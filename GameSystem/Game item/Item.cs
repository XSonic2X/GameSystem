using GameSystem.Game_entity.Hero_element;
using GameSystem.Game_Properties;

namespace GameSystem.Game_item
{
    public delegate void EventItem(Item item);
    public abstract class Item
    {
        public Info info;
        /// <summary>
        /// Количество
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (stack) 
                {
                    CountChangeBegi?.Invoke(this);
                    count = value;
                    CountChangeEnd?.Invoke(this);
                }
            }
        }
        public int Weight
        {
            get
            {
                if (stack)
                {
                    return weight * count;
                }
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        /// <summary>
        /// Стакается
        /// </summary>
        public bool stack = false;
        public bool IsUsed = false;
        public event EventItem CountChangeBegi;
        public event EventItem CountChangeEnd;
        public abstract void Use(Hero hero);

        int count = 1;
        int weight = 0;
        public override string ToString()
        {
            return info.ToString();
        }
    }
}
