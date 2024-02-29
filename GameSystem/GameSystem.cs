using GameSystem.Game_entity.Hero_element;

namespace GameSystem
{
    public delegate void Log(string log);
    static public class GameSystem
    {
        static public event Log logE;
        static public void Log(string log) => logE?.Invoke(log);
        static public void GetClass(Hero h) => hero?.Invoke(h);
        static public event EventHero hero;
    }
}
