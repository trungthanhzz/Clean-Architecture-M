using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher.Application;

namespace MISA.WebFresher.API
{
    /// <summary>
    /// Lớp controller chỉ đọc
    /// </summary>
    /// Created by: dtthanh (20/9/2023)
    [Route("api/vi/[controller]")]
    [ApiController]
    public class BaseReadOnlyController<TDto> : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Service cơ sở chỉ đọc
        /// </summary>
        /// Created by: dtthanh (20/9/2023)
        protected readonly IBaseReadOnlyService<TDto> BaseReadOnlyService;
        #endregion

        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseReadOnlyService"></param>
        /// Created by: dtthanh (20/9/2023)
        public BaseReadOnlyController(IBaseReadOnlyService<TDto> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>Danh danh bản ghi</returns>
        /// Created by: dtthanh (20/9/2023)
        [HttpGet]
        public async Task<List<TDto>> GetAllAsync()
        {
            var result = await BaseReadOnlyService.GetAllAsync();

            return result;
        }

        /// <summary>
        /// Lấy ra một bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Created by: dtthanh (20/9/2023)
        [HttpGet]
        [Route("{id}")]
        public async Task<TDto> GetAsync(Guid id)
        {
            var result = await BaseReadOnlyService.GetAsync(id);

            return result;
        }

        #endregion
    }
}
