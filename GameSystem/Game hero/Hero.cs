using GameSystem.Game_effect;
using GameSystem.Game_element;

namespace GameSystem.Game_hero
{
    public delegate void EventHero(Hero hero);
    public class Hero : Info
    {
        public Hero() 
        {
            effects = [];
        }

        public event EventHero E_Next;

        //=========================

        public List<Effect> effects;

        public void AddEffect(Effect effect)
        { 
            effects.Add(effect);
            effect.Apply(this);
        }

        public void RemoveEffect(Effect effect) 
        {
            effects.Remove(effect);
            effect.Reset(this);
        }

        //=========================

        public void Next()
        {
            E_Next?.Invoke(this);
        }
    }
}
