using System;

namespace GameSystem.Game_Properties.Player
{
    [Serializable]
    public class Specifications
    {
        public Specifications()
        {
            charS = new Characteristic[GameString.CharLength];
            int i;
            for (i = 0; i < charS.Length; i++)
            {
                charS[i] = new Characteristic((TypeCharacteristic)i);
            }
            points = new Point[GameString.PointLength];
            for (i = 0; i < points.Length; i++)
            {
                points[i] = new Point((TypePoints)i);
            }
            statistics = new Statistics(this);
            Characteristic C;
            C = GetChar(TypeCharacteristic.Physique);
            C.CEUpdateEnd += points[0].Update;
            points[0].balance = 0.9;
            C = GetChar(TypeCharacteristic.Intelligence);
            C.CEUpdateEnd += points[1].Update;
            points[1].balance = 2;
            for (i = 0; i < charS.Length; i++)
            {
                charS[i].primaryChar = 5;
            }
            skills = new Skills[GameString.SkillLength];
            for (i = 0;i <skills.Length;i++)
            {
                skills[i] = new Skills((TypeSkills)i);
            }
        }
        public Statistics statistics;
        public Point[] points;
        public Characteristic[] charS;
        public Skills[] skills;
        public Point GetPoint(TypePoints typePoints) => points[(int)typePoints];
        public Characteristic GetChar(TypeCharacteristic typeCharacteristic) => charS[(int)typeCharacteristic];
        public CharacteristicStatistics GetCharS(TypeCharacteristicStatistics typeCharacteristicStatistics) => statistics.charS[(int)typeCharacteristicStatistics];
    }
}
