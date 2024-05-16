using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp ngoại lệ cơ sở
    /// </summary>
    /// Created by: dtthanh (18/9/2023)
    public class BaseException
    {
        #region Properties
        /// <summary>
        /// Mã lỗi nội bộ
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Thông báo cho dev
        /// </summary>
        public string? DevMsg { get; set; }

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// Thông tin thêm
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Mã tra cứu thông tin lỗi 
        /// </summary>
        public string? TraceId { get; set; }

        /// <summary>
        /// Lỗi đính kèm
        /// </summary>
        public object? Errors { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Phương thức chuyển lỗi thành json
        /// </summary>
        /// <returns>Chuỗi json</returns>
        public override string ToString()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(this, option);
        }
        #endregion
    }
}
