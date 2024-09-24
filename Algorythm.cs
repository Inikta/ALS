public interface Algorythm {
    private ArrayList<Curve> Curves{get; private set;};
    private ArrayList<Parameter> ParametersList{get; private set;}

    public Algorythm(Dataset dataset, ArrayList<Parameter> parametersList) {
        Dataset = dataset;
        ParametersList = parametersList;
    }

    public Data process(Dataset dataset, ArrayList<Parameter> parametersList) {
        //algorythm
        return new Data();
    }
}