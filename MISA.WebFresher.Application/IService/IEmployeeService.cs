using MISA.WebFresher.Domain;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Interface cho lớp service nhân viên
    /// </summary>
    /// Created by: dtthanh (25/9/2023)
    public interface IEmployeeService : IBaseService<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Xuất dữ liệu ra file excel
        /// </summary>
        /// <returns>excel package</returns>
        /// Created by: dtthanh (5/10/2023)
        Task<MemoryStream> ExportExcelAsync();
    }
}
