using FormulaSystem.Number_element;

namespace FormulaSystem.Dictionary_element
{
    public class DictiNegative : IDictionary
    {
        public DictiNegative()
        {
            key = "-";
        }
        public string key { get; set; }

        public INumber Create(IMathematics iMath)
        {
            return new Negative(iMath.Level2());
        }
    }
}
