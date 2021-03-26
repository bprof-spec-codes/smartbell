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
        public IActionResult DeleteBellRing(string id)
        {
            try
            {
                BellRing bellring = logic.GetOneBellring(id);
                logic.DeleteBellring(bellring);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
        }
        [HttpGet("{id}")]
        public IActionResult GetBellRing(string id)
        {
            try
            {
                return Ok(logic.GetOneBellring(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
        }

        [HttpGet]
        public IActionResult GetAllBellRings()
        {
            try
            {
                return Ok(logic.GetAllBellring());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
        }

        [HttpPost]
        public void AddBellRing([FromBody] BellRing item)
        {
            logic.InsertBellRing(item);
        }

        [HttpGet("GetAllSequencedBellRings")]
        public IQueryable<BellRing> GetAllSequencedBellRings()
        {
            return logic.GetAllSequencedBellRings();
        }

        [HttpGet("GetOneSequencedBellRing/{id}")]
        public BellRing GetAllSequencedBellRings(string id)
        {
            return logic.GetSequencedBellring(id);
        }

    }
}
