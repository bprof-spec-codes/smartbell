using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ModificationLogic
    {
        IBellRingRepository bellRingRepo;
        ITemplateRepository templateRepo;
        IHolidayRepository holidayRepo;
        ITemplateElementRepository templateElementRepo;
        public ModificationLogic(IBellRingRepository bellRingRepo, ITemplateRepository templateRepo, IHolidayRepository holidayRepo, ITemplateElementRepository templateElementRepo)
        {
            this.bellRingRepo = bellRingRepo;
            this.templateRepo = templateRepo;
            this.holidayRepo = holidayRepo;
            this.templateElementRepo = templateElementRepo;
        }

        // Insert
        public void InsertBellRing(BellRing bellRing)
        {
            bellRing.Id = Guid.NewGuid().ToString();
            if (bellRing.IntervalSeconds>0)
            {
                bellRing.Interval = new TimeSpan(0, 0, bellRing.IntervalSeconds);
            }
            bellRingRepo.Insert(bellRing);
        }

        public void InsertHoliday(Holiday holiday)
        {
            holiday.Id = Guid.NewGuid().ToString();
            holidayRepo.Insert(holiday);
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
            templateRepo.Insert(template);
        }
        private bool VerifyTemplateName(string name)
        {
            IQueryable<Template> SameNames = GetAllTemplate().Where(x => x.Name == name);
            if (SameNames.Count()==0)
            {
                return true;
            }
            return false;
        }
        public void InsertTemplateElement(TemplateElement templateElement)
        {
            templateElement.Id = Guid.NewGuid().ToString();
            templateElementRepo.Insert(templateElement);
        }
        

        // Get one
        public BellRing GetOneBellring(string id)
        {
            return bellRingRepo.GetOne(id);
        }

        public Holiday GetOneHoliday(string id)
        {
            return holidayRepo.GetOne(id);
        }

        public Template GetOneTemplate(string id)
        {
            return templateRepo.GetOne(id);
        }
        public TemplateElement GetOneTemplateElement(string id)
        {
            return templateElementRepo.GetOne(id);
        }
        // Get all
        public IQueryable<BellRing> GetAllBellring()
        {
            return bellRingRepo.GetAll();
        }

        public IQueryable<Holiday> GetAllHoliday()
        {
            return holidayRepo.GetAll();
        }

        public IQueryable<Template> GetAllTemplate()
        {
            return templateRepo.GetAll();
        }
        public IQueryable<TemplateElement> GetAllTemplateElement()
        {
            return templateElementRepo.GetAll();
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

        // BellRingSpecific method
        public void SetIntervalByAudioPath(string id)
        {
            bellRingRepo.SetIntervalByAudioPath(id);
        }

        // This method will allow us to get all Elements for a ceratin template (one to many)
        public IQueryable<TemplateElement>GetElementsForTemplate(string templateId)
        {
            return templateRepo.GetOne(templateId).TemplateElements.AsQueryable();
        }

        public IQueryable<BellRing> GetBellRingsForDay(DateTime dayDate)
        {
            IQueryable<BellRing> BellringsOfDay = GetAllBellring().Where(bellring => bellring.BellRingTime.Date == dayDate.Date);
            return BellringsOfDay;
        }


        public string CheckForIntersect(DateTime dayDate, Template template)
        {
            string output = "";
            List<BellRing> BellringsOfDay = GetBellRingsForDay(dayDate).Where(x=>x.Type.Equals(BellRingType.Special)).ToList();
            List<TemplateElement> ElementsOfTemplate = GetElementsForTemplate(template.Id).ToList();
            if (ElementsOfTemplate.Count() % 2 !=0)
            {
                throw new Exception("Template elements declaration is incorrect, all start types have a separate end type");
            }
            List<BellRing> ElementsOfTemplateForThisDay = new List<BellRing>();
            foreach (var item in ElementsOfTemplate)
            {
                BellRing b = AssignNewBellRingByTemplateElement(item, dayDate);
                ElementsOfTemplateForThisDay.Add(b);
            }
            for (int i = 1; i < ElementsOfTemplateForThisDay.Count()-1; i+=2)
            {
                foreach (var item in BellringsOfDay)
                {
                    if (BellringsOfDay[i-1].BellRingTime < item.BellRingTime && item.BellRingTime < BellringsOfDay[i].BellRingTime)
                    {
                        output += $"\n Template Modification intersect between type StartTime:{BellringsOfDay[i - 1].BellRingTime} " +
                            $"and EndTime:{BellringsOfDay[i].BellRingTime} there is a Special type with which shall not rang at: {item.BellRingTime}";
                    }
                    else if (BellringsOfDay[i - 1].BellRingTime > item.BellRingTime && BellringsOfDay[i - 1].BellRingTime < item.BellRingTime+item.Interval)
                    {
                        output += $"\n Template Modification intersect Special type of bellring starts at : {item.BellRingTime} " +
                            $"has the interval of {item.Interval} which creates an intersect with the StartTime:{BellringsOfDay[i - 1].BellRingTime}";
                    }
                }
            }
            return output;
        }
        
        public void ModifyByTemplate(DateTime dayDate,Template template)
        {
            IQueryable<BellRing> BellringsOfDay = GetBellRingsForDay(dayDate);
            IQueryable<TemplateElement> ElementsOfTemplate = GetElementsForTemplate(template.Id);
            if (BellringsOfDay == null || ElementsOfTemplate == null)
            {
                return;
            }
            foreach (var item in BellringsOfDay)
            {
                if (item.Type.Equals(BellRingType.Start) || item.Type.Equals(BellRingType.End))
                {
                    DeleteBellring(item);
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
            IQueryable<Holiday> holidays = GetAllHoliday();
            if (holidays == null )
            {
                return;
            }
            foreach (var item in holidays)
            {
                IQueryable<BellRing> bellRingsDuringHoliday =
                    GetAllBellring().Where(bellring => bellring.BellRingTime >= item.StartTime && item.EndTime >= bellring.BellRingTime);
                if (bellRingsDuringHoliday!=null)
                {
                    foreach (var BellRingToBeRemoved in bellRingsDuringHoliday)
                    {
                        DeleteBellring(BellRingToBeRemoved);
                    }
                }
            }
        }

        public void RemoveByHoliday(Holiday h)
        {
            IQueryable<BellRing> bellRingsDuringHoliday =
                    GetAllBellring().Where(bellring => bellring.BellRingTime >= h.StartTime && h.EndTime >= bellring.BellRingTime);
            if (bellRingsDuringHoliday != null)
            {
                foreach (var BellRingToBeRemoved in bellRingsDuringHoliday)
                {
                    DeleteBellring(BellRingToBeRemoved);
                }
            }
        }
        // this method should be "locked" from the frontend site to only allow years to be filled by a template with a name like "normal" 
        public void FillDbByTemplate(Template template,DateTime StartDate, DateTime EndDate) 
        {
            if (template == null)
            {
                return;
            }
            List<BellRing> bellRingsForADay = new List<BellRing>();
            IQueryable<TemplateElement> ElementsOfTemplate = GetElementsForTemplate(template.Id);
            foreach (DateTime day in EachDay(StartDate, EndDate)) // loops through an entire school year
            {
                if (day.Day<6) // checks if it's a workday Monday->Friday
                {
                    foreach (var item in ElementsOfTemplate)
                    {
                        BellRing b = AssignNewBellRingByTemplateElement(item, day);
                        InsertBellRing(b);
                    }
                }
            }
        }
        private BellRing AssignNewBellRingByTemplateElement(TemplateElement templateElement,DateTime dayDate)
        {
            BellRing b = new BellRing()
            {
                Id = Guid.NewGuid().ToString(),
                AudioPath = templateElement.AudioPath,
                Interval = templateElement.Interval,
                Type = templateElement.Type,
                BellRingTime = new DateTime(dayDate.Year, dayDate.Month, dayDate.Day, templateElement.BellRingTime.Hour, templateElement.BellRingTime.Minute, templateElement.BellRingTime.Second),
            };
            return new BellRing();
        }
        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

    }
}
