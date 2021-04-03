using Data;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
        public IList<BellRing> RemoveElapsedBellRing(string id,List<BellRing> list)
        {
            BellRing b = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(b);
            return list;            
        }
    }
}
