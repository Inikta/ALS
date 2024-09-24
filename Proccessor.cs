public class CurveNameId {
    public string curvename{get; private set;};
    public string datasetname{get; private set;};

    public CurveNameId {
        
    }
}

public class Processor {
    Dictionary<string, Dataset> DatasetDictionary{get; private set;};

}