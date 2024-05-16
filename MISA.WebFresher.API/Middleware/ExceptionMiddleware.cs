using MISA.WebFresher.Domain;
using MISA.WebFresher.Domain.Resource;

namespace MISA.WebFresher.API
{
    /// <summary>
    /// Lớp xử lý ngoại lệ ở middleware
    /// </summary>
    /// Created by: dtthanh (18/9/2023)
    public class ExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;

        #endregion

        #region Constructors
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Thực hiện try catch
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>http context</returns>
        /// Created by: dtthanh (18/9/2023)
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Hàm xử lý exception
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="ex">Exception</param>
        /// <returns>Trả về lỗi</returns>
        /// Created by: dtthanh (18/9/2023)
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Console.WriteLine(ex);

            context.Response.ContentType = "application/json";

            if (ex is NotFoundException notFoundException)
            {
                context.Response.StatusCode =
                    StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = notFoundException.ErrorCode,
                    UserMsg = ResourceVN.NotFoundException,
                    DevMsg = ex.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = ex.HelpLink
                }.ToString() ?? "");
            }
            else if (ex is ConflictException conflicException)
            {
                context.Response.StatusCode =
                    StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = conflicException.ErrorCode,
                    UserMsg = ResourceVN.ConflictException,
                    DevMsg = ex.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = ex.HelpLink
                }.ToString() ?? "");
            }
            else
            {
                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = context.Response.StatusCode,
                    UserMsg = ResourceVN.SystemException,
                    DevMsg = ex.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = ex.HelpLink
                }.ToString() ?? "");
            }
        }

        #endregion    
    }
}
