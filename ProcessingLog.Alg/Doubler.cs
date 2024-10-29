using System.Linq;

namespace ProcessingLog.Alg
{

    using interv_idx = (int idx_begin, int idx_end);
    public class Doubler : IAlgorythm
    {

        private int InputCurvesCnt = 0;
        private int InputParametersCnt = 0;
        private int OutputCurvesCnt = 0;

        public Curve[] ChangedCurves { get; private set; }

        public void Process(Curve[] inputCurves, interv_idx[] changed_idx_input,
                                Parameter[] inputParameters, (string, bool)[] param_chng_status, Curve[] outputCurves,
                                    interv_idx[] changed_idx_output)
        {
            InputCurvesCnt = inputCurves.Length;
            InputParametersCnt = inputParameters.Length;
            OutputCurvesCnt = outputCurves.Length;

            ChangedCurves = (Curve[])outputCurves.Clone();

            int pairCnt = 0;

            foreach (interv_idx pair in changed_idx_input)
            {
                if (pair.idx_begin >= 0 && pair.idx_end >= 0)
                {
                    for (int i = pair.idx_begin; i < pair.idx_end; i++)
                    {
                        ChangedCurves[pairCnt].Value[i] = inputCurves[pairCnt].Value[i];
                    }
                }

                pairCnt++;
            }

            /*ChangedCurves = from curve in inputCurves
                            where (from pair in changed_idx_input 
                                   where pair.idx_begin >= 0 && pair.idx_end >= 0
)
                            select inputCurves[pairCnt].Value;*/
        }


        int IAlgorythm.CountInputCurves
        {
            get { return InputCurvesCnt; }
        }

        int IAlgorythm.CountInputParameters
        {
            get { return InputParametersCnt; }
        }

        int IAlgorythm.CountOutputCurves
        {
            get { return OutputCurvesCnt; }
        }
    }
}