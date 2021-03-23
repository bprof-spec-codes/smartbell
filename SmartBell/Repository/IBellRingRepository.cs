using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBellRingRepository : IRepository<BellRing>
    {
        
    }
    public class BellRingRepository : Repository<BellRing>, IBellRingRepository
    {
        public BellRingRepository(SbDbContext context) : base(context)
        {
        }

        public override BellRing GetOne(string id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        // TODO: Method must move to-> IOutPutPath repository as an entity specific method
        /*public bool PathExists(string id)
        {
            var bellRing = GetOne(id);
            try
            {
                string outPutDirpath = Path.Combine(Directory.GetCurrentDirectory(), @"Output");
                string fullPath = Path.Combine(outPutDirpath, bellRing.AudioPath);
                if (File.Exists(fullPath))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // TODO: This method is not entity specific it's dependent by output paths
        public void SetIntervalByAudioPath(string id)
        {
            var bellRing = GetOne(id);
            if (bellRing == null)
            {
                return;
            } 

            // TODO: If possible Interval should be able to be set by the mp3 file's duration
            
            Bellring.Interval = ???;
             
        }*/
    }
}
