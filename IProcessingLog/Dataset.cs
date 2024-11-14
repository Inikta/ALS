using System.Linq;

namespace IProcessingLog
{
    public class Dataset : ICloneable
    {

        public string Name { get; private set; }
        public Dictionary<string, Curve> CurvesByName { get; private set; }

        public Dataset(Curve[] curvesByName, string name = "")
        {
            CurvesByName = curvesByName.ToDictionary(c => c.Name, c => c);
            Name = name;
        }
        public Dataset(Dictionary<string, Curve> curvesByName, string name = "")
        {
            CurvesByName = curvesByName;
            Name = name;
        }

        public Curve GetByName(string name = "")
        {
            if (CurvesByName.TryGetValue(name, out Curve? value))
            {
                return value;
            }

            return null;
        }

        public Curve this[string namecurve]
        {
            get
            {
                return null;
            }
            set
            {
                if (CurvesByName.ContainsKey(namecurve))
                {
                    CurvesByName[namecurve] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return CurvesByName.Count;
            }
        }

        public object Clone() { return new Dataset(CurvesByName); }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is Dataset dataset) return Name == dataset.Name;

            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}