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

        public TemplateController(ModificationLogic logic,ReadLogic readlogic)
        {
            this.modlogic = logic;
            this.readlogic = readlogic;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTemplate(string id)
        {
            try
            {
                Template template = readlogic.GetOneTemplate(id);
                modlogic.DeleteTemplate(template);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetTemplate(string id)
        {
            try
            {
                return Ok(readlogic.GetOneTemplate(id));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpGet]
        public IActionResult GetAllTemplate()
        {
            try
            {
                return Ok(readlogic.GetAllTemplate());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult AddTemplate([FromBody] Template item)
        {
            try
            {
                modlogic.InsertTemplate(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpGet("GetAllSampleTemplate")]
        public IActionResult GetAllSampleTemplate()
        {
            try
            {
                return Ok(readlogic.GetAllSampleTemplate());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpPost("ModifyByTemplate/{dateTime}&{id}")]
        public IActionResult ModifyByTemaplate(DateTime dateTime, string id)
        {
            try
            {
                Template template = readlogic.GetOneTemplate(id);
                modlogic.ModifyByTemplate(dateTime,template);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpPost("FillDbByTemplate")]
        public IActionResult FillDbByTemplate(string id, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                Template template = readlogic.GetOneTemplate(id);
                modlogic.FillDbByTemplate(template, StartDate, EndDate);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }
    }
}
