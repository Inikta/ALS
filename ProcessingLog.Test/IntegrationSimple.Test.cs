namespace ProcessingLog.Test
{
    [TestClass]
    public class IntegrationSimple
    {
        [TestMethod]
        public void Simple1()
        {
            double[] data= new double[] {1,2,3,4,5,6,7,8,9,10 };
            var c1 = new Curve("C1",data);
            var ds_input = new Dataset(new Curve[] { c1 });
            var dss=new Dataset[] { ds_input };
            var parameters = new Parameter[] {new Parameter("P1","10") };
            var processor = new Processor(dss, parameters);
            //Задать схему обработки
            processor.process();
            //Получить результата обработки
        }
    }
}