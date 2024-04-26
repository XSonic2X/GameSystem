using GameSystem.Game_effect;
using GameSystem.Game_element;
using GameSystem.Game_hero;

namespace GameSystem.Game_skill
{
    public class Skill : Info
    {
        public Skill() 
        {

        }

        public BuildEffect buildEffect;

        public void Use(Hero hero)
        {
            Effect effect = buildEffect?.Get(this);
            if (effect != null) 
            {
                hero.AddEffect(effect);
            }
            buildEffect?.Get(this);
        }



    }
}
