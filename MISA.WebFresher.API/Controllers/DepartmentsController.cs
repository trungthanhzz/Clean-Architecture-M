using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher.Application;

namespace MISA.WebFresher.API
{
    /// <summary>
    /// Lớp controller đơn vị
    /// </summary>
    /// Created by: dtthanh (20/9/2023)
    public class DepartmentsController : BaseReadOnlyController<DepartmentDto>
    {
        #region Contructors
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="departmentService">Service đơn vị</param>
        /// Created by: dtthanh (20/9/2023)
        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
        }

        #endregion    
    }
}
