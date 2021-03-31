using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ITimeLogic
    {
        DateTime GetNetworkTime();
        DateTime GetNextBellRingTime(DateTime dayDate);
    }
}
