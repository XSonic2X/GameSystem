using FormulaSystem.Number_element;

namespace FormulaSystem.Dictionary_element
{
    public class DictiStaples : IDictionary
    {
        public DictiStaples()
        {
            key = "(";
        }
        public string key { get; set; }

        public INumber Create(IMathematics iMath)
        {
            INumber number = new Staples(iMath.Level1());
            if (iMath.txt == ")") { }
            else { throw new Exception(); }
            iMath.Next();
            return number;
        }
    }
}
