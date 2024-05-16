using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Interface tương tác với Repository của nhân viên
    /// </summary>
    /// Created by: dtthanh (18/9/2023)
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// Created by: dtthanh (18/9/2023)
        Task<bool> IsExistEmployeeAsync(string employeeCode);

        /// <summary>
        /// Tạo mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (30/9/2023)
        Task<string> GetNewEmployeeCodeAsync();

        /// <summary>
        /// Phân trang tìm kiếm nhân viên
        /// </summary>
        /// <param name="page">Số trang</param>
        /// <param name="pageSize">Số bản ghi 1 trang</param>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Model lọc nhân viên</returns>
        /// Created by: dtthanh (1/10/2023)
        Task<EmployeeFilter> FilterEmployeeAsync(int page, int pageSize, string? searchKeyword = "");
    }
}
