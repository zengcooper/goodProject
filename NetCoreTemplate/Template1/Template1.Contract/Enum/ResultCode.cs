using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template1.Contract.Enum
{
    /// <summary>
    /// ResultCode
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// InvalidParameter
        /// </summary>
        InvalidParameter = -1,
        /// <summary>
        /// Success
        /// </summary>
        Success = 20000,
        /// <summary>
        /// ServiceInternalError
        /// </summary>
        ServiceInternalError = 40000

    }
}
