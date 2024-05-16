using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp ngoại lệ không tìm thấy
    /// </summary>
    /// Created by: dtthanh (18/9/2023)
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int ErrorCode;

        #region Construction
        public NotFoundException() { }

        public NotFoundException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        #endregion
    }
}
