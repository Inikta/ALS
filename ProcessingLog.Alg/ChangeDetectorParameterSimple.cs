using IProcessingLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingLog.Alg
{
    public class ChangeDetectorParameterSimple : IChangeDetectorParameter
    {
        public bool DetectChanges(Parameter parameter1, Parameter parameter2)
        {
            return Equals(parameter1, parameter2);
        }
    }
}