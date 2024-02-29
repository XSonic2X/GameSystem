using GameSystem.Game_entity.Hero_element;

namespace GameSystem.Game_item
{
    public class Armor : Artifact
    {
        public Armor() 
        {
            Initialize();
            def = 0;
        }
        public int def;
        public override void Use(Hero hero)
        {
            if (IsUsed)
            {
                IsUsed = !IsUsed;
                effect.Remove(hero);
                hero.characteristic.DEF -= def;
            }
            else
            {
                IsUsed = !IsUsed;
                effect.Add(hero);
                hero.characteristic.DEF += def;
            }
        }
    }
}
