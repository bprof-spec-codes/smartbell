using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IReadLogic
    {
        IList<BellRing> GetBellRingsForDay(DateTime dayDate);
        IList<OutputPath> GetAllOutputPathsForDay(DateTime dayDate);
        void GetAllFiles(IList<OutputPath> outputs);
    }
}
