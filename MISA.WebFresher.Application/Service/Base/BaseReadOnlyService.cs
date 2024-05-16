using MISA.WebFresher.Domain;
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
    public abstract class BaseReadOnlyService<TEntity, TDto> : IBaseReadOnlyService<TDto>
    {

        #region Fields
        protected readonly IBaseRepository<TEntity> BaseRepository;
        #endregion

        #region Contructors
        protected BaseReadOnlyService(IBaseRepository<TEntity> baseRepository)
        {
            BaseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả các đối tượng
        /// </summary>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        public async Task<List<TDto>> GetAllAsync()
        {
            var entities = await BaseRepository.GetAllAsync();

            var result = entities.Select(entity => MapEntityToDto(entity)).ToList();

            return result;
        }

        /// <summary>
        /// Lấy 1 đối tượng theo id
        /// </summary>
        /// <param name="id">định danh đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        public async Task<TDto> GetAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = MapEntityToDto(entity);

            return result;
        }

        /// <summary>
        /// Map đổi tượng qua dto 
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public abstract TDto MapEntityToDto(TEntity entity);

        #endregion    
    }
}
