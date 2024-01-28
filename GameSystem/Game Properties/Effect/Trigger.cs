using GameSystem.Game_Objects;
using System;

namespace GameSystem.Game_Properties.Effect
{
    [Serializable]
    public abstract class Trigger
    {
        public VoidEvent eventTrigger;
        public GAction gAction;
        public abstract Trigger Cloning(Entity e);
        public abstract void End(Entity e);
    }
}
