using System;

namespace GameSystem.Game_entity.Hero_element
{
    public class Characteristic
    {
        public Characteristic(Hero hero)
        {
            Skill skill = hero[TypeSkill.Power];
            skill.End += UpdateForce;
            skill.End += UpdateWeightMax;
            UpdateForce(skill);
            UpdateWeightMax(skill);
            skill = hero[TypeSkill.Imagination];
            skill.End += UpdateResistance;
            UpdateResistance(skill);
            skill = hero[TypeSkill.Logic];
            skill.End += UpdatePowerCaste;
            UpdatePowerCaste(skill);
        }
        /// <summary>
        /// Сила удара
        /// </summary>
        public int DPS { get; private set; } = 0;

        public int DEF = 0;
        
        public int PowerCaste { get; private set; } = 0;
        
        public int Saturation = 0; // Уровень насыщение(это для выносливости прибавка к востанове после одыха)
        public int Mood = 0; //Настроение
        public int WeightMax = 0;
        public int Weight = 0;//Вес
        int def = 0;
        void UpdatePowerCaste(Skill skill)
        {
            PowerCaste = 6 + skill.Modifier();
            if (PowerCaste < 0) { PowerCaste = 0; }
        }
        void UpdateResistance(Skill skill)
        {
            DEF -= def;
            def = (int)Math.Truncate(skill.values* 1.2);
            DEF += def;
        }
        void UpdateForce(Skill skill)
        {
            DPS = 6 + skill.Modifier();
            if (DPS < 0) { DPS = 0; }
        }
        void UpdateWeightMax(Skill skill)
        {
            WeightMax = skill.values * 10;
        }
    }
}
