using GameSystem.Game_Properties.Player;
using System;

namespace GameSystem.Game_Properties.Effect
{
    [Serializable]
    public class MCharacteristic : Meaning
    {
        public MCharacteristic(TypeCharacteristic Chara, bool primary, bool p1)
        {
            type = Chara;
            this.primary = primary;
            this.p1 = p1;
        }
        Characteristic chara;
        TypeCharacteristic type;
        bool primary;
        bool p1 = true;
        event VoidEvent VEStart;
        event VoidEvent VEEnd;
        public override void InstallEvent(GAction gAction)
        {
            VEStart += gAction.Unuse;
            VEEnd += gAction.Use;
        }
        public override void UninstallEvent(GAction gAction)
        {
            VEStart -= gAction.Unuse;
            VEEnd -= gAction.Use;
        }
        public void UpdateStarte(Characteristic c, bool p) { if (p == primary) { VEStart?.Invoke(); } }
        public void UpdateEnd(Characteristic c, bool p) { if (p == primary) { VEEnd?.Invoke(); } }
        public override int Get()
        {
            if (primary) { return chara.primaryChar; }
            return chara.secondaryChar;
        }
        public override void Set(int num)
        {
            if (primary) { chara.primaryChar = num; }
            else { chara.secondaryChar = num; }
        }
        public override string ToString()
        {
            if (chara == null) 
            {
                if (primary) { return $"Пер.{GameString.CharToString(type)}:-0"; }
                return $"Вто.{GameString.CharToString(type)}:-0";
            }
            if (primary) { return $"Пер.{GameString.CharToString(type)}:{chara.primaryChar}"; }
            return $"Вто.{GameString.CharToString(type)}:{chara.secondaryChar}";
        }
        public override void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2)
        {
            if (this.p1) { chara = p1.specifications.GetChar(type); }
            else { chara = p2.specifications.GetChar(type); }
            if (VEStart != null)
            {
                VEStart = null;
                VEEnd = null;
            }
            chara.CEUpdateStart += UpdateStarte;
            chara.CEUpdateEnd += UpdateEnd;
        }
        public override bool Validity()
        {
            return chara != null;
        }
        public override Meaning Cloning()
        {
            return new MCharacteristic(type,primary,p1);
        }

    }
}
