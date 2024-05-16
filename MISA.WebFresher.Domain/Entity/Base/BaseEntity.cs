using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp thực thể cơ sở
    /// </summary>
    /// Created by: dtthanh (20/9/2023)
    public abstract class BaseEntity
    {
        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Thời gian chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

    }
}
