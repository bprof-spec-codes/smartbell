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
        ModificationLogic modlogic;
        ReadLogic readlogic;

        public TemplateController(ModificationLogic logic)
        {
            this.modlogic = logic;
        }

        [HttpDelete("{id}")]
        public void DeleteTemplate(string id)
        {
            Template template = readlogic.GetOneTemplate(id);
            modlogic.DeleteTemplate(template);
        }
        [HttpGet("{id}")]
        public Template GetTemplate(string id)
        {
            return readlogic.GetOneTemplate(id);
        }

        [HttpGet]
        public IEnumerable<Template> GetAllTemplate()
        {
            return readlogic.GetAllTemplate();
        }

        [HttpPost]
        public void AddTemplate([FromBody] Template item)
        {
            modlogic.InsertTemplate(item);
        }

        [HttpGet("GetAllSampleTemplate")]
        public IQueryable GetAllSampleTemplate()
        {
            return readlogic.GetAllSampleTemplate();
        }

    }
}
