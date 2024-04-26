using GameSystem.Game_effect.Element;
using GameSystem.Game_effect.Game_mod.Game_states;
using GameSystem.Game_element;

namespace GameSystem.Game_effect
{
    public class BuildEffect
    {
        public BuildEffect() 
        {
            states = [];
        }
        public List<States> states;

        public Effect Get(Info info)
        {
            return new PassiveEffect(states, info);
        }
        public Effect Get(Info info, int duration)
        {
            return new ActiveEffect(duration, states,info);
        }
    }
}
