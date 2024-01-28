using GameSystem.Game_Elements;
using GameSystem.Game_Properties;
using GameSystem.Game_Properties.Player;
using System;
using System.Collections.Generic;


namespace GameSystem.Game_Objects
{
    
    [Serializable]
    public class Player : Entity
    {
        public Player(Info info)
        { 
            this.info = info;
            Initialize();
            typeObjects = TypeObjects.player;
            Weight = 1;
        }
        
        public void EffectRem(Effect e)
        {
            effects.Remove(e);
            e.effectEnd -= EffectRem;
        }
        public override int Weight 
        {
            get => specifications.statistics.Weight;
            set => specifications.statistics.Weight = value;
        }
        public void Next()
        {
            foreach (Point p in specifications.points)
            {
                p.Regeneration();
            }
            specifications.statistics.RegenerationSpeed();
            //for (int i = 0; i < effects.Count; i++)
            //{
            //    effects[i].Next();
            //}
        }
        public string InfoEffect()
        {
            string txt = "";
            for (int i = 0;i< effects.Count;i++)
            {
                txt += $"{effects[i]}\r\n";
            }
            return txt;
        }

    }
}
