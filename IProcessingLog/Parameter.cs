namespace IProcessingLog
{
    public class Parameter : ICloneable
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string Unit { get; private set; }
        public string Description { get; private set; }
        public double? NumberDouble { get; private set; }
        public int? NumberInt { get; private set; }

        public Parameter(string name, string value, string unit = "", string description = "")
        {
            Name = name;
            Value = value;
            Unit = unit;
            Description = description;
            NumberFromValue();
        }

        public void NumberFromValue() 
        {
            if (int.TryParse(Value, out int i))
            {
                NumberInt = int.Parse(Value);
            }

            if (double.TryParse(Value, out double d))
            {
                NumberDouble = double.Parse(Value);
            } 
        } // number = double or int(for flags) or null

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is Parameter parameter &&
                   String.Equals(this.Name, parameter.Name, StringComparison.OrdinalIgnoreCase) &&
                   String.Equals(this.Value, parameter.Value);
        }
    }
}