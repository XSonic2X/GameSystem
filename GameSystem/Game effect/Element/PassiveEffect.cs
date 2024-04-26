using GameSystem.Game_effect.Game_mod.Game_states;
using GameSystem.Game_element;
using GameSystem.Game_hero;

namespace GameSystem.Game_effect.Element
{
    public class PassiveEffect(List<States> _states, Info info) : Effect(_states, info)
    {
        protected override void ApplyEffect(Hero hero)
        {
            throw new NotImplementedException();
        }

        protected override void ResetEffect(Hero hero)
        {
            throw new NotImplementedException();
        }

    }
}
