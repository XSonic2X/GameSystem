using GameSystem.Game_Properties.Player;
using System;

/// <summary>
/// Принимает Characteristic и тип праметра characteristic
/// </summary>
/// <param name="characteristic"></param>
/// <param name="primary"></param>
public delegate void CharaEvent(Characteristic characteristic, bool primary);
namespace GameSystem.Game_Properties.Player
{
    /// <summary>
    /// Характеристика
    /// </summary>
    [Serializable]
    public class Characteristic
    {
        public Characteristic(TypeCharacteristic typeCharacteristic)
        {
            this.typeCharacteristic = typeCharacteristic;
        }
        public TypeCharacteristic typeCharacteristic;
        /// <summary>
        /// Characteristic event update завершение
        /// </summary>
        public event CharaEvent CEUpdateEnd;
        /// <summary>
        /// Characteristic event update начало
        /// </summary>
        public event CharaEvent CEUpdateStart;
        int V1 = 0, V2 = 0;
        /// <summary>
        /// Первичная
        /// </summary>
        public int primaryChar
        {
            get { return V1; }
            set
            {
                CEUpdateStart?.Invoke(this, true);
                V1 = value;
                CEUpdateEnd?.Invoke(this, true);
            }
        }
        /// <summary>
        /// Вторичная
        /// </summary>
        public int secondaryChar
        {
            get { return V2; }
            set
            {
                CEUpdateStart?.Invoke(this, false);
                V2 = value;
                CEUpdateEnd?.Invoke(this, false);
            }
        }
        /// <summary>
        /// Первичная+Вторичная
        /// </summary>
        public int All
        {
            get
            {
                int a = V1 + V2;
                if (a < 0) { return 0; }
                return a;
            }
        }
        public override string ToString()
        {
            if (secondaryChar > 0 || secondaryChar < 0) { return $"{GameString.CharToString(typeCharacteristic)}:{primaryChar}({secondaryChar})"; }
            return $"{GameString.CharToString(typeCharacteristic)}:{primaryChar}";
        }
    }
}
