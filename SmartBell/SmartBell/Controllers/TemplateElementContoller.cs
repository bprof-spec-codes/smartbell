using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBell.Controllers
{
    [ApiController]
    [Route("TemplateElement")]
    public class TemplateElementContoller:ControllerBase
    {
        ModificationLogic logic;

        public TemplateElementContoller(ModificationLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{id}")]
        public void DeleteTemplateElement(string id)
        {
            TemplateElement templateElement = logic.GetOneTemplateElement(id);
            logic.DeleteTemplateElement(templateElement);
        }

        [HttpGet("{id}")]
        public TemplateElement GetTemplateElement(string id)
        {
            return logic.GetOneTemplateElement(id);
        }

        [HttpGet]
        public IEnumerable<TemplateElement> GetAllTemplate()
        {
            return logic.GetAllTemplateElement();
        }

        [HttpPost]
        public IActionResult AddTemplateElement([FromBody] TemplateElement item)
        {
            try
            {
                logic.InsertTemplateElement(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
            
        }
    }
}
