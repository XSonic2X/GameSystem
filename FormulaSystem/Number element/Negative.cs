namespace FormulaSystem.Number_element
{
    public class Negative : INumber
    {
        public Negative(INumber _number)
        {
            number = _number;
        }
        public INumber number;

        public double Get() => -number.Get();

        public override string ToString() => $"-{number}";

        public void Set(dynamic dynamic)
        {
            number.Set(dynamic);
        }
    }
}
