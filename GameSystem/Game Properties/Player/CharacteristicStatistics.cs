
using GameSystem.Game_Properties.Player;
using System;

public delegate void CharaSEvent(CharacteristicStatistics characteristic, bool primary);
namespace GameSystem.Game_Properties.Player
{
    [Serializable]
    public class CharacteristicStatistics
    {
        public CharacteristicStatistics(TypeCharacteristicStatistics typeCharacteristicS)
        {
            this.typeCharacteristicS = typeCharacteristicS;
        }
        public TypeCharacteristicStatistics typeCharacteristicS;
        /// <summary>
        /// CharacteristicStatistics event update завершение
        /// </summary>
        public event CharaSEvent CSEUpdateEnd;
        /// <summary>
        /// CharacteristicStatistics event update начало
        /// </summary>
        public event CharaSEvent CSEUpdateStart;
        int V1 = 0, V2 = 0;
        /// <summary>
        /// Первичная
        /// </summary>
        public int primaryChar
        {
            get { return V1; }
            set
            {
                CSEUpdateStart?.Invoke(this, true);
                V1 = value;
                CSEUpdateEnd?.Invoke(this, true);
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
                CSEUpdateStart?.Invoke(this, false);
                V2 = value;
                CSEUpdateEnd?.Invoke(this, false);
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
            if (secondaryChar > 0 || secondaryChar < 0) { return $"{GameString.CharSToString(typeCharacteristicS)}:{primaryChar}({secondaryChar})"; }
            return $"{GameString.CharSToString(typeCharacteristicS)}:{primaryChar}";
        }
    }
}
