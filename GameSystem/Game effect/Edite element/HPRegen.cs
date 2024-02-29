using GameSystem.Game_entity.Hero_element;

namespace GameSystem.Game_effect.Edite_element
{
    public class HPRegen : Edite
    {
        public HPRegen(int value)
        {
            this.value = value;
        }
        public override void Set(Hero hero) => hero.HP.Regen += value;
        public override void Unset(Hero hero) => hero.HP.Regen -= value;
        public override string ToString()
        {
            return $"Regen HP:{value}";
        }
    }
}
