using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [ApiController]
    [Route("Template")]
    public class TemplateController:ControllerBase
    {
        ModificationLogic logic;

        public TemplateController(ModificationLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{id}")]
        public void DeleteTemplate(string id)
        {
            Template template = logic.GetOneTemplate(id);
            logic.DeleteTemplate(template);
        }
        [HttpGet("{id}")]
        public Template GetTemplate(string id)
        {
            return logic.GetOneTemplate(id);
        }

        [HttpGet]
        public IEnumerable<Template> GetAllTemplate()
        {
            return logic.GetAllTemplate();
        }

        [HttpPost]
        public void AddTemplate([FromBody] Template item)
        {
            logic.InsertTemplate(item);
        }

    }
}
