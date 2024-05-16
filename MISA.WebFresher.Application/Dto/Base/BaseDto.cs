using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp Dto cơ sở
    /// </summary>
    /// Created by: dtthanh (15/9/2023)
    public class BaseDto
    {
        #region Properties
        /// <summary>
        /// Người tạo
        /// </summary>
        [StringLength(255)]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        [StringLength(255)]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Thời gian chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        #endregion
    }
}
