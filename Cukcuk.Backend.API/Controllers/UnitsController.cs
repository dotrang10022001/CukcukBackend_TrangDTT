using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.BL.UnitBL;
using Cukcuk.Backend.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cukcuk.Backend.API.Controllers
{
    public class UnitsController : BaseController<Unit>
    {
        #region Field
        private readonly IUnitBL _unitBL;
        #endregion

        #region Constructor
        public UnitsController(IUnitBL unitBL) : base(unitBL)
        {
            _unitBL = unitBL;
        }
        #endregion
    }
}
