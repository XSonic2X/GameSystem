using System;

namespace GameSystem.Game_Properties.Effect
{
    /// <summary>
    /// Изменение
    /// </summary>
    [Serializable]
    public class Modification : GAction
    {
        public Modification(Meaning mod, Meaning meaning) 
        {
            this.mod = mod;
            this.meaning = meaning;
        }

        Modification(Meaning mod, Meaning meaning,bool AvtoUpdate)
        {
            this.mod = mod;
            this.meaning = meaning;
            this.AvtoUpdate = AvtoUpdate;
            validity = mod.Validity() && meaning.Validity();
            if (validity && AvtoUpdate) { meaning.InstallEvent(this); }
        }
        protected bool validity = false;
        int value = 0;
        public override GAction Cloning(Game_Elements.Effect effect, Game_Objects.Player p1, Game_Objects.Player p2)
        {
            Meaning m1 = mod.Cloning(), m2 = meaning.Cloning();
            m1.Update(effect, p1, p2);
            m2.Update(effect, p1, p2);
            return new Modification(m1, m2, AvtoUpdate);
        }
        public override void Unuse()
        {
            if (validity)
            {
                mod.Set(mod.Get() - value);
            }
        }
        public override void Use()
        {
            if (validity)
            {
                mod.Set(mod.Get() - value);
                value = meaning.Get();
                mod.Set(mod.Get() + value);
            }
        }
        public override void End()
        {
            if (validity)
            {
                mod.Set(mod.Get() - value);
                if (validity && AvtoUpdate) { meaning.UninstallEvent(this); }
                validity = false;
            }
        }
        public override string ToString()
        {
            return $"Изменение {mod} += {meaning}";
        }
    }
}
