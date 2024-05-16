using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher.Application;

namespace MISA.WebFresher.API
{
    /// <summary>
    /// Lớp controller cơ sở
    /// </summary>
    /// Created by: dtthanh (20/9/2023)
    public class BaseController<TDto, TCreateDto, TUpdateDto> : BaseReadOnlyController<TDto>
    {
        #region Fields
        /// <summary>
        /// Service cơ sở
        /// </summary>
        /// Created by: dtthanh (20/9/2023)
        protected readonly IBaseService<TDto, TCreateDto, TUpdateDto> BaseService;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseService">Service cơ sở</param>
        /// Created by: dtthanh (20/9/2023)
        public BaseController(IBaseService<TDto, TCreateDto, TUpdateDto> baseService) : base(baseService)
        {
            BaseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="createDto">Dữ liệu bản ghi cần thêm</param>
        /// <returns></returns>
        /// Created by: dtthanh (20/9/2023)
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] TCreateDto createDto)
        {
            var result = await BaseService.InsertAsync(createDto);

            return StatusCode(201, result);
        }

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="id">Mã định danh đối tượng</param>
        /// <param name="updateDto">Đối tượng cập nhật</param>
        /// <returns></returns>
        /// Created by: dtthanh(20/9/2023)
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TUpdateDto updateDto)
        {
            var result = await BaseService.UpdateAsync(id, updateDto);

            return Ok(result);
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">Định danh đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh(20/9/2023)
        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await BaseService.DeleteAsync(id);

            return result;
        }

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="ids">Danh sách định danh đối tượng</param>
        /// <returns></returns>
        /// Created by: dtthanh(20/9/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteManyAsync([FromBody] List<Guid> ids)
        {
            var result = await BaseService.DeleteManyAsync(ids);

            return Ok(result);
        }

        #endregion
    }
}
