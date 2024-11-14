using IProcessingLog;
using System.Linq;

namespace ProcessingLog.Alg
{

    public class Doubler : IAlgorythm
    {

        private int InputCurvesCnt = 0;
        private int InputParametersCnt = 0;
        private int OutputCurvesCnt = 0;

        public Curve[] ChangedCurves { get; private set; } = [];

        public void Process(Curve[] inputCurves, IndexRange inputChanges,
                                Parameter[] inputParameters, (string, bool)[] param_chng_status, Curve[] outputCurves,
                                    IndexRange outputChanges)
        {
            InputCurvesCnt = inputCurves.Length;
            InputParametersCnt = inputParameters.Length;
            OutputCurvesCnt = outputCurves.Length;

            ChangedCurves = outputCurves;

            int pairCnt = 0;

            foreach ((int start, int end) range in inputChanges.Range)  //namechecking
            {
                if (range.start >= 0 && range.end >= 0)
                {
                    for (int i = range.start; i <= range.end; i++)
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

        public Curve[] GetCurves()
        {
            return ChangedCurves;
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