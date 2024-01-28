using System;

namespace GameSystem.Game_Properties
{
    /// <summary>
    /// Имя и описание об объекте или элементе
    /// </summary>
    [Serializable]
    public class Info
    {
        public Info()
        {
            Name = "No_Name";
            Description = "";
        }
        public Info(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
