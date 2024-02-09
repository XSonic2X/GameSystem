using System;

namespace GameSystem.Game_Objects
{
    [Serializable]
    public abstract class ProtectiveCover
    {
        public abstract void Hit(ref int a, Entity eDefender, Entity eStriker);
        public void End(Entity eDefender)
        {
            eDefender.modTakeDps -= Hit;
        }
    }
}
