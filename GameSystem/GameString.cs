namespace GameSystem
{
    static public class GameString
    {
        static public string ToString(TypeSkill TS) => SkillStr[(int)TS];
        static public int SkillLength
        {
            get { return SkillStr.Length; }
        }
        static string[] SkillStr = new string[]
        {
            //Атлетика
            "Сила",
            "Моторика", //Качества движение
            //Интеллект
            "Воображение",
            "Логика",
            //Мудрость
            "Медицина",
            "Выживание",
            "Проницательность",
            "Работа с животным",
            "Химия",
            "История",
            //Харизма
            "Выступление",
            "Запугивание",
            "Обман",
            "Убеждение",
            //Универсал
            "Выносливость",
            "Реакция"
        };
    }
}
