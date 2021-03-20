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
    [Route("Holiday")]
    public class HolidayController : ControllerBase
    {
        ModificationLogic logic;

        public HolidayController(ModificationLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{id}")]
        public void DeleteHoliday(string id)
        {
            Holiday holiday = logic.GetOneHoliday(id);
            logic.DeleteHoliday(holiday);
        }
        [HttpGet("{id}")]
        public Holiday GetHoliday(string id)
        {
            return logic.GetOneHoliday(id);
        }
        [HttpGet]
        public IEnumerable<Holiday> GetAllHolidays()
        {
            return logic.GetAllHoliday();
        }

        [HttpPost]
        public void AddHoliday([FromBody] BellRing item)
        {
            logic.InsertBellRing(item);
        }
    }
}
