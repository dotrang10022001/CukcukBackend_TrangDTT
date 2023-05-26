using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.DL.BaseDL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.DL.UnitDL
{
    /// <summary>
    /// Thực thi giao diện data layer đơn vị
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class UnitDL:BaseDL<Unit>, IUnitDL
    {
        /// <summary>
        /// Kiểm tra trùng lặp tên đơn vị
        /// </summary>
        /// <param name="unitID">ID đơn vị cần kiểm tra</param>
        /// <param name="unitName">Tên đơn vị cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool CheckDuplicateName(Guid unitID, string unitName)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = "Proc_Unit_CheckDuplicateName";

            // 2. Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"v_UnitID", unitID);
            parameters.Add($"v_UnitName", unitName);

            // 3. Khởi tạo kết nối đến database
            var connection = GetConnection();
            var result = QueryFirstOrDefault(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 4. Xử lý kết quả trả về
            if (result != null) return true;
            return false;
        }
    }
}
