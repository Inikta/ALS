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
    public class DoublerTests
    {
        [TestMethod]
        public void Simple()
        {
            double[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var c1 = new Curve("C1", data);
            var curveArr = new Curve[] { c1 };

            IndexRange inputChanges = new IndexRange();
            inputChanges.Range.Add((2, 5));

            var ds_input = new Dataset(new Curve[] { c1 });
            var dss = new Dataset[] { ds_input };
            var parameters = new Parameter[] { new("P1", "10") };

            double[] outData = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            var o1 = new Curve("o1", outData);
            var outCurveArr = new Curve[] { o1 };

            double[] expectedData = [0, 0, 3, 4, 5, 6, 0, 0, 0, 0];

            Doubler doubler = new();
            doubler.Process(curveArr, inputChanges, parameters, new (string, bool)[parameters.Length], outCurveArr, new IndexRange()); //также сравнить interv_idx (класс)
            var ans = doubler.ChangedCurves;

            CollectionAssert.AreEqual(ans[0].Value, expectedData); //коллекции и интервалы сравнить
        }

        [TestMethod]
        public void Simple3()
        {
            double[] data1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            double[] data2 = [0, 12, 4, 4, double.NaN, 6, 7, -5, 93, 110];
            double[] data3 = [double.NaN, 2, double.NaN, double.NaN, 5, 6, double.NaN, 8, 9, double.NaN];
            var c1 = new Curve("C1", data1);
            var c2 = new Curve("C2", data1);
            var c3 = new Curve("C3", data1);

            var curveArr = new Curve[] { c1, c2, c3 };
            IndexRange inputChanges = new IndexRange();
            inputChanges.Range.Add((2, 5));
            inputChanges.Range.Add((0, -1));
            inputChanges.Range.Add((3, 9));

            var ds_input = new Dataset(new Curve[] { c1 });
            var dss = new Dataset[] { ds_input };
            var parameters = new Parameter[] { new("P1", "10") };

            double[] outData1 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            double[] outData2 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            double[] outData3 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            var o1 = new Curve("o1", outData1);
            var o2 = new Curve("o2", outData2);
            var o3 = new Curve("o3", outData3);
            var outCurveArr = new Curve[] { o1, o2, o3 };

            double[][] expectedData = [ [0, 0, 3, 4, 5, 6, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 5, 6, double.NaN, 8, 9, double.NaN]];

            Doubler doubler = new();
            doubler.Process(curveArr, inputChanges, parameters, new (string, bool)[parameters.Length], outCurveArr, new IndexRange());
            var ans = doubler.ChangedCurves;

            CollectionAssert.AreEqual(ans[0].Value, expectedData[0]);
            CollectionAssert.AreEqual(ans[1].Value, expectedData[1]);
            CollectionAssert.AreEqual(ans[2].Value, expectedData[2]);
        }
    }
}
