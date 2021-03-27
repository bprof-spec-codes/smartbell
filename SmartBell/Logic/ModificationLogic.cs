using Microsoft.AspNetCore.StaticFiles;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;


namespace Logic
{
    public class ModificationLogic
    {
        IBellRingRepository bellRingRepo;
        ITemplateRepository templateRepo;
        IHolidayRepository holidayRepo;
        ITemplateElementRepository templateElementRepo;
        IOutputPathRepository outputPathRepo;
        ReadLogic readlogic;
        public ModificationLogic(IBellRingRepository bellRingRepo, ITemplateRepository templateRepo, IHolidayRepository holidayRepo, ITemplateElementRepository templateElementRepo, IOutputPathRepository outputPathRepo, ReadLogic readLogic)
        {
            this.bellRingRepo = bellRingRepo;
            this.templateRepo = templateRepo;
            this.holidayRepo = holidayRepo;
            this.templateElementRepo = templateElementRepo;
            this.outputPathRepo = outputPathRepo;
            this.readlogic = readLogic;
        }

        // Insert One and Multiple
        public void InsertBellRing(BellRing bellRing)
        {
            bellRing.Id = Guid.NewGuid().ToString();
            if (bellRing.IntervalSeconds > 0)
            {
                bellRing.Interval = new TimeSpan(0, 0, bellRing.IntervalSeconds);
            }
            bellRingRepo.InsertOne(bellRing);
            if (bellRing.IntervalSeconds == 0) 
                SetBellRingIntervalByPath(bellRing.Id);
        }
        public void InsertMultipleBellRings(IQueryable<BellRing> bellRings)
        {
            foreach (BellRing bellRing in bellRings)
            {
                if (bellRingRepo.GetOne(bellRing.Id)!=null)
                {
                    InsertBellRing(bellRing); // Important to use the Logic's method which generates id-s
                }
                else
                {
                    bellRingRepo.Update(bellRing.Id, bellRingRepo.GetOne(bellRing.Id));
                }
            }
        }

        public void InsertHoliday(Holiday holiday)
        {
            holiday.Id = Guid.NewGuid().ToString();
            holidayRepo.InsertOne(holiday);
        }
        public void InsertTemplate(Template template)
        {
            template.Id = Guid.NewGuid().ToString();
            int i = 1;
            while (!VerifyTemplateName(template.Name))
            {
                template.Name += i;
                i++;
            }
            templateRepo.InsertOne(template);
        }

        private bool VerifyTemplateName(string name)
        {
            IQueryable<Template> SameNames = templateRepo.GetAll().Where(x => x.Name == name);
            if (SameNames.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public void InsertTemplateElement(TemplateElement templateElement)
        {
            templateElement.Id = Guid.NewGuid().ToString();
            if (templateElement.IntervalSeconds == 0)
            {
                throw new Exception("This parameter should never be zero, it's required.");
            }
            templateElement.Interval = new TimeSpan(0, 0, templateElement.IntervalSeconds);
            templateElementRepo.InsertOne(templateElement);
        }
        public void InsertOutputPath(OutputPath outputPath)
        {
            outputPath.Id = Guid.NewGuid().ToString();
            outputPathRepo.InsertOne(outputPath);
        }
        // Update
        public void UpdateBellRing(string oid,BellRing bellRing)
        {
            bellRingRepo.Update(oid, bellRing);
        }
        

        
        // Delete
        public void DeleteBellring(BellRing bellRing)
        {
            bellRingRepo.Delete(bellRing);
        }

        public void DeleteHoliday(Holiday holiday)
        {
            holidayRepo.Delete(holiday);
        }

        public void DeleteTemplate(Template template)
        {
            templateRepo.Delete(template);
        }
        public void DeleteTemplateElement(TemplateElement templateElement)
        {
            templateElementRepo.Delete(templateElement);
        }
        public void DeleteOutputPath(OutputPath outputPath)
        {
            outputPathRepo.Delete(outputPath);
        }
        //Save
        public void SaveBellring()
        {
            bellRingRepo.SaveChanges();
        }

        public void SaveHoliday()
        {
            holidayRepo.SaveChanges();
        }

        public void SaveTemplate()
        {
            templateRepo.SaveChanges();
        }
        public void SaveTemplateElement()
        {
            templateElementRepo.SaveChanges();
        }


        public void SetBellRingIntervalByPath(string id)
        {
            if (bellRingRepo.GetOne(id).IntervalSeconds>0)
            {
                throw new Exception("This Bellring has a static interval, so it shall not be changed.");
            }
            TimeSpan t = new TimeSpan(0, 0, 0, 0);
            IQueryable<OutputPath> outputPaths = readlogic.GetOutputsForBellRing(id);
            foreach (var item in outputPaths)
            {
                string path =
                Path.Combine(Environment.CurrentDirectory + @"\Output\", item.FilePath);
                if (File.Exists(path))
                {
                    string ct;
                    var x = new FileExtensionContentTypeProvider().TryGetContentType(path, out ct);
                    if (ct == "text/plain")
                    {
                        // TODO: For txt files we should implement a mathematical function to assume an interval.
                        char[] delims = { '.', '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };

                        string[] words = File.ReadAllText(path)
                            .Split(delims, StringSplitOptions.RemoveEmptyEntries);
                        TimeSpan avrageWordsDuration = new TimeSpan(0, 0, 0, 0, words.Length * 650);
                        t += avrageWordsDuration;

                    }
                    else if (ct == "audio/mpeg")
                    {
                        var tfile = TagLib.File.Create(path);
                        TimeSpan duration = tfile.Properties.Duration;
                        t += duration.Add(new TimeSpan(0, 0, 0, 1));
                    }

                    
                }
                else
                {
                    throw new Exception($"Couldn't get file with the name: {item}");
                }
            }
            if (t> new TimeSpan(0, 0, 0, 0))
            {
                BellRing b = bellRingRepo.GetOne(id);
                b.Interval = t;
                bellRingRepo.Update(id, b);
            }
        }

        // This method will allow us to get all Elements for a cerating template (one to many)
        

        public void ModifyByTemplate(DateTime dayDate, Template template)
        {
            IQueryable<BellRing> BellringsOfDay = bellRingRepo.GetBellRingsForDay(dayDate);
            IQueryable<TemplateElement> ElementsOfTemplate = readlogic.GetElementsForTemplate(template.Id);
            if (BellringsOfDay == null || ElementsOfTemplate == null)
            {
                return;
            }
            foreach (var item in BellringsOfDay)
            {
                if (item.Type.Equals(BellRingType.Start) || item.Type.Equals(BellRingType.End))
                {
                    bellRingRepo.Delete(item);
                }
            }

            foreach (var item in ElementsOfTemplate)
            {
                BellRing b = AssignNewBellRingByTemplateElement(item, dayDate);
                InsertBellRing(b);
            }
        }

        public void RemoveAllHolidays()
        {
            IQueryable<Holiday> holidays = holidayRepo.GetAll();
            if (holidays == null)
            {
                return;
            }
            foreach (var item in holidays)
            {
                IQueryable<BellRing> bellRingsDuringHoliday =
                    bellRingRepo.GetAll().Where(bellring => bellring.BellRingTime >= item.StartTime && item.EndTime >= bellring.BellRingTime);
                if (bellRingsDuringHoliday != null)
                {
                    foreach (var BellRingToBeRemoved in bellRingsDuringHoliday)
                    {
                        bellRingRepo.Delete(BellRingToBeRemoved);
                    }
                }
            }
        }

        public void RemoveByHoliday(Holiday h)
        {
            IQueryable<BellRing> bellRingsDuringHoliday =
                    bellRingRepo.GetAll().Where(bellring => bellring.BellRingTime >= h.StartTime && h.EndTime >= bellring.BellRingTime);
            if (bellRingsDuringHoliday != null)
            {
                foreach (var BellRingToBeRemoved in bellRingsDuringHoliday)
                {
                    bellRingRepo.Delete(BellRingToBeRemoved);
                }
            }
        }
        // this method should be "locked" from the frontend site to only allow years to be filled by a template with a name like "normal" 
        public void FillDbByTemplate(Template template, DateTime StartDate, DateTime EndDate)
        {
            if (template == null)
            {
                throw new Exception("Template element must be set to fill a year.");
            }
            List<BellRing> bellRingsForADay = new List<BellRing>();
            IQueryable<TemplateElement> ElementsOfTemplate = readlogic.GetElementsForTemplate(template.Id);
            DisableSequencedBellRingsInRange(StartDate, EndDate);
            DeleteRegularBellRingsInRange(StartDate, EndDate);
            foreach (DateTime day in EachDay(StartDate, EndDate)) // loops through an entire school year
            {
                if (day.Day < 6) // checks if it's a workday Monday->Friday
                {
                    foreach (var item in ElementsOfTemplate)
                    {
                        BellRing b = AssignNewBellRingByTemplateElement(item, day);
                        InsertBellRing(b);
                    }
                }
            }
        }
        private void DisableSequencedBellRingsInRange(DateTime StartDate, DateTime EndDate)
        {
           IQueryable<BellRing> inRange = readlogic.GetAllSequencedBellRings().Where(x => (x.BellRingTime >= StartDate && x.BellRingTime <= EndDate));
            foreach (BellRing bellRing in inRange)
            {
                BellRing b = bellRingRepo.GetOne(bellRing.Id);
                b.BellRingTime = new DateTime(1, 1, 1, bellRing.BellRingTime.Hour, bellRing.BellRingTime.Minute, bellRing.BellRingTime.Second);
                bellRingRepo.Update(b.Id, b);
            }
        }
        private void DeleteRegularBellRingsInRange(DateTime StartDate, DateTime EndDate)
        {
            List<BellRing> inRange = bellRingRepo.GetAll()
                .Where(x => (x.BellRingTime >= StartDate && x.BellRingTime <= EndDate))
                .ToList();
            foreach (BellRing bellRing in inRange)
            {
                bellRingRepo.Delete(bellRing);
            }
        }
        private BellRing AssignNewBellRingByTemplateElement(TemplateElement templateElement, DateTime dayDate)
        {
            BellRing b = new BellRing()
            {
                Id = Guid.NewGuid().ToString(),
                Interval = templateElement.Interval,
                Type = templateElement.Type,
                BellRingTime = new DateTime(dayDate.Year, dayDate.Month, dayDate.Day, templateElement.BellRingTime.Hour, templateElement.BellRingTime.Minute, templateElement.BellRingTime.Second),
            };
            bellRingRepo.InsertOne(b);
            OutputPath outputPath = new OutputPath()
            {
                Id = Guid.NewGuid().ToString(),
                FilePath = templateElement.FilePath,
                BellRingId = b.Id,
            };
            outputPathRepo.InsertOne(outputPath);
            return new BellRing();
        }
        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

    }
}
