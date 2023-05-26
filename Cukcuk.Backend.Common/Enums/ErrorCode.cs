using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Enums
{
    /// <summary>
    /// Mã lỗi sử dụng cho lập trình viên
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public enum ErrorCode
    {
        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        InvalidData = 1,
        /// <summary>
        /// Ngoại lệ xảy ra
        /// </summary>
        Exception = 2,
        /// <summary>
        /// Không tìm thấy
        /// </summary>
        NotFound = 3
    }
}
