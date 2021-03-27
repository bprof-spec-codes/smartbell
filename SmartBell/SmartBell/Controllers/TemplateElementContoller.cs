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
        ModificationLogic modlogic;
        ReadLogic readlogic;

        public TemplateElementContoller(ModificationLogic logic, ReadLogic readlogic)
        {
            this.modlogic = logic;
            this.readlogic = readlogic;
        }

        [HttpDelete("{id}")]
        public void DeleteTemplateElement(string id)
        {
            TemplateElement templateElement = readlogic.GetOneTemplateElement(id);
            modlogic.DeleteTemplateElement(templateElement);
        }

        [HttpGet("{id}")]
        public TemplateElement GetTemplateElement(string id)
        {
            return readlogic.GetOneTemplateElement(id);
        }

        [HttpGet]
        public IEnumerable<TemplateElement> GetAllTemplate()
        {
            return readlogic.GetAllTemplateElement();
        }

        [HttpPost]
        public IActionResult AddTemplateElement([FromBody] TemplateElement item)
        {
            try
            {
                modlogic.InsertTemplateElement(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
            
        }
    }
}
