namespace ProcessingLog
{
    using interv_idx = (int idx_begin, int idx_end);
    public class Processor
    {
        public Dictionary<string, Dataset> CurrentDatasets { get; private set; }
        public Dictionary<string, Dataset> InputDatasets { get; private set; }
        public Dictionary<string, Dataset> OutputDatasets { get; private set; }
        public Dictionary<string, Parameter> InputParameters { get; private set; }

        public IEnumerable<(string[] inputCurves, string[] inputParameters, string[] outParameters, IAlgorythm algorythm)> ProcessScheme { get; private set; }

        public Processor(IList<Dataset> inputDatasets, IList<Parameter> inputParameters)
        {
            InputDatasets = new Dictionary<string, Dataset>();
            CurrentDatasets = new Dictionary<string, Dataset>();

            DatasetsFiller(InputDatasets, inputDatasets);
            DatasetsFiller(CurrentDatasets, inputDatasets);

            InputParameters = new Dictionary<string, Parameter>();

            foreach (var currentParameter in inputParameters)
            {
                if (!InputParameters.ContainsKey(currentParameter.Name))
                {
                    InputParameters.Add(currentParameter.Name, currentParameter);
                }
                else
                {
                    continue;
                }
            }
        }

        public void process()
        {
            //updates datasets
        }

        /*public interv_idx ChangeDetector()
        {
            interv_idx intervals
        }*/

        private void DatasetsFiller(Dictionary<string, Dataset> current, IList<Dataset> input)
        {
            foreach (Dataset currentDataset in input)
            {
                if (!InputDatasets.ContainsKey(currentDataset.Name))
                {
                    current.Add(currentDataset.Name, currentDataset);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}