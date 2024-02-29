using GameSystem.Game_effect;
using GameSystem.Game_item;
using GameSystem.Game_Properties;
using System;
using System.Collections.Generic;

namespace GameSystem.Game_entity.Hero_element
{
    public delegate void EventHero(Hero character);
    [Serializable]
    public class Hero : Entity
    {
        public Hero()
        {
            info = new Info();
            skills = new Skill[GameString.SkillLength];
            for (int i = 0; i < skills.Length; i++)
            {
                skills[i] = new Skill((TypeSkill)i);
            }
            characteristic = new Characteristic(this);
            HP = new Point(this[TypeSkill.Stamina], 50, 10);
            SP = new Point(this[TypeSkill.Stamina], 35, 5);
            Sanity = new Point2(this[TypeSkill.Imagination], this[TypeSkill.Logic],5,1);
            speed = new Speed(this[TypeSkill.Reaction]);
            changes  = new List<Change>();
            items = new List<Item>();
        }
        public Info info;
        /// <summary>
        /// Очки здоровья
        /// </summary>
        public Point HP;
        /// <summary>
        /// Очки выносливости
        /// </summary>
        public Point SP;
        /// <summary>
        /// Рассудок
        /// </summary>
        public Point Sanity;
        public Speed speed;
        /// <summary>
        /// Эффекты
        /// </summary>
        public List<Change> changes;
        public List<Item> items;
        public List<Weapon> weapons;
        //==================================
        public Characteristic characteristic;
        //==================================
        /// <summary>
        /// Атлетика
        /// </summary>
        public int Athletics
        {
            get
            {
                return this[TypeSkill.Power].values + this[TypeSkill.Motor].values;
            }
        }
        /// <summary>
        /// Интеллект
        /// </summary>
        public int Intelligence
        {
            get
            {
                return this[TypeSkill.Imagination].values + this[TypeSkill.Logic].values;
            }
        }
        /// <summary>
        /// Мудрость
        /// </summary>
        public int Wisdom
        {
            get
            {
                return
                    this[TypeSkill.Medicine].values +
                    this[TypeSkill.Survival].values +
                    this[TypeSkill.Insight].values +
                    this[TypeSkill.Training].values +
                    this[TypeSkill.Chemistry].values +
                    this[TypeSkill.History].values;
            }
        }
        /// <summary>
        /// Харизма
        /// </summary>
        public int Charisma
        {
            get
            {
                return
                    this[TypeSkill.Performance].values +
                    this[TypeSkill.Intimidation].values +
                    this[TypeSkill.Deception].values +
                    this[TypeSkill.Conviction].values;
            }
        }
        //==================================
        public event EventHero ECMove;
        public void Move()
        {
            speed.Move(0);
            ECMove?.Invoke(this);
        }
        public event EventHero ECNext;
        public override void Next()
        {
            if (HP.Poin > 0)
            {
                HP.Next();
                SP.Next();
                Sanity.Next();
                speed.Next();
                ECNext?.Invoke(this);
            }
        }
        public event EventHero ECRelax;
        public override void Relax()
        {
            ECRelax?.Invoke(this);
        }
        public event EventHero ECReset;
        public override void Reset()
        {
            HP.Reset();
            SP.Reset();
            Sanity.Reset();
            speed.Reset();
            ECReset?.Invoke(this);
        }
        public void AddItem(Item item)
        {
            items.Add(item);
            characteristic.Weight += item.Weight;
            item.CountChangeBegi += WeightChangeBegi;
            item.CountChangeEnd += WeightChangeEnd;
        }
        public Item RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                if (item.IsUsed) { item.Use(this); }
                characteristic.Weight -= item.Weight;
                item.CountChangeBegi -= WeightChangeBegi;
                item.CountChangeEnd -= WeightChangeEnd;
                return item;
            }
            return null;
        }
        public override void Invoke() => GameSystem.GetClass(this);
        //==================================
        public Skill[] skills;
        public Skill this[TypeSkill typeSkill]
        {
            get { return skills[(int)typeSkill]; }
        }
        //==================================
        public override string ToString() => info.ToString();

        void WeightChangeBegi(Item item)
        {
            characteristic.Weight -= item.Weight;
        }
        void WeightChangeEnd(Item item)
        {
            characteristic.Weight += item.Weight;
        }
    }
}
