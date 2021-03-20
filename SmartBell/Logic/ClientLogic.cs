using Models;
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

        public ClientLogic(ModificationLogic modLogic)
        {
            this.modLogic = modLogic;
        }

        public Template GetTemplateByName(string name)
        {
            return modLogic.GetAllTemplate().Where(x => x.Name == name).FirstOrDefault();  
        }
        public IQueryable<TemplateElement> GetElementsForTemplate(string id)
        {
            return modLogic.GetElementsForTemplate(id);
        }
        public IQueryable<BellRing> GetBellRingsForDay(DateTime dayDate)
        {
            return modLogic.GetBellRingsForDay(dayDate);
        }
    }
}
