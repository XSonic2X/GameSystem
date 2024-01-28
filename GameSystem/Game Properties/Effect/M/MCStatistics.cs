using GameSystem.Game_Properties.Player;
using System;

namespace GameSystem.Game_Properties.Effect
{
    [Serializable]
    public class MCStatistics : Meaning
    {
        public MCStatistics(TypeCharacteristicStatistics typeCS, bool primary, bool p1) 
        { 
            this.typeCS = typeCS;
            this.primary = primary;
            this.p1 = p1;
        }
        CharacteristicStatistics cs;
        bool primary;
        bool p1 = true;
        TypeCharacteristicStatistics typeCS;
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
        public void UpdateStarte(CharacteristicStatistics c, bool p) { if (p == primary) { VEStart?.Invoke(); } }
        public void UpdateEnd(CharacteristicStatistics c, bool p) { if (p == primary) { VEEnd?.Invoke(); } }
        public override int Get()
        {
            if (primary) { return cs.primaryChar; }
            return cs.secondaryChar;
        }
        public override void Set(int num)
        {
            if(primary) { cs.primaryChar = num; } 
            else { cs.secondaryChar = num; }
        }
        public override string ToString()
        {
            if (cs == null)
            {
                if (primary) { return $"Пер.{GameString.CharSToString(typeCS)}:-0"; }
                return $"Вто.{GameString.CharSToString(typeCS)}:-0";
            }
            if (primary) { return $"Пер.{GameString.CharSToString(typeCS)}:{cs.primaryChar}"; }
            return $"Вто.{GameString.CharSToString(typeCS)}:{cs.secondaryChar}";
        }
        public override void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2)
        {
            if (this.p1) { cs = p1.specifications.GetCharS(typeCS); }
            else { cs = p2.specifications.GetCharS(typeCS); }
            if (VEStart != null)
            {
                VEStart = null;
                VEEnd = null;
            }
            cs.CSEUpdateStart += UpdateStarte;
            cs.CSEUpdateEnd += UpdateEnd;
        }

        public override bool Validity()
        {
            return cs != null;
        }

        public override Meaning Cloning()
        {
            return new MCStatistics(typeCS,primary,p1);
        }
    }
}
