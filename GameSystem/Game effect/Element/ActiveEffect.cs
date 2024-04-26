using GameSystem.Game_effect.Game_mod.Game_states;
using GameSystem.Game_element;
using GameSystem.Game_hero;

namespace GameSystem.Game_effect.Element
{
    public class ActiveEffect(int duration, List<States> _states, Info info) : Effect(_states, info)
    {
        private void Tick(Hero hero)
        {
            duration--;
            if (duration > 0) { return; }
            hero.RemoveEffect(this);
        }


        protected override void ApplyEffect(Hero hero)
        {
            hero.E_Next += Tick;
        }

        protected override void ResetEffect(Hero hero)
        {
            hero.E_Next -= Tick;
        }

        public override string ToString() => $"{duration} <= {base.ToString()}";
    }
}
