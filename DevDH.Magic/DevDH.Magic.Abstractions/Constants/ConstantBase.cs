using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.Constants
{
    /// <summary>
    /// Набор Констант которые чаще всего используются в одном месте
    /// </summary>
    public class ConstantBase
    {
        protected ConstantEnum.RequestStatus statusUnknown = ConstantEnum.RequestStatus.Unknown;
        protected ConstantEnum.RequestStatus statusOk = ConstantEnum.RequestStatus.Ok;
        protected ConstantEnum.RequestStatus statusNotModified = ConstantEnum.RequestStatus.NotModified;
        protected ConstantEnum.RequestStatus statusBadRequest = ConstantEnum.RequestStatus.BadRequest;
        protected ConstantEnum.RequestStatus statusUnauthorized = ConstantEnum.RequestStatus.Unauthorized;
        protected ConstantEnum.RequestStatus statusForbidden = ConstantEnum.RequestStatus.Forbidden;
        protected ConstantEnum.RequestStatus statusNotFound = ConstantEnum.RequestStatus.NotFound;
        protected ConstantEnum.RequestStatus statusInternalServerError = ConstantEnum.RequestStatus.InternalServerError;
        protected ConstantEnum.RequestStatus statusServiceUnavailable = ConstantEnum.RequestStatus.ServiceUnavailable;
        protected ConstantEnum.RequestStatus statusCanceled = ConstantEnum.RequestStatus.Canceled;
        protected ConstantEnum.RequestStatus statusInvalidRequest = ConstantEnum.RequestStatus.InvalidRequest;
        protected ConstantEnum.RequestStatus statusSerializationError = ConstantEnum.RequestStatus.SerializationError;
        protected ConstantEnum.RequestStatus statusDatabaseError = ConstantEnum.RequestStatus.DatabaseError;
        protected ConstantEnum.RequestStatus statusFileAccessError = ConstantEnum.RequestStatus.FileAccessError;
        protected ConstantEnum.RequestStatus statusNoContent = ConstantEnum.RequestStatus.NoContent;
        protected ConstantEnum.RequestStatus statusNotOneValue = ConstantEnum.RequestStatus.NotOneValue;
        protected ConstantEnum.RequestStatus statusNotUnique = ConstantEnum.RequestStatus.NotUnique;
        protected ConstantEnum.RequestStatus statusSomethingWrong = ConstantEnum.RequestStatus.SomethingWrong;
        protected ConstantEnum.RequestStatus statusAlreadyExist = ConstantEnum.RequestStatus.AlreadyExist;
        protected ConstantEnum.RequestStatus statusBlobErrorCreateContainer = ConstantEnum.RequestStatus.BlobErrorCreateContainer;
        protected ConstantEnum.RequestStatus statusBlobUploadError = ConstantEnum.RequestStatus.BlobUploadError;
        protected ConstantEnum.RequestStatus statusBlobGetAllItemError = ConstantEnum.RequestStatus.BlobGetAllItemError;
        protected ConstantEnum.RequestStatus statusInputParamsNotValid = ConstantEnum.RequestStatus.InputParamsNotValid;

        protected const int default_int = ConstantNumeric.default_int;
    }
}
