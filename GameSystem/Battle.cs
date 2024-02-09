using GameSystem.Game_Objects;
using System;
using System.Collections.Generic;

namespace GameSystem
{
    public delegate void EventBattle(Battle battle);
    [Serializable]
    public class Battle
    {
        public Battle()
        {
            entities = new List<Entity>();
        }
        public List<Entity> entities;
        event EventBattle EB;
        public void Add (Entity entity) 
        {
            entities.Add(entity);
            EB += entity.aura.WGetsInAura;
            EB.Invoke(this);
        }
        public void Remove (Entity entity) 
        {
            if (entities.Remove(entity))
            {
                EB -= entity.aura.WGetsInAura;
            }
        }
        public void UpDateAura() => EB.Invoke(this);
    }
}
