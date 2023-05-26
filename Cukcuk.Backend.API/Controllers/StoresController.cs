using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.BL.StoreBL;
using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Enums;
using Cukcuk.Backend.Common.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cukcuk.Backend.API.Controllers
{
    public class StoresController : BaseController<Store>
    {
        #region Field
        private readonly IStoreBL _storeBL;
        #endregion

        #region Constructor
        public StoresController(IStoreBL storeBL) : base(storeBL)
        {
            _storeBL = storeBL;
        }
        #endregion
        #region Method
        /// <summary>
        /// API lấy mã kho mới
        /// </summary>
        /// <returns>Mã trả lời + mã kho/thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpGet("GetNewCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                ServiceResult result = _storeBL.GetNewCode();
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
