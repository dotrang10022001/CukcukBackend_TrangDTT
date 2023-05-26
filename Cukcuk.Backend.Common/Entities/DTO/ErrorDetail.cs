using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities.DTO
{
    /// <summary>
    /// Chi tiết lỗi
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class ErrorDetail
    {
        #region Property
        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string Message { get; set; }
        #endregion
    }
}
