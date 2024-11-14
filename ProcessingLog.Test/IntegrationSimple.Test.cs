using IProcessingLog;
using ProcessingLog.Alg;

namespace ProcessingLog.Test
{
    [TestClass]
    public class IntegrationSimple
    {

        public double Power2(double x)
        {
            return x * x;
        }

        [TestMethod]
        public void Simple1()   // написать функцию делегат del
        {
            double[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var c1 = new Curve("C1", data);
            var ds_input = new Dataset(new Curve[] { c1 });
            var dss = new List<Dataset>{ ds_input };
            var parameters = new Parameter[] { new("P1", "10") };

            MultiplierFucntion del = Power2;

            Queue<IAlgorythm> sequence = new Queue<IAlgorythm>();

            sequence.Enqueue(new Doubler());
            sequence.Enqueue(new Multiplier(del));
            sequence.Enqueue(new Doubler());

            ProcessScheme processScheme = new ProcessScheme(sequence);

            var processor = new Processor(processScheme, dss, parameters, 
                                            new ChangeDetectorCurveSimple(), new ChangeDetectorParameterSimple());

            processor.Process();
            var res = processor.CurrentDatasets;
        }
    }
}