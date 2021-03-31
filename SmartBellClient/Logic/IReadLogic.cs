using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IReadLogic
    {
        IList<BellRing> GetBellRingsForDay(DateTime dayDate);
        IList<OutputPath> GetOutputForBellring(string bellringId);
        void GetAllFiles(IList<OutputPath> outputs);
    }
}
