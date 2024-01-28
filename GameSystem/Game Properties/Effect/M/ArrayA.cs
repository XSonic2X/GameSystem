using System;

namespace GameSystem.Game_Properties.Effect
{
    [Serializable]
    public class ArrayA : Number
    {
        public ArrayA(int num) : base(num) { }

        public override ArrayA GetArrayA()
        {
            return this;
        }
        public override Meaning Cloning()
        {
            return new ArrayA(Num);
        }
    }
}
