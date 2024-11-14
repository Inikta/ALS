namespace IProcessingLog
{
    public interface IAlgorythm
    {
        void Process(Curve[] inputCurves, IndexRange inputChanges,
                        Parameter[] inputParameters, (string, bool)[] parameterChangeStatus, Curve[] outputCurves,
                            IndexRange outputChanges);
        int CountInputCurves { get; }
        int CountInputParameters { get; }
        int CountOutputCurves { get; }
        Curve[] GetCurves();
    }
}