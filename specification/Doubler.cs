using System;
public class Doubler : IAlgorythm {

    private int InputCurvesCnt = 0;
    private int InputParametersCnt = 0;
    private int OutputCurvesCnt = 0;


    public void Process(Curve[] inputCurves, IEnumerable<interv_idx>[] changed_idx_inputCurves, 
                            Parameter[] inputParameters, (string, bool)[] param_chng_status, Curve[] outputCurves, 
                                IEnumerable<interv_idx>[] changed_idx_outputCurves) 
    {
        InputCurvesCnt = inputCurves.Length;
        InputParametersCnt = inputParameters.Length;
        OutputCurvesCnt = outputCurves.Length;

        if Array.TrueForAll(inputCurves, c => {
                                                return c.Value == null || c.Value == [];
                                                }
        ) {
            Console.WriteLine("Empty input.")
        } else {
            
        }
    }

    public int CountInputCurves{get; private set;} {

    }
    public int publicCountInputParameters{get;} {

    }
    public int CountOutputCurves{get;} {

    }
}