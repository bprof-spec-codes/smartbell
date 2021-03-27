using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ClientLogic
    {
        ModificationLogic modLogic;
        ReadLogic readlogic;
        IBellRingRepository bellRingRepo;
        ITemplateRepository templateRepo;

        public ClientLogic(ModificationLogic logic,IBellRingRepository bellRingRepo, ITemplateRepository templateRepo)
        {
            this.modLogic = logic;
            this.bellRingRepo = bellRingRepo;
            this.templateRepo = templateRepo;
        }

        public Template GetTemplateByName(string name)
        {
            return templateRepo.GetAll().Where(x => x.Name == name).FirstOrDefault();  
        }
        public IQueryable<TemplateElement> GetElementsForTemplate(string id)
        {
            return readlogic.GetElementsForTemplate(id);
        }
        public IQueryable<BellRing> GetBellRingsForDay(DateTime dayDate)
        {
            return bellRingRepo.GetBellRingsForDay(dayDate);
        }
    }
}
