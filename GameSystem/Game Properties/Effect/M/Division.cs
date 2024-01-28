using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Деление
    /// </summary>
    [Serializable]
    public class Division : Mathematics
    {
        public Division(Meaning m1, Meaning m2)
        {
            meaning1 = m1;
            meaning2 = m2;
        }

        public override Meaning Cloning()
        {
            return new Division(meaning1.Cloning(), meaning2.Cloning());
        }

        public override int Get()
        {
            return (int)Math.Truncate((double)meaning1.Get() / (double)meaning2.Get());
        }
        public override string ToString()
        {
            return $"({meaning1}/{meaning2})";
        }
    }
}
