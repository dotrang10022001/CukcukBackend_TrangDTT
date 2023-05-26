using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.DL.UnitDL
{
    /// <summary>
    /// Giao diện data layer đơn vị
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public interface IUnitDL:IBaseDL<Unit>
    {
        /// <summary>
        /// Kiểm tra trùng lặp tên đơn vị
        /// </summary>
        /// <param name="unitID">ID đơn vị cần kiểm tra</param>
        /// <param name="unitName">Tên đơn vị cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool CheckDuplicateName(Guid unitID, string unitName);
    }
}
