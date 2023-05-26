using Cukcuk.Backend.BL.MaterialBL;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Enums;
using Cukcuk.Backend.Common.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cukcuk.Backend.API.Controllers
{
    public class MaterialsController : BaseController<MaterialDTO>
    {
        #region Field
        private readonly IMaterialBL _materialBL;
        #endregion

        #region Constructor
        public MaterialsController(IMaterialBL materialBL) : base(materialBL)
        {
            _materialBL = materialBL;
        }
        #endregion

        #region Method
        [HttpGet("GetNewCode")]
        public IActionResult GetNewCode([FromQuery]string startStr)
        {
            try
            {
                ServiceResult result = _materialBL.GetNewCode(startStr);
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
