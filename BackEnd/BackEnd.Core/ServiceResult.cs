using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core
{
    public class ServiceResult<T>
    {
        public ServiceResult(ResponseCode responseCode, string error, T result)
        {
            ResponseCode = responseCode;
            Error = error;
            Result = result;
        }
        public ResponseCode ResponseCode { get; set; }

        public string Error { get; set; }

        public T Result { get; set; }

        public static ServiceResult<T> ErrorResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.Error, error, default(T));
        }

        public static ServiceResult<T> SuccessResult(T entity)
        {
            return new ServiceResult<T>(ResponseCode.Success, string.Empty, entity);
        }
    }
}
