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
                return StatusCode(400, $"Bad request error: {ex}");
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
                return StatusCode(400, $"Bad request error: {ex}");
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
                return StatusCode(400, $"Bad request error: {ex}");
            }
            
        }

        [HttpPost]
        public IActionResult AddBellRing([FromBody] BellRing item)
        {
            try
            {
                logic.InsertBellRing(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("GetAllSequencedBellRings")]
        public IActionResult GetAllSequencedBellRings()
        {
            try
            {
                return Ok(logic.GetAllSequencedBellRings());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpGet("GetOneSequencedBellRing/{id}")]
        public IActionResult GetAllSequencedBellRings(string id)
        {
            try
            {
                return Ok(logic.GetSequencedBellring(id));

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

        [HttpPost("SetBellRingIntervalByPath/{id}")]
        public IActionResult SetBellRingIntervalByPath(string id)
        {
            try
            {
                logic.SetBellRingIntervalByPath(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request error: {ex}");
            }
        }

    }
}
