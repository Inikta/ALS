namespace LinkageAlgorythm
{
    public class Parameter
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string Unit { get; private set; }
        public string Description { get; private set; }
        public double? Number { get; private set; }

        public Parameter(string name, string value, string unit = "", string description = "")
        {
            Name = name;
            Value = value;
        }
    }
}