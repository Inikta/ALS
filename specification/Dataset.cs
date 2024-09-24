public class Dataset {
    private Dictionary<string, Curve> CurvesByName = {get; private set;}

    public Dataset(Dictionary<string, Curve> curvesByName) {
        CurvesByName = curvesList;
    }

    public Curve getByName(string name) {
        if (CurvesByName.ContainsKey(name)) {
            return CurvesByName[name];
        }

        return null;
    }

    public Curve this[string namecurve]{
        get{
            return null;
        }
        set{
            if (CurvesByName.ContainsKey(namecurve)) {
                CurvesByName[namecurve] = value
            }
        }
    }

    public Curve this[int i]{
        get{
            return null;
        }
        set{
            return CurvesByName.Count = i
        }
    }

    public int Count{
        get{
            return CurvesByName.Count;
        }
    }
}