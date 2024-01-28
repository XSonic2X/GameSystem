using GameSystem.Game_Properties;
using GameSystem.Game_Properties.Effect;
using System;

namespace GameSystem.Game_Assembler
{
    public static class GAssembler
    {
        static string txt;
        static int n = 0;
        public static string CreateEffect(string txtEffect)
        {
            n = 0;
            txt = txtEffect.ToLower();
            Info info = GetInfo();
            return "";
        }
        static Info GetInfo()
        {
            string name, description;
            name = GetString("имя");
            description = GetString("описание");
            return new Info(name, description);
        }
        //static ActivationEvent GetActivationEvent()
        //{
        //    switch (GetString("cобытие"))
        //    {
        //        case "без":
        //            break;
        //        default: break;
        //    }
        //    return null;
        //}
        //static ActivationEvent CreateActivationEvent()
        //{
        //    GAction[] gAction = new GAction[Convert.ToInt32(GetString("размер"))];
        //    bool avtoUpdate = false;
        //    int a = n;
        //    string txt = Parsing('.');
        //    if (txt == "авто")
        //    {
        //        txt = Parsing(';');
        //        if (txt == "вкыл") { avtoUpdate = true; }
        //        else if (txt == "выкл") { }
        //        else { throw new Exception("Ошибка на " + n); }
        //    }
        //    else { n = a; }
        //    for (int i = 0; i < gAction.Length; i++)
        //    {
        //        gAction[i] = CreateAction();
        //        gAction[i].AvtoUpdate = avtoUpdate;
        //    }
        //    return null;
        //}
        static GAction CreateAction()
        {
            //GAction gAction = new GAction();
            Meaning mod;
            return null;
        }
        static Meaning CreateMeaning()
        {
            int n = 0;
            string txt = Parsing(';');
            Parsing(txt, ref n);
            Meaning mod;
            return null;
        }

        static Meaning CM1(string txt)
        {
            int a;
            if (int.TryParse(txt, out a))
            {
                return new Number(a);
            }
            return CM2(txt);
        }
        static Meaning CM2(string txt)
        {
            int i = 0;
            string t1 = Parsing(txt, '.', ref i), t2;
            bool p1 = false,
                prim = false;
            if (t1 == "p1") { p1 = true; }
            else if (t1 == "p2") { }
            else { throw new Exception("Ошибка на " + (i + n)); }
            t1 = Parsing(txt, '.', ref i);
            t2 = Parsing(txt, ';', ref i);
            if (t2 == "1") { prim = true; }
            else if (t2 == "2") { }
            else { throw new Exception("Ошибка на " + (i + n)); }
            switch (t1)
            {
                case "сила":
                    return new MCharacteristic(TypeCharacteristic.Power, prim, p1);
                case "ловкость":
                    return new MCharacteristic(TypeCharacteristic.Dexterity, prim, p1);
                case "телосложение":
                    return new MCharacteristic(TypeCharacteristic.Physique, prim, p1);
                case "интеллект":
                    return new MCharacteristic(TypeCharacteristic.Intelligence, prim, p1);
                case "мудрость":
                    return new MCharacteristic(TypeCharacteristic.Wisdom, prim, p1);
                case "мд":
                    return new MCharacteristic(TypeCharacteristic.MagicPressure, prim, p1);
                case "аттака":
                    return new MCStatistics(TypeCharacteristicStatistics.Damag, prim, p1);
                case "защита":
                    return new MCStatistics(TypeCharacteristicStatistics.Protection, prim, p1);
                case "оз":
                    return new MPoint(TypePoints.HP, prim, p1);
                case "ом":
                    return new MPoint(TypePoints.MP, prim, p1);
                case "массив":
                    if (prim) { return new ArrayA(0); }
                    else { return null; }
                default: throw new Exception("Ошибка на " + (i + n - 1));
            }
        }
        static string Parsing(string txt, ref int n)
        {
            if (txt.Length <= n) { return null; }
            string p = "";
            for (; n < txt.Length; n++)
            {
                if (txt[n] == ' ' || txt[n] == '\r' || txt[n] == '\n') { continue; }
                break;
            }
            for (; n < txt.Length; n++)
            {
                if (txt[n] == '-' || txt[n] == '+' || txt[n] == '*' || txt[n] == '/') { break; }
                p += Convert.ToString(txt[n]);
            }
            return p;
        }
        static string Parsing(string txt, char end, ref int n)
        {
            if (txt.Length <= n) { return null; }
            string p = "";

            for (; n < txt.Length; n++)
            {
                if (txt[n] == ' ' || txt[n] == '\r' || txt[n] == '\n') { continue; }
                break;
            }
            for (; n < txt.Length; n++)
            {
                if (txt[n] == end) { break; }
                p += Convert.ToString(txt[n]);
            }
            n++;
            return p;
        }
        static string GetString(string code)
        {
            if (Parsing('.') == code) { return Parsing(';'); }
            else { throw new Exception("Ошибка на " + n); }
        }
        static string Parsing(char end)
        {
            if (txt.Length <= n) { return null; }
            string p = "";
            for (int i = n; i < txt.Length; i++)
            {
                if (txt[i] == ' ' || txt[i] == '\r' || txt[i] == '\n') { continue; }
                break;
            }
            for (int i = n; i < txt.Length; i++)
            {
                if (txt[i] == end) { break; }
                p += Convert.ToString(txt[i]);
            }
            n++;
            return p;
        }

    }
}
