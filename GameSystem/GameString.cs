namespace GameSystem
{
    public delegate void VoidEvent();
    public static class GameString
    {
        /// <summary>
        /// Список type objects
        /// </summary>
        static string[] TOString = new string[] 
        { 
            "Персонаж" ,
            "Барьер"
        };
        /// <summary>
        /// Название type objects по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string TypeOToString(int id) => TOString[id];
        /// <summary>
        /// Название type objects по enum TypeObjects
        /// </summary>
        /// <param name="typeObjects"></param>
        /// <returns></returns>
        public static string TypeOToString(TypeObjects typeObjects) => TypeOToString((int)typeObjects);
        
        static string[] stringsCharacteristic = new string[]
{
            "Сила",
            "Ловкость",
            "Телосложение",
            "Интеллект",
            "Мудрость",
            "Магическое Давление"
};
        public static int CharLength { get => stringsCharacteristic.Length; }
        public static string CharToString(int id) => stringsCharacteristic[id];
        public static string CharToString(TypeCharacteristic typeCharacteristic) => CharToString((int)typeCharacteristic);
        
        static string[] stringsPoints = new string[]
        {
            "ОЗ",
            "ОМ"
        };
        public static int PointLength { get => stringsPoints.Length; }
        public static string PointToString(int id) => stringsPoints[id];
        public static string PointToString(TypePoints typePoints) => PointToString((int)typePoints);

        static string[] stringsCharacteristicS = new string[]
        {
            "Аттака",
            "Защита"
        };
        public static int CharSLength { get => stringsCharacteristicS.Length; }
        public static string CharSToString(int id) => stringsCharacteristicS[id];
        public static string CharSToString(TypeCharacteristicStatistics typeCharacteristic) => CharSToString((int)typeCharacteristic);
        
        static string[] stringsSkill = new string[]
            {
                "Атлетика",
                "Акробатика",
                "Ловкость рук",
                "Скрытность",
                "История",
                "Магия",
                "Природа",
                "Расследование",
                "Религия",
                "Восприятие",
                "Выживание",
                "Медицина",
                "Проницательность",
                "Уход за животными",
                "Ремесло",
                "Выступление",
                "Запугивание",
                "Обман",
                "Убеждение",
                "Концентрация"
            };
        public static int SkillLength { get => stringsSkill.Length; }
        public static string SkillToString(int id) => stringsSkill[id];
        public static string SkillToString(TypeSkills typeSkills) => SkillToString((int)typeSkills);
        
    }
}
