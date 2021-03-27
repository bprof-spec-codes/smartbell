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
    [Route("OutPutPath")]
    public class OutputPathController : ControllerBase
    {
        ModificationLogic modlogic;
        ReadLogic readlogic;

        public OutputPathController(ModificationLogic logic, ReadLogic readlogic)
        {
            this.modlogic = logic;
            this.readlogic = readlogic;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOutputPath(string id)
        {
            try
            {
                OutputPath outputPath = readlogic.GetOneOutputPath(id);
                modlogic.DeleteOutputPath(outputPath);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOutputPath(string id)
        {
            try
            {
                return Ok(readlogic.GetOneOutputPath(id));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }
        [HttpGet]
        public IActionResult GetAllOutputPaths()
        {
            try
            {
                return Ok(readlogic.GetAllOutputPath());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult AddOutputPath([FromBody] OutputPath item)
        {
            try
            {
                modlogic.InsertOutputPath(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }
    }
}
