using GameSystem.Game_hero;

namespace GameSystem.Game_effect.Game_mod.Game_states
{
    public abstract class States
    {
        public abstract void Apply(Hero hero);
        public abstract void Reset(Hero hero);
    }
}
