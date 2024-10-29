namespace ProcessingLog
{
    public class Dataset : ICloneable
    {

        public string Name { get; private set; }
        private Dictionary<string, Curve> CurvesByName { get; }
        public Dataset(Dictionary<string, Curve> curvesByName)
        {
            CurvesByName = curvesByName;
        }
        public Dataset(Curve[] curvesByName)
        {
            //CurvesByName = curvesByName;
        }

        public Curve getByName(string name = "")
        {
            if (CurvesByName.ContainsKey(name))
            {
                return CurvesByName[name];
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

        /*public Curve this[int i]{
            get{
                return null;
            }
            set{
                return CurvesByName.Count = i;
            }
        }*/

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