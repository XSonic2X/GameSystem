using GameSystem.Game_entity.Hero_element;
using System;

namespace GameSystem.Game_effect
{
    public delegate void EventChange(Change change);
    [Serializable]
    public class Change
    {
        public Change(Hero hero, Effect effect)
        { 
            this.hero = hero;
            this.effect = effect;
            time = effect.time;
            timeEnabled = time >= 0;
            if (timeEnabled) { hero.ECNext += Next; }
            for (int i = 0; i < effect.edites.Count; i++)
            {
                effect.edites[i].Set(hero);
            }
            hero.changes.Add(this);
        }
        public Hero hero;
        public event EventChange ECEnd;
        //==================================
        public bool timeEnabled;
        public int time;
        //==================================
        public void Next(Hero hero)
        {
            time--;
            if (time <= 0) { End(hero); }
        }
        public void End(Hero hero)
        {
            for (int i = 0;i < effect.edites.Count;i++)
            {
                effect.edites[i].Unset(hero);
            }
            if (timeEnabled) { hero.ECNext -= Next; }
            hero.changes.Remove(this);
            ECEnd?.Invoke(this);
        }
        public override string ToString()
        {
            if (timeEnabled)
            { return $"{time} | {effect.info}"; }
            return $"{effect.info}";
        }
        //==================================
        Effect effect;
    }
}