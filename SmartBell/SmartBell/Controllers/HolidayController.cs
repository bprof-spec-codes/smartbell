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
        ModificationLogic modlogic;
        ReadLogic readlogic;

        public HolidayController(ModificationLogic logic, ReadLogic readlogic)
        {
            this.modlogic = logic;
            this.readlogic = readlogic;
        }

        [HttpDelete("{id}")]
        public void DeleteHoliday(string id)
        {
            Holiday holiday = readlogic.GetOneHoliday(id);
            modlogic.DeleteHoliday(holiday);
        }
        [HttpGet("{id}")]
        public Holiday GetHoliday(string id)
        {
            return readlogic.GetOneHoliday(id);
        }
        [HttpGet]
        public IEnumerable<Holiday> GetAllHolidays()
        {
            return readlogic.GetAllHoliday();
        }

        [HttpPost]
        public void AddHoliday([FromBody] Holiday item)
        {
            modlogic.InsertHoliday(item);
        }

        [HttpGet("GetAllCalendarHoliday")]
        public IQueryable GetAllCalenderHoliday()
        {
            return readlogic.GetAllCalendarHoliday();
        }
    }
}
