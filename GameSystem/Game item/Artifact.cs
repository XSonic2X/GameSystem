using GameSystem.Game_effect;
using GameSystem.Game_entity.Hero_element;
using GameSystem.Game_Properties;

namespace GameSystem.Game_item
{
    public class Artifact : Item
    {
        public Artifact() 
        {
            Initialize();
        }
        public Effect effect;

        public override void Use(Hero hero)
        {
            if (IsUsed)
            {
                IsUsed = !IsUsed;
                effect.Remove(hero);
            }
            else
            {
                IsUsed = !IsUsed;
                effect.Add(hero);
            }
        }
        public override string ToString()
        {
            if (IsUsed)
            {
                return "*" + info.ToString();
            }
            return info.ToString();
        }
        protected void Initialize()
        {
            info = new Info();
            effect = new Effect();
            effect.info = info;
            effect.time = -1;
        }
    }
}
