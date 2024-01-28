using System;

namespace GameSystem.Game_Properties.Effect
{
    [Serializable]
    public abstract class Mathematics : Meaning
    {
        protected Meaning meaning1, meaning2;
        public override void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2)
        {
            meaning1.Update(effect, p1, p2);
            meaning2.Update(effect, p1, p2);
        }
        public override ArrayA GetArrayA()
        {
            ArrayA arrayA = meaning1.GetArrayA();
            if (arrayA == null) { return meaning2.GetArrayA(); }
            return arrayA;
        }
        public override void InstallEvent(GAction gAction)
        {
            meaning1.InstallEvent(gAction);
            meaning2.InstallEvent(gAction);
        }
        public override void UninstallEvent(GAction gAction)
        {
            meaning1.UninstallEvent(gAction);
            meaning2.UninstallEvent(gAction);
        }
        public override void Set(int num)
        {
        }
        public override bool Validity()
        {
            return meaning1.Validity() && meaning2.Validity();
        }
    }
}
