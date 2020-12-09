using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {

        public string ConvertExceptionList2String(List<Exception> exceptions)
        {
            string result = string.Empty;

            try
            {
                if (exceptions == null)
                {
                    return result;
                }

                if (exceptions?.Count == 0)
                {
                    return result;
                }

                foreach (Exception exception in exceptions)
                {
                    result = result + "\n" + exception.Message;
                }
            }
            catch
            { }

            return result;
        }

        public RequestResult<dalDataObjects.MgcInt> ConsvertString2Int(string str, int my_default_int = default_int)
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

        public RequestResult<Tuple<bool>> ConverStringIntToBool(string str)
        {
            if (str.Equals("1"))
            {
                return new RequestResult<Tuple<bool>>(Tuple.Create(true), statusOk);
            }
            else
            {
                return new RequestResult<Tuple<bool>>(Tuple.Create(false), statusOk);
            }
        }

        public RequestResult<Tuple<bool>> ConverStringToBool(string str)
        {
            if (Boolean.Parse(str))
            {
                return new RequestResult<Tuple<bool>>(Tuple.Create(true), statusOk);
            }
            else
            {
                return new RequestResult<Tuple<bool>>(null, statusSomethingWrong);
            }
        }

        public RequestResult<Tuple<DateTimeOffset>> ConvertString2DateTimeOffset(string str)
        {
            DateTimeOffset result;
            try
            {
                result = Convert.ToDateTime(str);
                return new RequestResult<Tuple<DateTimeOffset>>(Tuple.Create(result), statusOk);
            }
            catch
            {
                return new RequestResult<Tuple<DateTimeOffset>>(null, statusSomethingWrong);
            }
        }

        public bool ConvertListBool2Bool(List<bool> list)
            => list.All(x => x == true);
    }
}
