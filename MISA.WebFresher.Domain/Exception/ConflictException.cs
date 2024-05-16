using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp ngoại lệ xung đột dữ liệu
    /// </summary>
    public class ConflictException : Exception
    {
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int ErrorCode { get; set; }

        #region Construction
        public ConflictException() { }

        public ConflictException(int errorCode)
        {
            this.ErrorCode = errorCode;
        }
        public ConflictException(string message) : base(message) { }

        public ConflictException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        #endregion
    }
}
