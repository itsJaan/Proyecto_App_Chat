using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core
{
    public enum ResponseCode
    {
        Success,
        Error,
        InternalServerError = 500,
        NotFound
    }
}
