using GameSystem.Game_entity.Hero_element;
using GameSystem.Game_Properties;

namespace GameSystem.Game_item
{
    public class Trash : Item
    {
        public Trash() 
        {
            info = new Info();
            stack = true;
        }
        public override void Use(Hero hero)
        {
            
        }
        public override string ToString()
        {
            return $"{info} | {Count}";
        }
    }
}
