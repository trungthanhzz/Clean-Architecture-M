using Dapper;
using MISA.WebFresher.Application;
using MISA.WebFresher.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Infrastructure
{
    /// <summary>
    /// Lớp repo riêng cho nhân viên
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructors
        public EmployeeRepository(IUnitOfWork uow) : base(uow)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Chức năng phân trang, tìm kiếm nhân viên
        /// </summary>
        /// <param name="page">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên trang</param>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>EmployeeFilter</returns>
        /// Created by: dtthanh (1/10/2023)
        public async Task<EmployeeFilter> FilterEmployeeAsync(int page, int pageSize, string? searchKeyword = "")
        {
            searchKeyword ??= "";
            var procedure = "Proc_Employee_Filter";
            var param = new DynamicParameters();
            param.Add("page", page);
            param.Add("pageSize", pageSize);
            param.Add("searchKeyword", searchKeyword);

            var result = await Uow.Connection.QueryMultipleAsync(procedure, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);

            var totalRecords = result.ReadSingleOrDefault<int>();
            var totalPages = result.ReadSingleOrDefault<int>();
            var employees = result.Read<Employee>().ToList();

            var currentPage = page;
            var currentPageRecords = employees.Count;

            return new EmployeeFilter(
                    totalRecords,
                    totalPages,
                     currentPageRecords,
                     currentPage,
                     employees
                );
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created by: dtthanh (30/9/2023)
        public async Task<string> GetNewEmployeeCodeAsync()
        {
            var procedure = "Proc_Employee_GetNewCode";

            var result = await Uow.Connection.QuerySingleAsync<string>(procedure, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);

            return result;
        }

        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true/false</returns>
        /// Created by: dtthanh (18/9/2023)
        public async Task<bool> IsExistEmployeeAsync(string employeeCode)
        {
            string sql = $"SELECT * FROM Employee WHERE employee.EmployeeCode = @employeeCode";
            var param = new DynamicParameters();
            param.Add("employeeCode", employeeCode);
            var employee = await Uow.Connection.QuerySingleOrDefaultAsync(sql, param, transaction: Uow.Transaction);
            if (employee != null) return true;
            return false;
        }
        #endregion    
    }
}
