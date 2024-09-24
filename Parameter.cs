public class Parameter {
    private string Name{get; private set;};
    private string Value{get; private set;};

    public Parameter(string name, string value) {
        Name = name;
        Value = value;
    }
}