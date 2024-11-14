using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProcessingLog
{
    public class ProcessScheme(Queue<IAlgorythm> sequence)
    {
        public Queue<IAlgorythm> Sequence { get; private set; } = sequence;
    }
}
