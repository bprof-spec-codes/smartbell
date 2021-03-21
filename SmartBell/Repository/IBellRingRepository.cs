using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBellRingRepository : IRepository<BellRing>
    {
        void SetIntervalByAudioPath(string Id);
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

        public void SetIntervalByAudioPath(string id)
        {
            var Bellring = GetOne(id);
            if (Bellring == null)
            {
                return;
            } 

            // TODO: If possible Interval should be able to be set by the mp3 file's duration
            /*
            Bellring.Interval = ???;
             */
        }
    }
}
