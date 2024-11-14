using IProcessingLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingLog.Alg
{
    public class ChangeDetectorCurveSimple : IChangeDetectorCurve       //make tests
    {
        public IndexRange DetectChanges(Curve curve1, Curve curve2)
        {
            double[] value1 = curve1.Value;
            double[] value2 = curve2.Value;

            if (value1.Length != value2.Length)
            {
                var indexRange = new IndexRange();
                indexRange.Add((0, value2.Length - 1));

                return indexRange;
            }

            IList<(int, int)> ilist = new List<(int, int)> ();
            
            bool isStartIdxDefined = false;
            int idxStart = 0;

            for (int i = 0; i < value2.Length; i++)
            {
                if (value1[i] != value2[i] && isStartIdxDefined == false)
                {
                    idxStart = i;
                    isStartIdxDefined = true;
                    continue;
                }

                if (value1[i] == value2[i] && isStartIdxDefined == true)
                {
                    ilist.Add((idxStart, i - 1));
                    isStartIdxDefined = false;
                    continue;
                }
            }

            if (isStartIdxDefined == true)
            {
                ilist.Add((idxStart, value2.Length - 1));
            }

            return new IndexRange(ilist);
        }
    }
}
