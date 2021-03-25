using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBell.Controllers
{
    [ApiController]
    [Route("Bellring")]
    public class BellRingController : ControllerBase
    {
        ModificationLogic logic;

        public BellRingController(ModificationLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{id}")]
        public void DeleteBellRing(string id)
        {
            BellRing bellring = logic.GetOneBellring(id);
            logic.DeleteBellring(bellring);
        }
        [HttpGet("{id}")]
        public BellRing GetBellRing(string id)
        {
            return logic.GetOneBellring(id);
        }

        [HttpGet]
        public IEnumerable<BellRing> GetAllBellRings()
        {
            return logic.GetAllBellring();
        }

        [HttpPost]
        public void AddBellRing([FromBody] BellRing item)
        {
            logic.InsertBellRing(item);
        }

        [HttpPost("PostTTSString/{content} & {filename}")]
        public IActionResult PostTTSFileFromString(string content,string filename)
        {
            try
            {
                var folderName = "Output";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                var fullpath = Path.Combine(pathToSave, filename);
                if (!System.IO.File.Exists(fullpath))
                {
                    System.IO.File.WriteAllText(fullpath, content);
                    return Ok();
                }
                return BadRequest("File already exists.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("DeleteTTSByName/ {filename}")]
        public IActionResult DeleteTTSFileByName(string filename)
        {
            try
            {
                var folderName = "Output";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                var fullpath = Path.Combine(pathToSave, filename);
                if (System.IO.File.Exists(fullpath))
                {
                    System.IO.File.Delete(fullpath);
                    return Ok();
                }
                return BadRequest("File does not exists.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
