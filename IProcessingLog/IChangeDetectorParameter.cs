using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProcessingLog
{
    public interface IChangeDetectorParameter
    {
        public bool DetectChanges(Parameter parameter1, Parameter parameter2); //realize with lambda-func
    }
}
