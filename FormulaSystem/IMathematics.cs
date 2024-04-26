namespace FormulaSystem
{
    public interface IMathematics
    {
        string txt { get; set; }
        INumber Level1();
        INumber Level2();
        void Next();
    }
}
