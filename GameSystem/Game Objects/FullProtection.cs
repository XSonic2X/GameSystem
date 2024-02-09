using System;

namespace GameSystem.Game_Objects
{
    [Serializable]
    public class FullProtection : ProtectiveCover
    {
        public FullProtection(int HP, Entity e)
        { 
            this.HP = HP;
            e.modTakeDps += Hit;
        }
        public int HP = 0;
        public override void Hit(ref int a, Entity eDefender, Entity eStriker)
        {
            int b = HP - a;
            if (b > 0)
            {
                a = 0;
                HP = b;
                return;
            }
            a -= HP;
            HP = 0;
            eDefender.modTakeDps -= Hit;
        }
        public override string ToString()
        {
            return $"Прочность:{HP}";
        }
    }
}
