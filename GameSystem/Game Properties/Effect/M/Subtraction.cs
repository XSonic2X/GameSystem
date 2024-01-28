using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Вычитание
    /// </summary>
    [Serializable]
    public class Subtraction : Mathematics
    {
        public Subtraction(Meaning m1, Meaning m2)
        {
            meaning1 = m1;
            meaning2 = m2;
        }

        public override Meaning Cloning()
        {
            return new Subtraction(meaning1.Cloning(), meaning2.Cloning());
        }

        public override int Get()
        {
            return meaning1.Get() - meaning2.Get();
        }
        public override string ToString()
        {
            return $"({meaning1}-{meaning2})";
        }
    }
}
