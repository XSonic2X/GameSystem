using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Значение
    /// </summary>
    [Serializable]
    public abstract class Meaning
    {
        public abstract void InstallEvent(GAction gAction);
        public abstract void UninstallEvent(GAction gAction);
        public virtual ArrayA GetArrayA() { return null; }
        public abstract bool Validity();
        public abstract void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2);
        public abstract int Get();
        public abstract void Set(int num);
        public abstract Meaning Cloning();
        public override string ToString()
        {
            return "Test";
        }
    }
}
