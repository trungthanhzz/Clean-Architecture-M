using MISA.WebFresher.Domain.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Lớp triển khai validate nghiệp vụ
    /// </summary>
    /// Created by: dtthanh(18/9/2023)
    public class EmployeeValidate : IEmployeeValidate
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructors
        public EmployeeValidate(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Hàm kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns></returns>
        /// <exception cref="ConflictException">Ngoại lệ xung đột dữ liệu</exception>
        /// Created by: dtthanh(18/9/2023)
        public async Task CheckEmployeeCodeAsync(Employee employee)
        {
            var isCheckEmployeeCode = await _employeeRepository.IsExistEmployeeAsync(employee.EmployeeCode);

            if (isCheckEmployeeCode == true)
            {
                throw new ConflictException(ResourceVN.ConflictException);
            }
        }

        #endregion    
    }
}
