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
