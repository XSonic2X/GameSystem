using GameSystem.Game_entity.Hero_element;

namespace GameSystem.Game_effect
{
    public abstract class Edite
    {
        protected int value;
        public abstract void Set(Hero hero);
        public abstract void Unset(Hero hero);
    }
}
