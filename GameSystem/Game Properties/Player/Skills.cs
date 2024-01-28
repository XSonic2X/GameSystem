using System;

namespace GameSystem.Game_Properties.Player
{
    [Serializable]
    public class Skills
    {
        public Skills(TypeSkills Sk)
        {
            this.Sk = Sk;
        }
        TypeSkills Sk;
        public int value = 0;
        public override string ToString()
        {
            return $"{GameString.SkillToString(Sk)}:{value}";
        }
    }
}
