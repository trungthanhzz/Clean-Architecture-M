using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp dto đơn vị
    /// </summary>
    /// Created by: dtthanh (15/9/2023)
    public class DepartmentDto : BaseDto
    {
        #region Properties
        /// <summary>
        /// Định danh đơn vị
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        [StringLength(255)]
        public string DepartmentName { get; set; }

        #endregion
    }
}
