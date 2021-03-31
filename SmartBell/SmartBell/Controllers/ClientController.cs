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
    [Route("Client")]
    public class ClientController : ControllerBase
    {
        ClientLogic clientLogic;
        TimeLogic timeLogic;

        public ClientController(ClientLogic clientLogic, TimeLogic timeLogic)
        {
            this.clientLogic = clientLogic;
            this.timeLogic = timeLogic;
        }

       [HttpGet("GetBellRingsForDay/{dayDate}")]
       public IQueryable<BellRing> GetBellRingsForDay(DateTime dayDate)
        {

            return clientLogic.GetBellRingsForDay(dayDate);
        }
        [HttpGet("GetCurrentDateTime/{ntpServerAddress}")]
        public DateTime GetCurrentDateTime(string ntpServerAddress)
        {

            return timeLogic.GetCurrentDateTime(ntpServerAddress);
        }
        [HttpGet("GetNextBellRing/{dayDate}&{ntpServerAddress}")]
        public DateTime GetNextBellRing(DateTime dayDate,string ntpServerAddress)
        {

            return timeLogic.GetNextBellRing(dayDate, ntpServerAddress);
        }
    }
}
