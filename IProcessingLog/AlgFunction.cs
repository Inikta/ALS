using IProcessingLog;

namespace IProcessingLog
{

     
    public class AlgFunction
    {

        public delegate void Function(double[] inCurveValue, Parameter[] inputParameters, double[] outCurveValue);
        private Function f;
        //TODO 
        public AlgFunction(Function _f)
        {
            f = _f;
        }
        public void Process(Curve[] inputCurves, IEnumerable<IndexRange>[] inputChanges,
                        Parameter[] inputParameters, (string, bool)[] param_chng_status, Curve[] outputCurves,
                            IEnumerable<IndexRange>[] outputChanges)
        {

        }
        public int CountInputCurves { get; private set; }
        public int CountInputParameters { get; private set; }
        public int CountOutputCurves { get; private set; }
    }
}