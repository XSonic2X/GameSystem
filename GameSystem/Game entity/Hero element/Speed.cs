using System;

namespace GameSystem.Game_entity.Hero_element
{
    public class Speed
    {
        public Speed(Skill skill) 
        {
            Max = 1;
            Current = 1;
            Negative = 0;
            skill.End += Update;
            Update(skill);
        }
        public int Max;
        public int Current
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
                if (Current > Max) { Current = Max; }
            }
        }
        public int Negative;
        public void Move(int a)
        {
            a += Negative;
            Current -= a;
        }
        public void Next()
        {
            Current += Max;
        }
        public void Reset()
        {
            Current = Max;
        }
        void Update(Skill skill)
        { 
            double b = Current/Max;
            Max = 6 + skill.Modifier();
            Current = (int)Math.Truncate(b * Max);
        }
        int s;
    }
}
