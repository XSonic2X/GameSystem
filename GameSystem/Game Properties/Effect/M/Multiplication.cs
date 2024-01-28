using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Умножение
    /// </summary>
    [Serializable]
    public class Multiplication : Mathematics
    {
        public Multiplication(Meaning m1, Meaning m2)
        {
            meaning1 = m1;
            meaning2 = m2;
        }

        public override Meaning Cloning()
        {
            return new Multiplication(meaning1.Cloning(), meaning2.Cloning());
        }

        public override int Get()
        {
            return meaning1.Get() * meaning2.Get();
        }
        public override string ToString()
        {
            return $"({meaning1}*{meaning2})";
        }

    }
}
