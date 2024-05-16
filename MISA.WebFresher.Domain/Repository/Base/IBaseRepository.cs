using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Domain
{
    /// <summary>
    /// Interface của repository cơ sở
    /// </summary>
    /// <typeparam name="TEntity">Đối tượng</typeparam>
    /// Created by: dtthanh (15/9/2023)
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy tất cả các đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// Created by: dtthanh (15/9/2023)
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Hàm tìm kiếm theo id
        /// </summary>
        /// <param name="id">id đối tượng</param>
        /// <returns>một đối tượng</returns>
        /// Created by: dtthanh (15/9/2023)
        Task<TEntity?> FindAsync(Guid id);

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">id đối tượng</param>
        /// <exception cref="NotFoundException">Không tìm thấy</exception>
        /// <returns>Một đối tượng</returns>
        /// Created by: dtthanh (15/9/2023)
        Task<TEntity> GetAsync(Guid id);

        Task<List<TEntity>> GetByListIdAsync(List<Guid> ids);

        /// <summary>
        /// Hàm thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">Nhân viên</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: dtthanh (15/9/2023)
        Task<int> InsertAsync(TEntity entity);

        /// <summary>
        /// Hàm sửa một đối tượng
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: dtthanh (15/9/2023)
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (15/9/2023)
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa nhiều đối tượng
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        /// Created by: dtthanh (15/9/2023)
        Task<int> DeleteManyAsync(List<TEntity> entitys);
    }
}
