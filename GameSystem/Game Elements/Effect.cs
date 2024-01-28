using GameSystem.Game_Objects;
using GameSystem.Game_Properties;
using GameSystem.Game_Properties.Effect;
using System;

namespace GameSystem.Game_Elements
{
    public delegate void EffectEvent(Effect effect);
    [Serializable]
    public abstract class Effect
    {
        public Info info;
        public int level;
        public event EffectEvent effectEnd;
        public Trigger trigger;
        
        public abstract void End();
        public abstract Effect Cloning(Player p1, Player p2);
    }
}
