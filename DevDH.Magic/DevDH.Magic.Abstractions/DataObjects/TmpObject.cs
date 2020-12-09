using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.DataObjects
{
    class TmpObject
    {
    }

    public class MgcInt
    {
        public MgcInt() { }
        public MgcInt(int int_value)
        {
            this.int_value = int_value;
        }
        public int int_value { get; set; }
    }

    public class MgcBool
    {
        public MgcBool() { }
        public MgcBool(bool bool_value)
        {
            this.bool_value = bool_value;
        }
        public bool bool_value { get; set; }
    }
}
