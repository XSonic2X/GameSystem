using System;

namespace GameSystem.Game_Properties.Player
{
    [Serializable]
    public class Statistics
    {
        public Statistics(Specifications s)
        {
            charS = new CharacteristicStatistics[GameString.CharSLength];
            for (int i = 0;i < charS.Length;i++ )
            {
                charS[i] = new CharacteristicStatistics((TypeCharacteristicStatistics)i);
            }
            Characteristic C;
            C = s.GetChar(TypeCharacteristic.Physique);
            C.CEUpdateEnd += UpdateSpeedRecovery;
            C = s.GetChar(TypeCharacteristic.Power);
            C.CEUpdateEnd += UpdateDamag;
            C = s.GetChar(TypeCharacteristic.Dexterity);
            C.CEUpdateEnd += UpdateSpeed;
        }
        public CharacteristicStatistics[] charS;
        public int Damag { get => charS[0].All; }
        void UpdateDamag(Characteristic characteristic, bool primary)
        {
            int a = (int)Math.Truncate(((double)characteristic.All) / 2);
            if (a <= 0) { a = 1; }
            charS[0].primaryChar = a;
            a = (int)Math.Truncate(((double)characteristic.All) / 5);
            if (a <= 0) { a = 1; }
            liftingForce = a;
        }
        public int Protection { get => charS[1].All; }
        public int Weight
        {
            get => currentWeight;
            set
            {
                currentWeight = value;
                negativeSpeed = (int)Math.Truncate((double)currentWeight / 10) - liftingForce;
                if (negativeSpeed <= 0)
                { negativeSpeed = 1; }
            }
        }
        int currentWeight = 0,//Тикущий вес
            liftingForce = 0,//Подъемная сила
            maxSpeed = 0;
        public int MaxSpeed
        {
            get
            {
                if (maxSpeed > negativeSpeed) { return maxSpeed; }
                else { return negativeSpeed; }
            }
        }
        /// <summary>
        /// Негативная скорость на движение
        /// </summary>
        public int negativeSpeed = 1;
        /// <summary>
        /// Восстоновление скорости
        /// </summary>
        public int RecoverySpeed = 0;
        /// <summary>
        /// Текущая скорость
        /// </summary>
        public int CurrentSpeed = 0;
        public void RegenerationSpeed()
        {
            if (CurrentSpeed < MaxSpeed) { CurrentSpeed += RecoverySpeed; }
        }
        void UpdateSpeed(Characteristic characteristic, bool primary)
        {
            int a = (int)Math.Truncate(((double)characteristic.All) / 2);
            if (a <= 0) { a = 1; }
            maxSpeed = a;

        }
        void UpdateSpeedRecovery(Characteristic characteristic, bool primary)
        {
            int a = (int)Math.Truncate(((double)characteristic.All) / 3);
            if (a <= 0) { a = 1; }
            RecoverySpeed = a;
        }
    }
}
