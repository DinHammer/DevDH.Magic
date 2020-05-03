using System;
using System.Collections.Generic;
using System.Text;
using constantEnum = DevDH.Magic.Abstractions.Constants.ConstantEnum;
using SimpleTools = DevDH.Magic.Abstractions.Staff.SimpleTools;

namespace DevDH.Magic.Abstractions
{
    public struct RequestResult<T> where T : class
    {
        public readonly List<Exception> ExceptionList;
        public string Message;
        public string MessageException => SimpleTools.Instance.ConvertExceptionList2String(ExceptionList);
        public readonly constantEnum.RequestStatus Status;
        public readonly T Data;
        public bool IsValid => Status == constantEnum.RequestStatus.Ok && Data != null && ExceptionList.Count == 0;

        public RequestResult(T data, constantEnum.RequestStatus status, List<Exception> exceptionList = null, string message = null)
        {
            Data = data;
            Status = status;

            if (exceptionList != null)
            {
                ExceptionList = exceptionList;
            }
            else
            {
                ExceptionList = new List<Exception>();
            }
            Message = message;
        }

        public override string ToString() { return $@"Result: {Status}, Data: {Data}, Message: {MessageException}, ExceptionCount: {ExceptionList?.Count}"; }
    }



    public struct RequestResult
    {
        public readonly List<Exception> ExceptionList;
        public string Message;
        public string MessageException => SimpleTools.Instance.ConvertExceptionList2String(ExceptionList);
        public readonly constantEnum.RequestStatus Status;
        public bool IsValid => Status == constantEnum.RequestStatus.Ok;

        public RequestResult(constantEnum.RequestStatus status, List<Exception> exceptionList = null, string message = null)
        {
            Status = status;

            if (exceptionList != null)
            {
                ExceptionList = exceptionList;
            }
            else
            {
                ExceptionList = new List<Exception>();
            }

            Message = message;
        }

        public override string ToString() { return $@"Result: {Status},  Message: {MessageException}, ExceptionCount: {ExceptionList?.Count}"; }
    }
}
