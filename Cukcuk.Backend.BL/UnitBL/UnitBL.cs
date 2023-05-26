using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Helpers;
using Cukcuk.Backend.Common.Resources;
using Cukcuk.Backend.DL.UnitDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.UnitBL
{
    /// <summary>
    /// Thực thi giao diện business layer đơn vị
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class UnitBL : BaseBL<Unit>, IUnitBL
    {
        #region Field
        private readonly IUnitDL _unitDL;
        #endregion

        #region Constructor
        public UnitBL(IUnitDL unitDL) : base(unitDL)
        {
            _unitDL = unitDL;
        }
        #endregion
        #region Method
        /// <summary>
        /// Validate cho các tính chất đặc biệt
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần validate</param>
        /// <returns>Danh sách chi tiết lỗi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public override List<ErrorDetail> ValidateForCustomFields(Unit record)
        {
            // 1. Khởi tạo danh sách lỗi
            var listOfErrors = new List<ErrorDetail>();

            // 2. Kiểm tra trùng lặp tên đơn vị
            var message = "";
            if (IsDuplicateName(record.UnitID, record.UnitName))
            {
                message = $"{CommonHelper.ParsePropertyName("UnitName")} " + record.UnitName + " " + ValidationError.duplicateCode;
            }

            if (message != "")
            {
                listOfErrors.Add(new ErrorDetail
                {
                    PropertyName = "UnitName",
                    Message = message
                });
            }

            return listOfErrors;
        }


        /// <summary>
        /// Kiểm tra trùng tên
        /// </summary>
        /// <param name="unitID">ID đơn vị cần kiểm tra</param>
        /// <param name="unitName">Tên đơn vị cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool IsDuplicateName(Guid unitID, string unitName)
        {
            return _unitDL.CheckDuplicateName(unitID, unitName);
        }
        #endregion
    }
}
