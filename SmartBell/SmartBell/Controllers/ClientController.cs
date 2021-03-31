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

        public ClientController(ClientLogic clientLogic)
        {
            this.clientLogic = clientLogic;
        }

       [HttpGet("GetBellRingsForDay/{dayDate}")]
       public IQueryable<BellRing> GetBellRingsForDay(DateTime dayDate)
        {

            return clientLogic.GetBellRingsForDay(dayDate);
        }
    }
}
