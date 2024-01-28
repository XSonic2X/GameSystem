using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Значение
    /// </summary>
    [Serializable]
    public class MEffectLv : Meaning
    {
        public MEffectLv() 
        { }
        Game_Elements.Effect effect;
        public override int Get() => effect.level;
        public override void Set(int num) => effect.level = num;
        public override string ToString()
        {
            if (effect == null) { return "Ур.Эффект:-0"; }
            return $"Ур.Эффект:{effect.level}";
        }
        public override void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2)
        {
            this.effect = effect;
        }

        public override bool Validity()
        {
            return effect != null;
        }

        public override Meaning Cloning()
        {
            return new MEffectLv();
        }

        public override void InstallEvent(GAction gAction)
        {

        }

        public override void UninstallEvent(GAction gAction)
        {

        }
    }
}
