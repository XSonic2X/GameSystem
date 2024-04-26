namespace FormulaSystem.Number_element
{
    public class Staples : INumber
    {
        public Staples(INumber _number)
        {
            number = _number;
        }
        public INumber number;

        public double Get() => number.Get();

        public override string ToString() => $"({number})";

        public void Set(dynamic dynamic)
        {
            number.Set(dynamic);
        }
    }
}
