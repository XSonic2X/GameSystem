using System;

namespace GameSystem.Game_entity.Hero_element
{
    [Serializable]
    public class Point
    {
        protected Point()
        { }
        public Point(Skill skill, int addition, int multiplier)
        {
            poiMax = 100;
            Poin = 100;
            poiRegen = 1;
            skill.End += Update;
            this.addition = addition;
            this.multiplier = multiplier;
            Update(skill);
        }
        public int PoiMax
        {
            get 
            {
                return poiMax;
            }
        }
        public int Poin
        {
            get
            {
                return poin;
            }
            set
            {
                poin = value;
            }
        }
        public int Regen 
        {
            get { return poiRegen; }
            set { poiRegen = value; }
        }
        public void Next()
        {
            poin += poiRegen;
        }
        public void Reset()
        {
            poin = poiMax;
        }
        public override string ToString()
        {
            return $"{poiMax}/{poin} | Regen:{poiRegen}";
        }
        //==================================
        protected int poiMax;
        protected int poin;
        protected int poiRegen;
        protected double addition;
        protected double multiplier;
        protected virtual void Update(Skill skill)
        {
            double a = skill.values / 2d, p = poin / poiMax;
            poiMax = (int)Math.Truncate(addition + a * multiplier);
            poin = (int)Math.Truncate(p * poiMax);
        }
    }
    [Serializable]
    public class Point2: Point //переделать
    {
        public Point2(Skill skill1, Skill skill2, int addition, int multiplier)
        {
            poiMax = 100;
            Poin = 100;
            poiRegen = 1;
            skill1.End += Update;
            skill2.End += Update;
            this.addition = addition;
            this.multiplier = multiplier;
            Update(null);
        }
        public override string ToString()
        {
            return $"{poiMax}/{poin} | Regen:{poiRegen}";
        }
        protected override void Update(Skill skill)
        {
            double a = (skill1.values + skill2.values) / 2d, p = poin / poiMax;
            poiMax = (int)Math.Truncate(addition + a * multiplier);
            poin = (int)Math.Truncate(p * poiMax);
        }
        Skill skill1;
        Skill skill2;
    }
}
