using GameSystem.Game_Elements;
using GameSystem.Game_Properties.Player;
using System;
using System.Collections.Generic;

namespace GameSystem.Game_Objects
{
    public delegate void GEventRIEDES(ref int a, Entity eDefender, Entity eStriker);
    [Serializable]
    public abstract class Entity : GObjects
    {
        public Specifications specifications;
        public List<Effect> effects;
        public Aura aura;
        public int X = 0;
        public int Y = 0;
        public Characteristic this[TypeCharacteristic TC]
        {
            get
            {
                return specifications.GetChar(TC);
            }
        }
        public Point this[TypePoints TP]
        {
            get
            {
                return specifications.GetPoint(TP);
            }
        }
        public CharacteristicStatistics this[TypeCharacteristicStatistics TCS]
        {
            get
            {
                return specifications.GetCharS(TCS);
            }
        }
        public Skills this[TypeSkills TS]
        {
            get
            {
                return specifications.skills[(int)TS];
            }
        }
        protected void Initialize()
        {
            specifications = new Specifications();
            effects = new List<Effect>();
            aura = new Aura(this);
        }
        /// <summary>
        /// Изменение получение домага (Магический щит)
        /// </summary>
        public event GEventRIEDES modTakeDps;
        /// <summary>
        /// Получение урона и возвращяет остаток
        /// </summary>
        /// <param name="Dps"></param>
        /// <returns></returns>
        public virtual int ReceivingHitDamage(int Dps, Entity eStriker)
        {
            modTakeDps?.Invoke(ref Dps,this,eStriker);
            if (Dps <= 0) { return 0; }
            Dps -= specifications.statistics.Protection;
            if (Dps <= 0) { return 0; }
            Point p = this[TypePoints.HP];
            p.point -= Dps;
            if (p.point < 0)
            {
                Dps += p.point;
                return Dps;
            }
            return 0;
        }
        /// <summary>
        /// Проверка на попадание для Striker
        /// </summary>
        /// <param name="eStriker"></param>
        /// <returns></returns>
        public virtual int HitCheck(Entity eStriker)
        {
            int eS = 0, eD = 0;
            eD += (int)Math.Truncate((double)(this[TypeCharacteristic.Dexterity].All / 2));
            eS += (int)Math.Truncate((double)(eStriker[TypeCharacteristic.Dexterity].All / 2));
            eD += Dice.Cast(TypeDice.D12);
            eS += Dice.Cast(TypeDice.D12);
            return eS - eD;
        }
    }
}
