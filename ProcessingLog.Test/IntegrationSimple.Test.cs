using IProcessingLog;
using ProcessingLog.Alg;

namespace ProcessingLog.Test
{
    [TestClass]
    public class IntegrationSimple
    {

        public double Square(double x)
        {
            return x * x;
        }

        [TestMethod]
        public void Simple1()   // написать функцию делегат del
        {
            double[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var c1 = new Curve("C1", data);
            var dataset = new Dataset(new Curve[] { c1 });
            var inputDatasets = new List<Dataset>{ dataset };
            var parameters = new Parameter[] { new("P1", "10") };

            double[] expectedData = { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };

            MultiplierFucntion function = Square;

            Queue<IAlgorythm> sequence = new Queue<IAlgorythm>();

            sequence.Enqueue(new Doubler());
            sequence.Enqueue(new Multiplier(function));
            sequence.Enqueue(new Doubler());

            ProcessScheme processScheme = new(sequence);

            var processor = new Processor(processScheme, inputDatasets, parameters, new ChangeDetectorCurveSimple(), new ChangeDetectorParameterSimple());

            processor.Process();
            var res = processor.CurrentDatasets;

            CollectionAssert.Equals(expectedData, res);
        }
    }
}