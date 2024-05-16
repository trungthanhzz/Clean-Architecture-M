using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Interface cho lớp validate nghiệp vụ
    /// </summary>
    /// Created by: dtthanh(18/9/2023)
    public interface IEmployeeValidate
    {
        /// <summary>
        /// Kiểm tra xem mã nhân viên có bị trùng không
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <exception cref="ConflicException">Nếu nhân viên tồn tại</exception>
        /// <returns></returns>
        /// Created by: dtthanh(18/9/2023)
        Task CheckEmployeeCodeAsync(Employee employee);
    }
}
