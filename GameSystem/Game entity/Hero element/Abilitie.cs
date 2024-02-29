using GameSystem.Game_effect;
using GameSystem.Game_Properties;

namespace GameSystem.Game_entity.Hero_element
{
    public class Abilitie
    {
        public Abilitie() 
        {
            info = new Info();
            effect = new Effect();
            effect.info = info;
        }
        public Info info;
        public Effect effect;
        public int time
        {
            get { return effect.time; }
            set { effect.time = value; }
        }
        public int
            HP = 0,
            SP = 0,
            Sanity = 0,
            Speed = 0;
        public int DPS = 0;
        public int Healing = 0;
        public void Spend(Hero hero)
        {
            hero.HP.Poin -= HP;
            hero.SP.Poin -= SP;
            hero.Sanity.Poin -= Sanity;
            hero.speed.Current -= Speed;
        }
        public void Use(Hero hero)
        {
            effect.Add(hero);
        }
        public override string ToString()
        {
            return info.ToString();
        }
    }
}
