using Data;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Net;

namespace Logic
{
    public class ReadLogic : IReadLogic
    {
        public void GetAllFiles(IList<OutputPath> outputs)
        {
            foreach (var item in outputs)
            {
                string url = ConstConfig.DomainAddress + @$"\File\filename={item.FilePath}";
                WebClient wc = new WebClient();
                //Check if file exists if so check for modification date
                wc.DownloadFile(url, item.FilePath); //path can be specified here perfectly like : @"c:\myfile.txt"
            }   
        }

        public IList<BellRing> GetBellRingsForDay(DateTime dayDate)
        {
            string url = ConstConfig.DomainAddress + @$"\Client\GetBellRingsForDay\id={dayDate}";
            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<List<BellRing>>(jsonContent);

        }

        public IList<OutputPath> GetOutputForBellring(string bellringId)
        {
            string url = ConstConfig.DomainAddress + @$"\Client\GetOutputsForBellRing\id={bellringId}";
            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<List<OutputPath>>(jsonContent);
        }
    }
}
