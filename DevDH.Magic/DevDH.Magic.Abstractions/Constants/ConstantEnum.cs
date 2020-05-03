using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.Constants
{
    /// <summary>
    /// Набор Enum констант
    /// </summary>
    public class ConstantEnum
    {
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
}
