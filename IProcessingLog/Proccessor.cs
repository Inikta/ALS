using System;

namespace IProcessingLog
{

    public class Processor
    {
        public IList<Dataset> CurrentDatasets { get; private set; }
        public IList<Dataset> InputDatasets { get; private set; }
        public IList<Dataset> OutputDatasets { get; private set; }
        public IList<Parameter> InputParameters { get; private set; }
        public (string, bool)[] ParameterChangeStatus { get; private set; }
        public ProcessScheme ProcessScheme { get; set; }

        private IChangeDetectorCurve changeDetectorCurve;

        private IChangeDetectorParameter changeDetectorParameter1;

        private IList<Dataset> previousInputDatasets = new List<Dataset>();

        private Dictionary<string, Parameter> previousParameters = new Dictionary<string, Parameter>();

        // namesorting of algos & index ranges
        public Processor(ProcessScheme processScheme, IList<Dataset> inputDatasets, IList<Parameter> inputParameters, 
                            IChangeDetectorCurve changeDetectorCurve, IChangeDetectorParameter changeDetectorParameter)
        {
            ProcessScheme = processScheme;

            InputDatasets = [];
            CurrentDatasets = [];
            OutputDatasets = [];

            InputDatasets = inputDatasets;
            CurrentDatasets = inputDatasets;
            InputParameters = inputParameters;

            ParameterChangeStatus = new (string, bool)[InputParameters.Count];
            for (int i = 0; i < ParameterChangeStatus.Length; i++) { ParameterChangeStatus[i] = (InputParameters[i].Name, false); }

            this.changeDetectorCurve = changeDetectorCurve;
            changeDetectorParameter1 = changeDetectorParameter;

            if (previousInputDatasets.Count == 0)   // case for empty previous datasets
            {
                previousInputDatasets = new List<Dataset>(10);
            } else if (previousInputDatasets.Count < InputDatasets.Count)
            {
                for (int i = 0; i < InputDatasets.Count; i++)
                {
                    previousInputDatasets.Add(new Dataset());
                }
            }
        }

        public void Process()
        {
            IndexRange[] currentIndexRanges  = [];

            for (int i = 0; i < InputDatasets.Count; i++)
            {
                var inputDataset = InputDatasets[i];
                var previousDataset = previousInputDatasets[i];

                var inputCurvesKeys = InputDatasets[i].CurvesByName.Keys;
                var inputCurvesValues = InputDatasets[i].CurvesByName.Values;

                foreach (var key in inputCurvesKeys)
                {
                    if (previousDataset.CurvesByName.ContainsKey(key))
                    {
                        var range = changeDetectorCurve.DetectChanges(previousDataset.CurvesByName[key], inputDataset.CurvesByName[key]);
                        currentIndexRanges[i] = range;
                    }
                    else
                    {
                        currentIndexRanges[i].Add((0, InputDatasets[i].CurvesByName[key].Value.Length - 1));
                    }
                }
            }   // решить ошибку с повторной обработкой кривой

            while (ProcessScheme.Sequence.Count > 0)
            {
                IAlgorythm algo = ProcessScheme.Sequence.Dequeue();

                var range = currentIndexRanges;
                int cnt = 0;

                foreach (var dataset in InputDatasets)
                {
                    Curve[] outCurves = dataset.CurvesByName.Values.ToArray();
                    algo.Process(dataset.CurvesByName.Values.ToArray(), range[cnt], InputParameters.ToArray(), ParameterChangeStatus, outCurves, currentIndexRanges[cnt]);
                    CurrentDatasets[cnt] = new Dataset(algo.GetCurves(), dataset.Name);
                    cnt++;
                }
            }

            previousInputDatasets = CurrentDatasets;
        }
    }
}