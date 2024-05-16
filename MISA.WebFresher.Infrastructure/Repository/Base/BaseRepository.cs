using Dapper;
using MISA.WebFresher.Application;
using MISA.WebFresher.Domain;
using MISA.WebFresher.Domain.Resource;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Infrastructure
{
    /// <summary>
    /// Lớp triển khai repository cơ sở
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// Created by: dtthanh(18/9/2023)
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
    {
        #region Fields
        protected readonly IUnitOfWork Uow;
        public virtual string TableName { get; set; } = typeof(TEntity).Name;
        #endregion

        #region Constructors
        public BaseRepository(IUnitOfWork uow)
        {
            Uow = uow;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tìm kiếm đối tượng với id
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <returns></returns>
        public async Task<TEntity?> FindAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @id";

            // Tạo param 
            var param = new DynamicParameters();
            param.Add("id", id);

            var result = await Uow.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction: Uow.Transaction);

            return result;
        }

        /// <summary>
        /// Lấy tất cả các đối tượng
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            var proc = $"Proc_{TableName}_GetAll";

            var result = await Uow.Connection.QueryAsync<TEntity>(proc, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);

            return result.ToList();
        }

        /// <summary>
        /// Lấy 1 đối tượng theo id
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Ngoại lệ không tìm thấy</exception>
        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await FindAsync(id);

            if (entity == null)
            {
                throw new NotImplementedException(ResourceVN.NotImplementedException);
            }

            return entity;
        }

        /// <summary>
        /// Lấy đối tượng theo danh sách id
        /// </summary>
        /// <param name="ids">Danh sách định danh</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Ngoại lệ không tìm thấy</exception>
        public async Task<List<TEntity>> GetByListIdAsync(List<Guid> ids)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id IN @ids";

            var parameters = new DynamicParameters();
            parameters.Add("ids", ids);

            var result = await Uow.Connection.QueryAsync<TEntity>(sql, parameters, transaction: Uow.Transaction);

            if (result.Count() < ids.Count)
            {
                throw new NotFoundException(ResourceVN.NotFoundId);
            }

            return result.ToList();
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public async Task<int> InsertAsync(TEntity entity)
        {
            var procedure = $"Proc_{TableName}_Create";
            var param = new DynamicParameters();
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var propertyName = "p_" + property.Name;
                var propertyValue = property.GetValue(entity);
                param.Add(propertyName, propertyValue);
            }

            var result = await Uow.Connection.ExecuteAsync(procedure, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);

            return result;
        }


        /// <summary>
        /// Cập nhật 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(TEntity entity)
        {
            var procedure = $"Proc_{TableName}_Update";
            var param = new DynamicParameters();
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var propertyName = "p_" + property.Name;
                var propertyValue = property.GetValue(entity);
                param.Add(propertyName, propertyValue);
            }

            var result = await Uow.Connection.ExecuteAsync(procedure, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);

            return result;

        }

        /// <summary>
        /// Xóa một đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TEntity entity)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @id";

            // Tạo param 
            var param = new DynamicParameters();
            param.Add("id", entity.GetId());

            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return result;
        }

        /// <summary>
        /// Xóa nhiều đối tượng 
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns></returns>
        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id IN @ids";

            // Tạo param 
            var param = new DynamicParameters();
            param.Add("ids", entities.Select(entity => entity.GetId()));

            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return result;
        } 
        #endregion
    }
}
