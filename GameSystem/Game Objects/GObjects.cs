using GameSystem.Game_Properties;
using System;

namespace GameSystem.Game_Objects
{
    [Serializable]
    public abstract class GObjects
    {
        public Info info;
        public TypeObjects typeObjects;
        /// <summary>
        /// Вес объекта
        /// </summary>
        public virtual int Weight { get; set; } = 0;
        public override string ToString()
        {
            return $"{GameString.TypeOToString(typeObjects)}:{info}";
        }
    }
}
