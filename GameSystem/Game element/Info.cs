namespace GameSystem.Game_element
{
    public abstract class Info
    {
        protected Info(string _name = "No_name",string _description = "")
        {
            name = _name;
            description = _description;
        }
        public string name;
        public string description;
        public override string ToString() => name;
    }
}
