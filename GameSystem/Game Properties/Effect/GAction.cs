using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Действие
    /// </summary>
    [Serializable]
    public abstract class GAction
    {
        public Meaning mod;
        public Meaning meaning;
        /// <summary>
        /// Включение автоматического обновление если это предусмотрено классом
        /// </summary>
        public bool AvtoUpdate = false;
        public abstract void End();
        public abstract void Use();
        public abstract void Unuse();
        public abstract GAction Cloning(Game_Elements.Effect effect, Game_Objects.Player p1, Game_Objects.Player p2);
    }
}
