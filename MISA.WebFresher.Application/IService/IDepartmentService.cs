using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp service đơn vị kế thừa lớp service base chỉ đọc
    /// </summary>
    /// Created by: dtthanh (25/9/2023)
    public interface IDepartmentService : IBaseReadOnlyService<DepartmentDto>
    {
    }
}
