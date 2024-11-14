using IProcessingLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProcessingLog
{
    public interface IChangeDetectorCurve
    {
        public IndexRange DetectChanges(Curve curve1, Curve curve2);
    }
}

