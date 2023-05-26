using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.UnitBL
{
    /// <summary>
    /// Giao diện business layer đơn vị
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public interface IUnitBL:IBaseBL<Unit>
    {
        /// <summary>
        /// Kiểm tra trùng tên
        /// </summary>
        /// <param name="unitID">ID đơn vị cần kiểm tra</param>
        /// <param name="unitName">Tên đơn vị cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool IsDuplicateName(Guid unitID, string unitName);
    }
}
