using GameSystem.Game_Properties.Player;
using System;

namespace GameSystem.Game_Objects
{
    [Serializable]
    public class PartialProtection : ProtectiveCover
    {
        public PartialProtection(int PCover, int CafeСenter, Entity e)
        {
            this.PCover = PCover;
            this.CafeСenter = CafeСenter;
            e.modTakeDps += Hit;
        }
        int PCover;
        int CafeСenter;
        public override void Hit(ref int a, Entity eDefender, Entity eStriker)
        {
            Point p = eDefender[TypePoints.MP];
            int c;
            if (p.point >= PCover)
            {
                p.point -= PCover;
                c = (int)Math.Truncate((double)PCover * (double)CafeСenter);
                a -= c;
                if (a < 0)
                {
                    a = 0;
                }
            } else if (p.point <= 0) { return; }
            c = (int)Math.Truncate((double)p.point * (double)CafeСenter);
            p.point = 0;
            a -= c;
            if (a < 0)
            {
                a = 0;
            }
        }
        public override string ToString()
        {
            return $"Защита:{PCover}*{CafeСenter}={(int)Math.Truncate((double)PCover * (double)CafeСenter)}";
        }
    }
}
