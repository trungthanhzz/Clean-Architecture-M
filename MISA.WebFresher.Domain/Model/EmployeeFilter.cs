using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp chứa model của chức năng phân trang, tìm kiếm
    /// </summary>
    /// Created by: dtthanh (1/10/2023)
    public class EmployeeFilter
    {
        #region Fields
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Số bản ghi hiện tại
        /// </summary>
        public int CurrentPageRecords { get; set; }

        /// <summary>
        /// Số trang hiện tại
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Danh sách nhân viên trả về
        /// </summary>
        public List<Employee> Employees { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="totalRecords">Tổng số bản ghi</param>
        /// <param name="totalPages">Tổng số trang</param>
        /// <param name="currentPageRecords">Số bản ghi hiện tại</param>
        /// <param name="currentPage">Số trang hiện tại</param>
        /// <param name="employees">Danh sách nhân viên</param>
        public EmployeeFilter(int totalRecords, int totalPages, int currentPageRecords, int currentPage, List<Employee> employees)
        {
            TotalRecords = totalRecords;
            TotalPages = totalPages;
            CurrentPageRecords = currentPageRecords;
            CurrentPage = currentPage;
            Employees = employees;
        }

        #endregion    
    }
}
