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

    public class MgcBoolData<T> where T : class, IBaseObjectId
    {
        public MgcBoolData() { }
        public MgcBoolData(bool bool_value, T data)
        {
            this.bool_value = bool_value;
            this.data = data;
        }
        public bool bool_value { get; set; }
        public T data { get; set; }
    }

    public class MgcDateTimeOffset
    {
        public MgcDateTimeOffset() { }
        public MgcDateTimeOffset(DateTimeOffset dateTime_value)
        {
            this.dateTime_value = dateTime_value;
        }
        public DateTimeOffset dateTime_value { get; set; }
    }

    public class MgcDateTime
    {
        public MgcDateTime() { }
        public MgcDateTime(DateTime dateTime_value)
        {
            this.dateTime_value = dateTime_value;
        }
        public DateTime dateTime_value { get; set; }
    }
}
