using Cukcuk.Backend.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities.DTO
{
    /// <summary>
    /// Thông tin lỗi
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class ErrorInfo
    {
        #region Property
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode ErrorCode { get; set; }
        /// <summary>
        /// Thông báo dành cho lập trình viên
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; }
        /// <summary>
        /// Thông tin thêm
        /// </summary>
        public object? MoreInfo { get; set; }
        /// <summary>
        /// Mã theo dõi
        /// </summary>
        public string? TraceId { get; set; }
        #endregion
    }
}
