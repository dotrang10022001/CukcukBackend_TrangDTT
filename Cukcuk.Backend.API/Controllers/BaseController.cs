using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Enums;
using Cukcuk.Backend.Common.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cukcuk.Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field
        private readonly IBaseBL<T> _baseBL;
        #endregion

        #region Constructor
        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        #region Method
        /// <summary>
        /// API lấy danh sách bản ghi
        /// </summary>
        /// <returns>Mã trả lời + dữ liệu/thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {
                var result = _baseBL.GetAllRecords();
                return StatusCode((int)(ResponseCode.Success), result.Data);
            }
            catch (Exception exception)
            {
                return StatusCode((int)(ResponseCode.ServerError), new ErrorInfo
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = exception.Message,
                    UserMsg = new List<string> { ResponseMessage.exceptionUserMsg },
                    MoreInfo = null,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API lấy thông tin bản ghi khi biết id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Mã trả lời + dữ liệu/thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpGet("{recordId}")]
        public IActionResult GetRecordById(Guid recordId)
        {
            try
            {
                ServiceResult result = _baseBL.GetRecordById(recordId);
                return StatusCode((int)(ResponseCode.Success), result.Data);
            }
            catch (Exception exception)
            {
                return StatusCode((int)(ResponseCode.ServerError), new ErrorInfo
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = exception.Message,
                    UserMsg = new List<string> { ResponseMessage.exceptionUserMsg },
                    MoreInfo = null,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API xóa bản ghi khi biết id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Mã trả lời + dữ liệu/thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpDelete("{recordId}")]
        public IActionResult DeleteRecordById(Guid recordId)
        {
            try
            {
                ServiceResult result = _baseBL.DeleteRecordById(recordId);
                return StatusCode((int)(ResponseCode.Success), result.Data);
            }
            catch (Exception exception)
            {
                return StatusCode((int)(ResponseCode.ServerError), new ErrorInfo
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = exception.Message,
                    UserMsg = new List<string> { ResponseMessage.exceptionUserMsg },
                    MoreInfo = null,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
        /// <summary>
        /// API thêm mới bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần thêm mới</param>
        /// <returns>Mã trả lời + Dữ liệu/Thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpPost]
        public IActionResult InsertRecord(T record)
        {
            try
            {
                ServiceResult result = _baseBL.InsertRecord(record);
                if (!result.IsSuccess)
                {
                    return StatusCode((int)(ResponseCode.BadRequest), result.Data);
                }
                return StatusCode((int)(ResponseCode.Created), result.Data);
            }
            catch (Exception exception)
            {
                return StatusCode((int)(ResponseCode.ServerError), new ErrorInfo
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = exception.Message,
                    UserMsg = new List<string> { ResponseMessage.exceptionUserMsg },
                    MoreInfo = null,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần cập nhật</param>
        /// <returns>Mã trả lời + Dữ liệu/Thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpPut]
        public IActionResult UpdateRecord(T record)
        {
            try
            {
                ServiceResult result = _baseBL.UpdateRecord(record);
                if (!result.IsSuccess)
                {
                    return StatusCode((int)(ResponseCode.BadRequest), result.Data);
                }
                return StatusCode((int)(ResponseCode.Success), result.Data);
            }
            catch (Exception exception)
            {
                return StatusCode((int)(ResponseCode.ServerError), new ErrorInfo
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = exception.Message,
                    UserMsg = new List<string> { ResponseMessage.exceptionUserMsg },
                    MoreInfo = null,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
        #endregion
    }
}
