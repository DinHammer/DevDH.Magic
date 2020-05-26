using System;
using System.Collections.Generic;
using System.Text;
//using constantEnum = DevDH.Magic.Abstractions.Constants.ConstantEnum;
using SimpleTools = DevDH.Magic.Abstractions.Staff.SimpleTools;

namespace DevDH.Magic.Abstractions
{
    public struct RequestResult<T> where T : class
    {
        public readonly List<Exception> ExceptionList;
        public string Message;
        public string MessageException => SimpleTools.Instance.ConvertExceptionList2String(ExceptionList);
        public readonly RequestStatus Status;
        public readonly T Data;
        public bool IsValid => Status == RequestStatus.Ok && Data != null && ExceptionList.Count == 0;

        public RequestResult(T data, RequestStatus status, string message = null, List<Exception> exceptionList = null )
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

        public override string ToString() { return $@"Result: {Status}, Data: {Data}, Message: {MessageException}, ExceptionCount: {ExceptionList.Count}"; }
    }



    public struct RequestResult
    {
        public readonly List<Exception> ExceptionList;
        public string Message;
        public string MessageException => SimpleTools.Instance.ConvertExceptionList2String(ExceptionList);
        public readonly RequestStatus Status;
        public bool IsValid => Status == RequestStatus.Ok;

        public RequestResult(RequestStatus status, string message = null, List<Exception> exceptionList = null )
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

        public override string ToString() { return $@"Result: {Status},  Message: {MessageException}, ExceptionCount: {ExceptionList.Count}"; }
    }

    public enum RequestStatus
    {
        Unknown = 0,
        Ok = 200,
        NotModified = 304,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        ServiceUnavailable = 503,
        Canceled = 1001,
        InvalidRequest = 1002,
        SerializationError = 1003,
        DatabaseError = 1100,
        FileAccessError = 2001,
        NoContent,
        NotOneValue,
        NotUnique,
        SomethingWrong,
        AlreadyExist,
        BlobErrorCreateContainer,
        BlobUploadError,
        BlobGetAllItemError,
        InputParamsNotValid
    }
}
