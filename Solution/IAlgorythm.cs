namespace LinkageAlgorythm
{
    using interv_idx = (int idx_begin, int idx_end);
    public interface IAlgorythm
    {
        void Process(Curve[] inputCurves, interv_idx[] changed_idx_inputCurves,
                        Parameter[] inputParameters, (string, bool)[] param_chng_status, Curve[] outputCurves,
                            interv_idx[] changed_idx_outputCurves);
        int CountInputCurves { get; }
        int CountInputParameters { get; }
        int CountOutputCurves { get; }
    }
}