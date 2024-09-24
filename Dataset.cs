public class Dataset {
    private Dictionary<string, Curve> CurvesList = {get; private set;}

    public Dataset(ArrayList<Curve> curvesList) {
        CurvesList = curvesList;
    }

    public Curve getByName(string name) {
        //foreach
    }

    public Curve this[string namecurve]{
        get{
            return null;
        }
        set{
            
        }
    }

    public Curve this[int i]{
        get{
            return null;
        }
        set{
            
        }
    }

    public int Count{
        get{
            return CurvesList.Count;
        }
    }

}