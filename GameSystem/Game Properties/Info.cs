using System;

namespace GameSystem.Game_Properties
{
    [Serializable]
    /// <summary>
    /// Имя и описание
    /// </summary>
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
