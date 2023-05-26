using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Attributes
{
    /// <summary>
    /// Thuộc tính bắt buộc
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class RequiredAttribute:ValidationAttribute
    {
        #region Method
        /// <summary>
        /// Xác định tính hợp lệ của thuộc tính
        /// </summary>
        /// <param name="value">Giá trị cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra(Hợp lệ/Không hợp lệ)</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public override bool IsValid(object? value)
        {
            return true;
        }
        #endregion
    }
}
