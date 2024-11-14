using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IProcessingLog;

namespace ProcessingLog.Test
{
    [TestClass]
    public class MultiplierTests
    {
        [TestMethod]
        public void Simple1()
        {
            double[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var c1 = new Curve("C1", data);
            var ds_input = new Dataset(new Curve[] { c1 });
            var dss = new Dataset[] { ds_input };
            var parameters = new Parameter[] { new("P1", "10") };

            //var processor = new Processor(dss, parameters);

            //Задать схему обработки
            //processor.Process();
            //Получить результата обработки
        }
    }
}
