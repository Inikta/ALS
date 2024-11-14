using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProcessingLog
{
    public class ProcessScheme(Queue<IAlgorythm> sequence) // add curves and parameters in and out names for algorythms to know from where to where copy and etc.
    {
        public Queue<IAlgorythm> Sequence { get; private set; } = sequence;
    }
}
