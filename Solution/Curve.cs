public class Curve {

    public string Name{get; private set;}
    public double?[] Value{get; private set;}

    public Curve(string name, double?[] value) {
        Name = name;
        Value = value;
    }

    public bool hasNull() {
        foreach (double? v in Value) {
            if (v == null) {
                return true;
            }
        }
        
        return false;
    }
}