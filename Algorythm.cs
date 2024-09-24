public interface Algorythm {
    private ArrayList<Curve> Curves{get; private set;};
    private ArrayList<Parameter> ParametersList{get; private set;}

    public Algorythm(ArrayList<Curve> curves, ArrayList<Parameter> parametersList) {
        Curves = curves;
        ParametersList = parametersList;
    }

    public ArrayList<Data> process(ArrayList<Curve> curves, ArrayList<Parameter> parametersList) {
        
        //some complex data processing

        return new ArrayList<Data>;
    }
}