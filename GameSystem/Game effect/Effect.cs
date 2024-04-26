using GameSystem.Game_effect.Game_mod.Game_states;
using GameSystem.Game_element;
using GameSystem.Game_hero;

namespace GameSystem.Game_effect
{
    public abstract class Effect
    {
        protected Effect(List<States> _states, Info _info)
        {
            enabled = false;
            info = _info;
            states = _states;
        }

        public Info info;
        public List<States> states;
        public bool enabled;

        /// <summary>
        /// Устаналиваевает все модификации
        /// </summary>
        /// <param name="hero"></param>
        public void Apply(Hero hero)
        {
            if (enabled) { return; }
            enabled = true;
            for (int i = 0; i < states.Count; i++)
            { states[i].Apply(hero); }
            ApplyEffect(hero);
        }
        /// <summary>
        /// Удаляет все модификации
        /// </summary>
        /// <param name="hero"></param>
        public void Reset(Hero hero)
        {
            if (enabled) 
            {
                enabled = false;
                for (int i = 0; i < states.Count; i++)
                { states[i].Reset(hero); }
                ResetEffect(hero); 
            }
        }
        protected abstract void ApplyEffect(Hero hero);
        protected abstract void ResetEffect(Hero hero);

        public override string ToString() => info == null ? "Null_Name" : info.ToString();
    }
}
