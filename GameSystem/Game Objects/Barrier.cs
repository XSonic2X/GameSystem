using System;

namespace GameSystem.Game_Objects
{
    [Serializable]
    public class Barrier : Entity
    {
        public int HP = 0;
        //public override int GettingHit(int Dps, Battle battle)
        //{
        //    HP -= Dps;
        //    if (HP < 0) { return HP; }
        //    return 0;
        //}
        public override string ToString()
        {
            return $"{GameString.TypeOToString(typeObjects)}:{HP}";
        }
    }
}
