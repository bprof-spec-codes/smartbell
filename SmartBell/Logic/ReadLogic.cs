using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ReadLogic
    {
        IBellRingRepository bellRingRepo;
        ITemplateRepository templateRepo;
        IHolidayRepository holidayRepo;
        ITemplateElementRepository templateElementRepo;
        IOutputPathRepository outputPathRepo;
        public ReadLogic(IBellRingRepository bellRingRepo, ITemplateRepository templateRepo, IHolidayRepository holidayRepo, ITemplateElementRepository templateElementRepo, IOutputPathRepository outputPathRepo)
        {
            this.bellRingRepo = bellRingRepo;
            this.templateRepo = templateRepo;
            this.holidayRepo = holidayRepo;
            this.templateElementRepo = templateElementRepo;
            this.outputPathRepo = outputPathRepo;
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
        public OutputPath GetOneOutputPath(string id)
        {
            return outputPathRepo.GetOne(id);
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
        public IQueryable<OutputPath> GetAllOutputPath()
        {
            return outputPathRepo.GetAll();
        }

        public IQueryable<Template> GetAllSampleTemplate()
        {
            return templateRepo.GetAll().Where(x => x.Id.Length < 4); ;
        }

        public IQueryable<Holiday> GetAllCalendarHoliday()
        {
            return holidayRepo.GetAll().Where(x => x.Type.Equals(HolidayType.Holiday));
        }

        public IQueryable<TemplateElement> GetElementsForTemplate(string templateId)
        {
            return templateRepo.GetOne(templateId).TemplateElements.AsQueryable();
        }

        public IQueryable<OutputPath> GetOutputsForBellRing(string bellringId)
        {
            return outputPathRepo.GetAll().Where(x => x.BellRingId == bellringId);
        }

        public IQueryable<BellRing> GetAllSequencedBellRings()
        {
            return bellRingRepo.GetAll().Where(x => x.Description != null && x.OutputPaths.Count() > 1 && x.Type.Equals(BellRingType.Special));
        }
        public BellRing GetSequencedBellring(string id)
        {
            return GetAllSequencedBellRings().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
