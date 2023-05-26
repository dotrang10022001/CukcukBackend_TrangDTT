using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.MaterialBL
{
    /// <summary>
    /// Giao diện business layer nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public interface IMaterialBL:IBaseBL<MaterialDTO>
    {
        #region Method
        /// <summary>
        /// Lấy mã nguyên vật liệu mới
        /// </summary>
        /// <param name="startStr">Xâu in hoa tạo bởi các chữ cái đầu trong tên nguyên vật liệu</param>
        /// <returns>Mã nguyên vật liệu mới tương ứng với xâu tên viết tắt</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public ServiceResult GetNewCode(string startStr);
        #endregion
    }
}
