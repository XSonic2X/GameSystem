using GameSystem.Game_entity.Hero_element;

namespace GameSystem.Game_effect.Edite_element
{
    public class ESkill : Edite
    {
        public ESkill(TypeSkill typeSkill, int value)
        {
            this.typeSkill = typeSkill;
            this.value = value;
        }
        TypeSkill typeSkill;

        public override void Set(Hero hero) => hero[typeSkill].values += value;
        public override void Unset(Hero hero) => hero[typeSkill].values -= value;
        public override string ToString()
        {
            return GameString.ToString(typeSkill) + $":{value}";
        }
    }
}
