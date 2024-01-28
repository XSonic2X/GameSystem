using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Число
    /// </summary>
    [Serializable]
    public class Number : Meaning
    {
        public Number(int num) => Num = num;
        protected int Num;
        public override int Get() => Num;
        public override void Set(int num) => Num=num;
        public override string ToString() => $"Number:{Num}";
        public override void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2)
        { }
        public override bool Validity()
        {
            return true;
        }
        public override Meaning Cloning()
        {
            return new Number(Num);
        }
        public override void InstallEvent(GAction gAction)
        {

        }

        public override void UninstallEvent(GAction gAction)
        {

        }
    }
}
