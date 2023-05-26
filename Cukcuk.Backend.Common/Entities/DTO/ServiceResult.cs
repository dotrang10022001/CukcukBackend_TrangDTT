using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities.DTO
{
    /// <summary>
    /// Kết quả gọi dịch vụ
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class ServiceResult
    {
        #region Property
        /// <summary>
        /// Thành công hay thất bại
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Thông tin lỗi nếu thất bại, dữ liệu trả về nếu thành công
        /// </summary>
        public object? Data { get; set; }
        #endregion
    }
}
