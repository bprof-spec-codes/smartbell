using Data;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TimeLogic : ITimeLogic
    {
        public DateTime GetNetworkTime()
        {
            string url = ConstConfig.DomainAddress + @$"/Client/GetCurrentDateTime/{ConstConfig.NtpAddress}";
            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<DateTime>(jsonContent);
        }

        public BellRing GetNextBellRingTime(DateTime dayDate)
        {
            string url = ConstConfig.DomainAddress + @$"/Client/GetNextBellRing/{dayDate}";
            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<BellRing>(jsonContent);
        }
    }
}
