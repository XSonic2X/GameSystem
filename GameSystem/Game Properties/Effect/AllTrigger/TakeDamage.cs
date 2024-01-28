using GameSystem.Game_Objects;
using System;

namespace GameSystem.Game_Properties.Effect.AllTrigger
{
    [Serializable]
    public class TakeDamage : Trigger
    {
        public TakeDamage() { }
        TakeDamage(Entity e) 
        {
            e.takeDamage += triggger;
        }
        public ArrayA arrayA;
        void triggger(int dps, Entity eDefender, Entity eStriker)
        {
            arrayA.Set(dps);
            eventTrigger.Invoke();
        }
        public override Trigger Cloning(Entity e)
        {
            return new TakeDamage(e);
        }

        public override void End(Entity e)
        {
            e.takeDamage -= triggger;
        }
    }
}
