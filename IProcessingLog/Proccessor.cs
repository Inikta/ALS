namespace IProcessingLog
{

    public class Processor
    {
        public IList<Dataset> CurrentDatasets { get; private set; }
        public IList<Dataset> InputDatasets { get; private set; }
        public IList<Dataset> OutputDatasets { get; private set; }
        public Dictionary<string, Parameter> InputParameters { get; private set; }
        public (string, bool)[] ParameterChangeStatus { get; private set; }
        public IndexRange[] CurrentIndexRanges { get; private set; } = [];
        public ProcessScheme ProcessScheme { get; set; }

        private IChangeDetectorCurve changeDetectorCurve;

        private IChangeDetectorParameter changeDetectorParameter1;

        private IList<Dataset> previousInputDatasets = new List<Dataset>();

        private Dictionary<string, Parameter> previousParameters = new Dictionary<string, Parameter>();


        public Processor(ProcessScheme processScheme, IList<Dataset> inputDatasets, IList<Parameter> inputParameters, 
                            IChangeDetectorCurve changeDetectorCurve, IChangeDetectorParameter changeDetectorParameter)
        {
            ProcessScheme = processScheme;

            InputDatasets = [];
            CurrentDatasets = [];
            OutputDatasets = [];

            InputDatasets = inputDatasets;
            CurrentDatasets = inputDatasets;

            InputParameters = [];

            foreach (var currentParameter in inputParameters)
            {
                if (!InputParameters.TryAdd(currentParameter.Name, currentParameter))
                {
                    continue;
                }
            }

            ParameterChangeStatus = new (string, bool)[InputParameters.Count];
            for (int i = 0; i < ParameterChangeStatus.Length; i++) { ParameterChangeStatus[i] = (InputParameters.Keys.ToArray()[i], false); }

            this.changeDetectorCurve = changeDetectorCurve;
            changeDetectorParameter1 = changeDetectorParameter;
        }

        public void Process()
        {
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
                        CurrentIndexRanges[i] = range;
                    }
                }
            }

            while (ProcessScheme.Sequence.Count > 0)
            {
                IAlgorythm algo = ProcessScheme.Sequence.Dequeue();

                var range = CurrentIndexRanges;
                int cnt = 0;

                foreach (var dataset in InputDatasets)
                {
                    Curve[] outCurves = dataset.CurvesByName.Values.ToArray();
                    algo.Process(dataset.CurvesByName.Values.ToArray(), range, InputParameters.Values.ToArray(), ParameterChangeStatus, outCurves, CurrentIndexRanges);
                    CurrentDatasets[cnt] = new Dataset(algo.GetCurves(), dataset.Name);
                    cnt++;
                }
            }
        }
    }
}