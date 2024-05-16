using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher.Application;
using MISA.WebFresher.Domain;
using MySqlConnector;

namespace MISA.WebFresher.API.Controllers
{
    /// <summary>
    /// Lớp controller nhân viên
    /// </summary>
    /// Created by: dtthanh (20/9/2023)
    public class EmployeesController : BaseController<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        private readonly IEmployeeService _employeeService;
        #region Contructors
        /// <summary>
        /// Hàm khởi tạo controller nhân viên
        /// </summary>
        /// <param name="employeeService">Service nhân viên</param>
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        /// <summary>
        /// Controller lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("NewEmployeeCode")]
        public async Task<IActionResult> GetNewEmployeeCodeAsync()
        {
            var result = await _employeeService.GetNewEmployeeCodeAsync();

            return Ok(result);
        }

        /// <summary>
        /// Controller phân trang và tìm kiếm nhân viên
        /// </summary>
        /// <param name="page">trang số</param>
        /// <param name="pageSize">kích cỡ trang</param>
        /// <param name="searchKeyword">từ khóa tìm kiếm</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Filter")]
        public async Task<IActionResult> FilterEmployeeAsync([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? searchKeyword = "")
        {
            var result = await _employeeService.FilterEmployeeAsync(page, pageSize, searchKeyword);

            return Ok(result);
        }

        /// <summary>
        /// Controller xuất khẩu giữ liệu ra excel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> ExportExcelAsync()
        {
            var data = await _employeeService.ExportExcelAsync();
            var fileName = "employees-export.xlsx";
            return File(data, "application/vnd.openxalformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
