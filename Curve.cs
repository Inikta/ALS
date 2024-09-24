public class Curve {
    public string Name{get; private set;}
    public double[] Value{get; private set;}

    public Curve(string name, double[] value=new double[0]) {
        Name = name;
        Value = value;
    }

    public bool hasNull() {
        //foreach ()
        return false;
    }
}