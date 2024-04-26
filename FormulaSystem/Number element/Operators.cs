namespace FormulaSystem.Number_element
{
    public abstract class Operators : INumber
    {
        public Operators(INumber _number1, INumber _number2)
        {
            number1 = _number1;
            number2 = _number2;
        }

        public INumber number1, number2;

        public abstract double Get();

        public void Set(dynamic dynamic)
        {
            number1.Set(dynamic);
            number2.Set(dynamic);
        }
    }
}
