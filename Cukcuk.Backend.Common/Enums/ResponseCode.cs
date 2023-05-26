using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Enums
{
    /// <summary>
    /// Mã lỗi khi gọi API
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Lỗi server
        /// </summary>
        ServerError = 500,
        /// <summary>
        /// Yêu cầu tồi
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// Không tìm thấy
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Đã tạo
        /// </summary>
        Created = 201,
    }
}
