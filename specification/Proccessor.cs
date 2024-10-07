public class Processor {
    public Dictionary<string, Dataset> InputDatasets{get; private set;};
    public Dictionary<string, Dataset> OutputDatasets{get; private set;};
    public Dictionary<string, Parameter> InputParameters{get; private set;};

    public IEnumerable<(string[] inputCurves, string[] inputParameters, string[] outParameters, IAlgorythm algorythm)> ProcessScheme{get; private set;};

    public Processor (IList<Dataset> inputDatasets, IList<Parameter> inputParameters) {
        InputDatasets = new Dictionary<string, Dataset>();

        foreach (var currentDataset in inputDatasets) {
            if (!InputDatasets.ContainsKey(currentDataset.name)) {
                InputDatasets.Add(currentDataset.name, currentDataset);
            } else {
                continue;
            }
        }

        InputParameters = new Dictionary<string, Parameter>();

        foreach (var currentParameter in inputParameters) {
            if (!InputParameters.ContainsKey(currentParameter.name)) {
                InputParameters.Add(currentParameter.name, currentParameter);
            } else {
                continue;
            }
        }
    }

    public process () {
        //updates datasets
    }

    //сделать алгоритм дублирования для изменений кривой, чтобы копировались только изменения.
    public Dictionary<string, Dataset> copyChanges () {
        var datasetsCopy = InputDatasets.Clone()
        
        foreach (var dataset in datasetsCopy) {
            foreach (var curve in dataset) {
                for (int i = 0; i < curve.Value.Length) {
                    if (curve.Value[i] != OutputDatasets[dataset.Name][curve.Name].Value[i]) {
                        curve.Value[i] = OutputDatasets[dataset.Name][curve.Name].Value[i];
                    }
                }      
            }
        }
        
        return datasetsCopy;
    }
}