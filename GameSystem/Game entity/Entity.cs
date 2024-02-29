using System;

namespace GameSystem.Game_entity
{
    [Serializable]
    public abstract class Entity
    {
        public abstract void Invoke();
        public abstract void Next();
        public abstract void Reset();
        public abstract void Relax();
        public override string ToString()
        {
            return "Entity";
        }
    }
}
