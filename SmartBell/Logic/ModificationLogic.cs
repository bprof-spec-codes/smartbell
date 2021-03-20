﻿using Models;
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
            templateRepo.Insert(template);
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


        // TODO: These logic methods should be fixed asap (sql antipattern issue...)
        /*public void ModifyByTemplate(DateTime dayDate,Template template)
        {
            IQueryable<BellRing> BellringsOfDay = GetBellRingsForDay(dayDate);
            if (BellringsOfDay == null || template.TemplateElements == null)
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
            foreach (var item in template.TemplateElements)
            {
                BellRing b = item;
                b.BellRingTime=new DateTime(dayDate.Year,dayDate.Month,dayDate.Day,b.BellRingTime.Hour,b.BellRingTime.Minute,b.BellRingTime.Second);
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
        /*public void FillDbbyTemplate(Template template,DateTime StartDate, DateTime EndDate) 
        {
            List<BellRing> bellRingsForADay = new List<BellRing>();
            foreach (DateTime day in EachDay(StartDate, EndDate)) // loops through an entire school year
            {
                bellRingsForADay = template.TemplateElements;
                if (day.Day<6) // checks if it's a workday Monday->Friday
                {
                    foreach (var item in bellRingsForADay)
                    {
                        item.BellRingTime= new DateTime(day.Year, day.Month, day.Day, item.BellRingTime.Hour, item.BellRingTime.Minute, item.BellRingTime.Second);
                        InsertBellRing(item);
                    }
                }
            }
        }
        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }*/

    }
}
