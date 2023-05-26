using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Resources
{
    /// <summary>
    /// Lỗi validate dữ liệu
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class ValidationError
    {
        /// <summary>
        /// Lỗi dữ liệu trống
        /// </summary>
        public static readonly string notAllowEmpty = "không được phép bỏ trống";

        /// <summary>
        /// Lỗi không đúng định dạng
        /// </summary>
        public static readonly string incorrectFormat = "không đúng định dạng";

        /// <summary>
        /// Lỗi trùng mã
        /// </summary>
        public static readonly string duplicateCode = "đã tồn tại";
    }
}
