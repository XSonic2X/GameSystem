using GameSystem.Game_entity.Hero_element;

namespace GameSystem.Game_effect.Edite_element
{
    public class DEF : Edite
    {
        public DEF(int value)
        {
            this.value = value;
        }
        public override void Set(Hero hero) => hero.characteristic.DEF += value;
        public override void Unset(Hero hero) => hero.characteristic.DEF -= value;
        public override string ToString()
        {
            return $"Защита:{value}";
        }
    }
}
