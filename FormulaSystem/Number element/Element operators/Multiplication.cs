namespace FormulaSystem.Number_element.Element_operators
{
    public class Multiplication : Operators
    {
        public Multiplication(INumber _number1, INumber _number2) : base(_number1, _number2) { }

        public override double Get() => number1.Get() * number2.Get();

        public override string ToString() => $"{number1}*{number2}";
    }
}
