namespace FormulaSystem
{
    public interface IDictionary
    {
        string key { get; set; }
        INumber Create(IMathematics iMath);
    }
}
