using GameSystem.Game_entity.Hero_element;
using System.Collections.Generic;

namespace GameSystem.Game_item
{
    public class Weapon : Artifact
    {
        public Weapon() 
        {
            Initialize();
            typeDices = new List<TypeDice>();
        }
        public List<TypeDice> typeDices;
        public override void Use(Hero hero)
        {
            if (IsUsed)
            {
                IsUsed = !IsUsed;
                effect.Remove(hero);
                hero.weapons.Remove(this);
            }
            else
            {
                IsUsed = !IsUsed;
                effect.Add(hero);
                hero.weapons.Add(this);
            }
        }
        public int DPS()
        {
            if (typeDices.Count == 0) { return 0; }
            int dps = 0;
            for (int i = 0;i < typeDices.Count;i++ )
            {
                dps += Dice.Cast(typeDices[i]);
            }
            return dps;
        }
    }
}
