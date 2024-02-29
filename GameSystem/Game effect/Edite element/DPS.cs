using GameSystem.Game_entity.Hero_element;

namespace GameSystem.Game_effect.Edite_element
{
    public class DPS : Edite
    {
        public DPS(int value)
        {
            this.value = value;
        }
        public override void Set(Hero hero) => hero.characteristic.DPS += value;
        public override void Unset(Hero hero) => hero.characteristic.DPS -= value;
        public override string ToString()
        {
            return $"Урон:{value}";
        }
    }
}
