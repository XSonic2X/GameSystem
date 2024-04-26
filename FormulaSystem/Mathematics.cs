using FormulaSystem.Dictionary_element;
using FormulaSystem.Number_element;
using FormulaSystem.Number_element.Element_operators;
using System.Text.RegularExpressions;

namespace FormulaSystem
{
    public class Mathematics : IMathematics
    {
        public Mathematics()
        {
            dictionaries.Add(new DictiNegative());
            dictionaries.Add(new DictiStaples());
        }

        public string formula;
        static public readonly string offset = @"\[(.*?)\]|[0-9]*\.?[0-9]+([0-9]+)?|[()+*-/]";
        public string txt { get => _txt; set => _txt = value; }
        private string _txt;
        private int index;
        public List<IDictionary> dictionaries = new List<IDictionary>();
        private MatchCollection matches;

        public INumber GetNumber(string txt)
        {
            formula = txt;
            Regex regex = new Regex(offset);
            matches = regex.Matches(formula);
            index = 0;
            return Level1();
        }
        public INumber Operators(INumber number)
        {
            return _txt switch
            {
                "-" => new Subtraction(number, Level1()),
                "+" => new Addition(number, Level1()),
                "/" => new Division(number, Level1()),
                "*" => new Multiplication(number, Level1()),
                _ => number
            };
        }
        public INumber CreateNumber()
        {
            try
            {
                INumber number = new Number(Convert.ToDouble(_txt));
                Next();
                return number;
            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public INumber Level1()
        {
            INumber number = Level2();
            if (number == null) { return null; }
            return Operators(number);
        }
        public INumber Level2()
        {
            Next();
            if (_txt == null) { return null; }
            for (int i = 0; i < dictionaries.Count; i++)
            {
                if (_txt == dictionaries[i].key)
                {
                    return dictionaries[i].Create(this);
                }
            }
            return CreateNumber();
        }
        public void Next()
        {
            if (index < matches.Count)
            {
                _txt = matches[index].Value;
            }
            else
            {
                _txt = null;
            }
            index++;
        }

    }
}
