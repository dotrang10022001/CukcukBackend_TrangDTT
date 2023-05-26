using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.BL.CategoryBL;
using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Enums;
using Cukcuk.Backend.Common.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cukcuk.Backend.API.Controllers
{
    public class CategoriesController : BaseController<Category>
    {
        #region Field
        private readonly ICategoryBL _categoryBL;
        #endregion

        #region Constructor
        public CategoriesController(ICategoryBL categoryBL) : base(categoryBL)
        {
            _categoryBL = categoryBL;
        }
        #endregion
        #region Method
        /// <summary>
        /// API lấy mã nhóm nguyên vật liệu mới
        /// </summary>
        /// <returns>Mã trả lời + mã nhóm nguyên vật liệu/thông tin lỗi</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        [HttpGet("GetNewCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                ServiceResult result = _categoryBL.GetNewCode();
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
