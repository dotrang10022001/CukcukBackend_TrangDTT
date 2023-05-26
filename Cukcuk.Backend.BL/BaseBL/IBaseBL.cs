using Cukcuk.Backend.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.BaseBL
{
    /// <summary>
    /// Giao diện business layer cơ sở
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu đối tượng thao tác</typeparam>
    /// CreatedBy: TrangDTT (23/05/2023)
    public interface IBaseBL<T>
    {
        #region Method
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult GetAllRecords();

        /// <summary>
        /// Lấy thông tin bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult GetRecordById(Guid recordId);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần thêm mới</param>
        /// <returns>Kết quả gọi service</returns>
        public ServiceResult InsertRecord(T record);

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult UpdateRecord(T record);

        /// <summary>
        /// Xóa bản ghi bởi ID
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult DeleteRecordById(Guid recordId);

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Kết quả gọi dịch vụ</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        public ServiceResult GetNewCode();

        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="recordID">ID bản ghi cần kiểm tra</param>
        /// <param name="recordCode">Mã bản ghi</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool IsDuplicateCode(Guid recordID, string recordCode);
        #endregion
    }
}
