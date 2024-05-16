using MISA.WebFresher.Domain;
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
    /// <typeparam name="TEntity">Đối tượng</typeparam>
    /// <typeparam name="TDto">Dto đối tượng</typeparam>
    /// <typeparam name="TCreateDto">Dto thêm đối tượng</typeparam>
    /// <typeparam name="TUpdateDto">Dto sửa đối tượng</typeparam>
    /// Created by: dtthanh (25/9/2023)
    public abstract class BaseService<TEntity, TDto, TCreateDto, TUpdateDto> : BaseReadOnlyService<TEntity, TDto>, IBaseService<TDto, TCreateDto, TUpdateDto> where TEntity : IEntity
    {
        #region Contructors
        protected BaseService(IBaseRepository<TEntity> baseRepository) : base(baseRepository)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thêm 1 đối tượng
        /// </summary>
        /// <param name="createDto">Dto thêm đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        public async Task<TDto> InsertAsync(TCreateDto createDto)
        {
            var entity = MapCreateDtoToEntity(createDto);

            if (entity.GetId() == Guid.Empty)
            {
                entity.SetId(Guid.NewGuid());
            }

            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedBy ??= "DTTHANH";
                baseEntity.CreatedDate ??= DateTime.Now;
            }

            await ValidateCreateBusiness(entity);

            await BaseRepository.InsertAsync(entity);

            var result = MapEntityToDto(entity);

            return result;
        }

        /// <summary>
        /// Sửa 1 đối tượng
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <param name="updateDto">Dto sửa đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        public async Task<TDto> UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            var entity = await BaseRepository.GetAsync(id);

            var newEntity = MapUpdateDtoToEntity(updateDto, entity);

            if (newEntity is BaseEntity baseEntity)
            {
                baseEntity.ModifiedBy ??= "DTTHANH";
                baseEntity.ModifiedDate ??= DateTime.Now;
            }

            await ValidateUpdateBusiness(newEntity);

            await BaseRepository.UpdateAsync(newEntity);

            var result = MapEntityToDto(newEntity);

            return result;

        }

        /// <summary>
        /// Xóa 1 đối tượng theo id
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = await BaseRepository.DeleteAsync(entity);

            return result;
        }

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="ids">List ids</param>
        /// <returns></returns>
        /// Created by: dtthanh (25/9/2023)
        public async Task<int> DeleteManyAsync(List<Guid> ids)
        {
            var entities = await BaseRepository.GetByListIdAsync(ids);

            var result = await BaseRepository.DeleteManyAsync(entities);

            return result;
        }

        /// <summary>
        /// Map đổi tượng qua dto thêm mới
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public abstract TEntity MapCreateDtoToEntity(TCreateDto createDto);

        /// <summary>
        /// Validate nghiệp vụ thêm đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task ValidateCreateBusiness(TEntity entity)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Map đổi tượng qua dto chỉnh sửa
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public abstract TEntity MapUpdateDtoToEntity(TUpdateDto updateDto, TEntity entity);

        /// <summary>
        /// Validate nghiệp vụ sửa đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task ValidateUpdateBusiness(TEntity entity)
        {
            await Task.CompletedTask;
        } 
        #endregion

    }
}
