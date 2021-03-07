using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ModificationLogic
    {
        BellRingRepository bellRingRepo;
        TemplateRepository templateRepo;
        HolidayRepository holidayRepo;
        public ModificationLogic(BellRingRepository bellRingRepo, TemplateRepository templateRepo, HolidayRepository holidayRepo)
        {
            this.bellRingRepo = bellRingRepo;
            this.templateRepo = templateRepo;
            this.holidayRepo = holidayRepo;
        }

        // Insert
        public void InsertBellRing(BellRing bellRing)
        {
            bellRingRepo.Insert(bellRing);
        }

        public void InsertHoliday(Holiday holiday)
        {
            holidayRepo.Insert(holiday);
        }

        public void InsertTemplate(Template template)
        {
            templateRepo.Insert(template);
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

        public IQueryable<BellRing> GetBellRingsForDay(DateTime dayDate)
        {
            IQueryable<BellRing> BellringsOfDay = bellRingRepo.GetAll().Where(bellring => bellring.BellRingTime.Date == dayDate.Date);
            return BellringsOfDay;
        }
    }
}
