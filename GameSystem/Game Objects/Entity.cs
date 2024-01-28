using GameSystem.Game_Elements;
using GameSystem.Game_Properties.Player;
using System;
using System.Collections.Generic;

namespace GameSystem.Game_Objects
{
    public delegate void GEventIEDES(int a, Entity eDefender, Entity eStriker);
    public delegate void GEventRIEDES(ref int a, Entity eDefender, Entity eStriker);
    [Serializable]
    public abstract class Entity : GObjects
    {
        public Specifications specifications;
        public List<Effect> effects;
        public int X = 0;
        public int Y = 0;
        protected void Initialize()
        {
            specifications = new Specifications();
            effects = new List<Effect>();
        }

        /// <summary>
        /// Получение домага
        /// </summary>
        public event GEventIEDES takeDamage;
        /// <summary>
        /// Нанисеный
        /// </summary>
        public event GEventIEDES damage;
        /// <summary>
        /// О количестве нанесеного урона Defender
        /// </summary>
        /// <param name="dps"></param>
        /// <param name="eDefender"></param>
        public void Damage(int dps, Entity eDefender) => damage?.Invoke(dps, eDefender, this);
        /// <summary>
        /// Изменение получение домага
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
            Dps -= specifications.statistics.Protection;
            if (Dps <= 0) { return 0; }
            specifications.points[0].point -= Dps;
            if (specifications.points[0].point < 0)
            {
                Dps += specifications.points[0].point;
                takeDamage?.Invoke(Dps, this, eStriker);
                eStriker.Damage(Dps, this);
                return Dps;
            }
            takeDamage?.Invoke(Dps, this, eStriker);
            eStriker.Damage(Dps, this);
            return 0;
        }

        /// <summary>
        /// Проверка на уклонение для Defender
        /// </summary>
        public event GEventRIEDES hitCheck;
        public void HitCheck(ref int a, Entity eStriker) => hitCheck?.Invoke(ref a, this, eStriker);
        /// <summary>
        /// Проверка на попадание для Striker
        /// </summary>
        public event GEventRIEDES hitCheckStriker;
        public void HitCheckStriker(ref int a, Entity eDefender) => hitCheckStriker?.Invoke(ref a, eDefender, this);
        public event GEventIEDES hitMiss;
        /// <summary>
        /// Если Striker промахнулся
        /// </summary>
        /// <param name="eDefender"></param>
        public void HitMiss(Entity eDefender) => hitMiss?.Invoke(0, eDefender, this);
        /// <summary>
        /// Если Defender увернулся
        /// </summary>
        public event GEventIEDES evadedE;
        /// <summary>
        /// Проверка на попадание для Striker
        /// </summary>
        /// <param name="eStriker"></param>
        /// <returns></returns>
        public virtual int HitCheck(Entity eStriker)
        {
            int eS = 0, eD = 0;
            HitCheck(ref eD, eStriker);
            eStriker.HitCheckStriker(ref eS, this);
            eD += (int)Math.Truncate((double)(specifications.GetChar(TypeCharacteristic.Dexterity).All / 2));
            eS += (int)Math.Truncate((double)(eStriker.specifications.GetChar(TypeCharacteristic.Dexterity).All / 2));
            eD += Dice.Cast(TypeDice.D12);
            eS += Dice.Cast(TypeDice.D12);
            if (eD > eS)
            {
                eStriker.HitCheck(this);
                evadedE?.Invoke(0, this, eStriker);
            }
            return eS - eD;
        }
    }
}
