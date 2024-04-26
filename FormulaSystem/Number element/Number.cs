namespace FormulaSystem.Number_element
{
    public class Number : INumber
    {
        public Number(double _values) => values = _values;


        public double values;

        public double Get() => values;

        public override string ToString() => values.ToString();

        public void Set(dynamic dynamic)
        {

        }
    }
}
