using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Resources
{
    /// <summary>
    /// Thông báo lỗi khi gọi API
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class ResponseMessage
    {
        /// <summary>
        /// Thông báo người dùng khi ngoại lệ xảy ra
        /// </summary>
        public static readonly string exceptionUserMsg = "Ngoại lệ xảy ra. Vui lòng liên hệ trung tâm tư vấn để được hỗ trợ!";
        /// <summary>
        /// Thông báo cho lập trình viên khi dữ liệu không hợp lệ
        /// </summary>
        public static readonly string invalidDataDevMsg = "Invalid data";
    }
}
