using GameSystem.Game_Properties.Player;
using System;

public delegate void PointsEvent(Point points);
namespace GameSystem.Game_Properties.Player
{
    [Serializable]
    public class Point
    {
        public Point(TypePoints typePoints)
        {
            this.typePoints = typePoints;
        }
        public TypePoints typePoints;
        /// <summary>
        /// Для характеристик
        /// </summary>
        public int pointPrimaryMax
        {
            get => PPM;
            private set
            {
                ePointMaxStart?.Invoke(this);
                double a = (double)point / (double)pointMax;
                PPM = value;
                p = (int)Math.Truncate(a * pointMax);
                ePointMaxEnd?.Invoke(this);
            }
        }
        /// <summary>
        /// Для баффо
        /// </summary>
        public int pointSecondaryMax
        {
            get => PSM;
            set
            {
                ePointMaxStart?.Invoke(this);
                double a = (double)point / (double)pointMax;
                PSM = value;
                p = (int)Math.Truncate(a * pointMax);
                ePointMaxEnd?.Invoke(this);
            }
        }
        int PPM = 1,
            PSM;
        /// <summary>
        /// Максимальный
        /// </summary>
        public int pointMax { get { return pointPrimaryMax + pointSecondaryMax; } }
        /// <summary>
        /// Тикущий
        /// </summary>
        public int point
        {
            get => p;
            set
            {
                ePointStart?.Invoke(this);
                p = value;
                if (p > pointMax) { p = pointMax; }
                ePointEnd?.Invoke(this);
            }
        }
        int p = 1;
        /// <summary>
        /// Процент регенерации
        /// </summary>
        public double gain = 1; // Нужны события
        /// <summary>
        /// Регенерация
        /// </summary>
        public int regeneration = 0; // Нужны события
        public double balance;
        public void UpdatePointToMax()
        {
            point = pointMax;
        }
        public void Update(Characteristic characteristic, bool primary)
        {
            int a = (int)Math.Truncate(((double)characteristic.All) / balance);
            if (a <= 0) { a = 1; }
            pointPrimaryMax = a;
        }
        public void Regeneration()
        {
            if (regeneration <= 0 && gain <= 0 && point >= pointMax) { return; }
            point += (int)Math.Truncate(gain * regeneration);
        }
        public event PointsEvent ePointMaxStart;
        public event PointsEvent ePointMaxEnd;
        public event PointsEvent ePointStart;
        public event PointsEvent ePointEnd;
        public override string ToString()
        {
            return $"{GameString.PointToString(typePoints)}:{pointMax}/{point}";
        }
    }
}
