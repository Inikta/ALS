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
            IndexRange indexRange = new IndexRange();

            double[] value1 = curve1.Value;
            double[] value2 = curve2.Value;

            if (value1.Length != value2.Length)
            {
                var range = new IndexRange();
                range.Add((0, value2.Length - 1));
                return range;
            }
            
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
                    indexRange.Add((idxStart, i - 1));
                    isStartIdxDefined = false;
                    continue;
                }
            }

            if (isStartIdxDefined == true)
            {
                indexRange.Add((idxStart, value2.Length - 1));
            }

            return indexRange;
        }
    }
}
