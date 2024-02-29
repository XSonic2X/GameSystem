using GameSystem.Game_entity.Hero_element;
using System.Collections.Generic;

namespace GameSystem
{
    public delegate void EventBattle(Battle battle);
    public class Battle
    {
        public Battle()
        {
            heroes = new List<Hero>();
        }
        public List<Hero> heroes;
        public int MaxSpeed;

        public event EventBattle ChangingList;

        public void Add(Hero hero)
        {
            heroes.Add(hero);
            Sorting();
            ChangingList?.Invoke(this);
        }
        public void Remove(Hero hero)
        {
            heroes.Remove(hero);
            if (heroes.Count > 0) { MaxSpeed = heroes[0].speed.Current; }
            ChangingList?.Invoke(this);
        }

        /// <summary>
        /// Частичная сортировка первенства не учитавет 
        /// </summary>
        public void SortingMotion()
        {
            if (heroes.Count < 2) { return; }
            int e2 = 0;
            Hero hero;
            for (int e1 = 1; e1 < heroes.Count; e1++)
            {
                if (heroes[e1].speed.Current >= heroes[e2].speed.Current)
                {
                    hero = heroes[e1];
                    heroes[e1] = heroes[e2];
                    heroes[e2] = hero;
                    e2 = e1;
                }
                else
                {
                    break;
                }
            }
            MaxSpeed = heroes[0].speed.Current;
            ChangingList?.Invoke(this);
        }
        /// <summary>
        /// Полная сортировка
        /// </summary>
        public void Sorting()
        {
            if (heroes.Count < 2) { return; }
            Hero hero;
            for (int e1 = 0; e1 < heroes.Count; e1++)
            {
                for (int e2 = 0; e2 < heroes.Count; e2++)
                {
                    if (heroes[e2].speed.Current > heroes[e1].speed.Current)
                    {
                        hero = heroes[e1];
                        heroes[e1] = heroes[e2];
                        heroes[e2] = hero;
                    }
                }
            }
            MaxSpeed = heroes[0].speed.Current;
            ChangingList?.Invoke(this);
        }
    }
}
