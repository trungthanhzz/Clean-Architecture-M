using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Lớp service cơ sở 
    /// </summary>
    /// <typeparam name="TDto">Dto đối tượng</typeparam>
    /// <typeparam name="TCreateDto">Dto thêm đối tượng</typeparam>
    /// <typeparam name="TUpdateDto">Dto sửa đối tượng</typeparam>
    /// Created by: dtthanh (25/9/2023)
    public interface IBaseService<TDto, TCreateDto, TUpdateDto> : IBaseReadOnlyService<TDto>
    {
        /// <summary>
        /// Thêm 1 đối tượng
        /// </summary>
        /// <param name="createDto">Dto thêm đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        Task<TDto> InsertAsync(TCreateDto createDto);

        /// <summary>
        /// Sửa 1 đối tượng
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <param name="updateDto">Dto sửa đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        Task<TDto> UpdateAsync(Guid id, TUpdateDto updateDto);

        /// <summary>
        /// Xóa 1 đối tượng theo id
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="ids">List ids</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        Task<int> DeleteManyAsync(List<Guid> ids);

    }
}
