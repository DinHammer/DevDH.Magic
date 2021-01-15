using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {

        //public string mgcConvertExceptionList2String(List<Exception> exceptions)
        //{
        //    string result = string.Empty;

        //    if (exceptions == null)
        //    {
        //        return result;
        //    }

        //    if (exceptions?.Count == 0)
        //    {
        //        return result;
        //    }

        //    foreach (Exception exception in exceptions)
        //    {
        //        result = result + "\n" + exception.Message;
        //    }

        //    return result;
        //}

        public RequestResult<dalDataObjects.MgcInt> mgcConsvertString2Int(string str, int my_default_int = default_int)
        {
            int result = my_default_int;
            if (Int32.TryParse(str, out result))
            {
                return new RequestResult<dalDataObjects.MgcInt>(new dalDataObjects.MgcInt(result), statusOk);
            }
            else
            {
                return new RequestResult<dalDataObjects.MgcInt>(null, statusSomethingWrong, message: $"Can not convert string {str} to int");
            }
        }

        public RequestResult<dalDataObjects.MgcBool> ConverStringIntToBool(string str)
        {
            if (str.Equals("1"))
            {
                return new RequestResult<dalDataObjects.MgcBool>(new dalDataObjects.MgcBool(true), statusOk);
            }
            else
            {
                return new RequestResult<dalDataObjects.MgcBool>(new dalDataObjects.MgcBool(), statusOk);
            }
        }

        public RequestResult<dalDataObjects.MgcBool> mgcConverStringToBool(string str)
        {
            if (Boolean.Parse(str))
            {
                return new RequestResult<dalDataObjects.MgcBool>(new dalDataObjects.MgcBool(true), statusOk);
            }
            else
            {
                return new RequestResult<dalDataObjects.MgcBool>(null, statusSomethingWrong, message:$"can not convert string: {str} to Bool");
            }
        }

        public RequestResult<dalDataObjects.MgcDateTimeOffset> mgcConvertString2DateTimeOffset(string str)
        {
            DateTimeOffset result;
            try
            {
                result = Convert.ToDateTime(str);
                return new RequestResult<dalDataObjects.MgcDateTimeOffset>(new dalDataObjects.MgcDateTimeOffset(result), statusOk);
            }
            catch
            {
                return new RequestResult<dalDataObjects.MgcDateTimeOffset>(null, statusSomethingWrong, message: $"can not convert string: {str} to DateTimeOffset");
            }
        }

        public bool mgcConvertListBool2Bool(List<bool> list)
            => list.All(x => x == true);
    }
}
