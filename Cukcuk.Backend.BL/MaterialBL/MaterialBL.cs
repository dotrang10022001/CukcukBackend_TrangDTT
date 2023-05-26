using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.DL.MaterialDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.MaterialBL
{
    /// <summary>
    /// Thực thi giao diện business layer nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class MaterialBL: BaseBL<MaterialDTO>, IMaterialBL
    {
        #region Field
        private readonly IMaterialDL _materialDL;
        #endregion

        #region Constructor
        public MaterialBL(IMaterialDL materialDL): base(materialDL)
        {
            _materialDL = materialDL;
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy mã nguyên vật liệu mới
        /// </summary>
        /// <param name="startStr">Xâu in hoa tạo bởi các chữ cái đầu trong tên nguyên vật liệu</param>
        /// <returns>Mã nguyên vật liệu mới tương ứng với xâu tên viết tắt</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public ServiceResult GetNewCode(string startStr)
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Data = _materialDL.GetNewCode(startStr)
            };
        }
        #endregion
    }
}
