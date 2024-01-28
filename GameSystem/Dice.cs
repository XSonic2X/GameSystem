using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    static public class Dice
    {
        static public Random random = new Random();
        static public string[] strings = new string[] { "D4", "D6", "D8", "D10", "D12", "D20", "D100" };
        static public int Cast(TypeDice typeDice)
        {
            switch (typeDice)
            {
                case TypeDice.D4: return random.Next(1, 4);
                case TypeDice.D6: return random.Next(1, 6);
                case TypeDice.D8: return random.Next(1, 8);
                case TypeDice.D10: return random.Next(1, 10);
                case TypeDice.D12: return random.Next(1, 12);
                case TypeDice.D20: return random.Next(1, 20);
                case TypeDice.D100: return random.Next(1, 100);
                default: return 0;
            }
        }
        static public string ToString(TypeDice typeDice) => strings[(int)typeDice];
    }
}
