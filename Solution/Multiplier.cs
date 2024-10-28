using LinkageAlgorythm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public delegate double MultiplierFucntion(double? x);
    class Multiplier : IAlgorythm
    {
        public Curve[] ChangedCurves { get; private set; }
        private MultiplierFucntion funcDelegate;

        public Multiplier(MultiplierFucntion del)
        {
            funcDelegate = del;
        }

        public void Process(Curve[] inputCurves, (int idx_begin, int idx_end)[] changed_idx_inputCurves, 
                            Parameter[] inputParameters, (string, bool)[] param_chng_status, Curve[] outputCurves, 
                            (int idx_begin, int idx_end)[] changed_idx_outputCurves)
        {
            ChangedCurves = (Curve[])outputCurves.Clone();
            int idx_pair_cnt = 0;

            foreach (Curve curve in inputCurves)
            {
                for (int i = changed_idx_inputCurves[idx_pair_cnt].idx_begin; i < changed_idx_inputCurves[idx_pair_cnt].idx_end; i++)
                {
                    ChangedCurves[idx_pair_cnt].Value[i] = funcDelegate(curve.Value[i]);
                }

                idx_pair_cnt++;
            }
        }

        public int CountInputCurves => throw new NotImplementedException();

        public int CountInputParameters => throw new NotImplementedException();

        public int CountOutputCurves => throw new NotImplementedException();       
    }
}
