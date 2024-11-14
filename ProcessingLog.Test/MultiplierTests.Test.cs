using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IProcessingLog;
using ProcessingLog.Alg;

namespace ProcessingLog.Test
{
    [TestClass]
    public class MultiplierTests
    {
        public static double Sqare(double x)
        {
            return x * x;
        }

        [TestMethod]
        public void Simple1()
        {
            double[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var c1 = new Curve("C1", data);
            var dataset = new Dataset(new Curve[] { c1 });
            var inputDatasets = new List<Dataset> { dataset };
            var parameters = new Parameter[] { new("P1", "10") };

            double[] expectedData = { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };

            MultiplierFucntion function = Sqare;

            
        }
    }
}
