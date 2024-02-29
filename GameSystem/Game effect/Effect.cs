using GameSystem.Game_entity.Hero_element;
using GameSystem.Game_Properties;
using System;
using System.Collections.Generic;

namespace GameSystem.Game_effect
{
    [Serializable]
    public class Effect
    {
        public Effect() 
        {
            time = -1;
            edites = new List<Edite> ();
            changes = new List<Change>();
        }
        
        public Info info;
        public List<Edite> edites;
        public List<Change> changes;
        //==================================
        public int time;
        //==================================
        public void Add(Hero hero)
        {
            if (edites.Count == 0) { return; }
            Change change = new Change(hero, this);
            changes.Add(change);
            change.ECEnd += Remove;
        }
        public void Remove(Hero hero)
        {
            if (edites.Count == 0) { return; }
            for (int i = changes.Count - 1; i >= 0;i-- )
            {
                changes[i].End(changes[i].hero);
            }
        }
        void Remove(Change change)
        {
            changes.Remove(change);
            change.ECEnd -= Remove;
        }
    }
}
