using System;

namespace GameSystem.Game_entity.Hero_element
{
    public delegate void EventSkill(Skill skill);
    [Serializable]
    public class Skill
    {
        public Skill(TypeSkill typeSkill)
        {
            this.typeSkill = typeSkill;
            v = 0;
        }
        public TypeSkill typeSkill;

        public event EventSkill Begi;
        public event EventSkill End;
        public int values
        {
            get
            {
                return v;
            }
            set
            {
                Begi?.Invoke(this);
                v = value;
                End?.Invoke(this);
            }
        }
        int v;
        /// <summary>
        /// Проверка модификатора
        /// </summary>
        /// <returns></returns>
        public int Modifier()
        {
            if (v <= 0) { return -5; }
            return (int)Math.Truncate((double)v / 2) - 5;
        }
        public override string ToString() => $"{GameString.ToString(typeSkill)}:{v}";
    }
}
