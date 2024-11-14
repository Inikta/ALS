namespace IProcessingLog
{

    public class Curve(string name, double[] value)
    {

        public string Name { get; private set; } = name;
        public double[] Value { get; private set; } = value;

        public bool HasNull()
        {
            foreach (double v in Value)
            {
                if (double.IsNaN(v))
                {
                    return true;
                }
            }

            return false;
        }
    }

}