using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProcessingLog
{
    public class IndexRange
    {
        public IList<(int start, int end)> Range { get; private set; }

        public IndexRange()
        {
            Range = new List<(int start, int end)>();
        }

        public IndexRange(IList<(int start, int end)> list) { Range = list; }

        public bool Add((int start, int end) indexPair)
        {
            if (indexPair.start > indexPair.end)
            {
                return false;
            }

            Range.Add(indexPair);

            return true;
        }

        public void AddAll(IndexRange indexRange)
        {
            foreach (var item in Range)
            {
                Range.Add(item);
            }
        }


        // check correctness of range (indexes from small to big)
    }
}
