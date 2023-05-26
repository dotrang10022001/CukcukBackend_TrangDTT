using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.DL.BaseDL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.DL.MaterialDL
{
    /// <summary>
    /// Thực thi giao diện data layer nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class MaterialDL:BaseDL<MaterialDTO>, IMaterialDL
    {
        #region Method
        /// <summary>
        /// Lấy mã nguyên vật liệu mới
        /// </summary>
        /// <param name="startStr">Xâu in hoa tạo bởi các chữ cái đầu trong tên nguyên vật liệu</param>
        /// <returns>Mã nguyên vật liệu mới tương ứng với xâu tên viết tắt</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public string GetNewCode(string startStr)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = "Proc_Material_GetNewCode";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            parameters.Add("v_StartStr", startStr);

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực hiện lệnh sql
            var newCode = QueryMultiple(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure).ReadFirst<string>();

            // 5. Xử lý kết quả trả về
            return newCode;
        }

        /// <summary>
        /// Lấy thông tin bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Thông tin bản ghi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public override MaterialDTO GetRecordById(Guid recordId)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = "Proc_Material_GetById";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            parameters.Add("v_MaterialID", recordId);

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực hiện truy vấn
            var result = QueryMultiple(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 5. Trả về kết quả
            MaterialDTO data = new MaterialDTO();
            data.Material = result.ReadFirst<Material>();
            data.ListOfConversions = result.Read<Conversion>().ToList();

            return data;
        }

        /// <summary>
        /// Xóa thông tin bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Thông tin bản ghi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public override int DeleteRecordById(Guid recordId)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = "Proc_Material_DeleteById";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            parameters.Add("v_MaterialID", recordId);

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực hiện truy vấn
            var affectedRows = Execute(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 5. Trả về kết quả

            return affectedRows;
        }
        #endregion
    }
}
