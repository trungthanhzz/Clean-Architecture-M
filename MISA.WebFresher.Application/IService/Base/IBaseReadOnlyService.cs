using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp service cơ sở chỉ đọc
    /// </summary>
    /// <typeparam name="TDto">Data tranfer của đối tượng</typeparam>
    /// Created by: dtthanh (25/9/2023)
    public interface IBaseReadOnlyService<TDto>
    {
        /// <summary>
        /// Lấy tất cả các đối tượng
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        Task<List<TDto>> GetAllAsync();

        /// <summary>
        /// Lấy 1 đối tượng theo id
        /// </summary>
        /// <param name="id">định danh đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        Task<TDto> GetAsync(Guid id);
    }
}
