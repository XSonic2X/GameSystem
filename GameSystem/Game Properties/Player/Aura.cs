using GameSystem.Game_Objects;
using System;
using System.Collections.Generic;

namespace GameSystem.Game_Properties.Player
{
    [Serializable]
    public class Aura
    {
        public Aura(Entity entity)
        { 
            this.entity = entity;
            List<Entity> entities = new List<Entity>();
            R = 0;
        }
        public int R;
        Entity entity;
        List<Entity> entities;
        public void Reset() => entities.Clear();
        public void WGetsInAura(Battle battle)
        {
            if (entities.Count > 0) { entities.Clear(); }
            if (R <= 0) { return; }
            for (int i = 0;i < battle.entities.Count;i++)
            {
                if (battle.entities[i] == entity) { continue; }
                if (Radius(battle.entities[i], entity) <= R) { entities.Add(battle.entities[i]); }
            }
        }
        int Radius(Entity e1, Entity e2) => (int)Math.Truncate(Math.Sqrt(Math.Pow(e1.X - e2.X, 2) + Math.Pow(e1.Y - e2.Y, 2)));
    }
}
