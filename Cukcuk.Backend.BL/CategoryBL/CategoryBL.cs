using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Helpers;
using Cukcuk.Backend.Common.Resources;
using Cukcuk.Backend.DL.BaseDL;
using Cukcuk.Backend.DL.CategoryDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.CategoryBL
{
    /// <summary>
    /// Thực thi giao diện business layer nhóm nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class CategoryBL: BaseBL<Category>, ICategoryBL
    {
        #region Field
        private readonly ICategoryDL _categoryDL;
        #endregion

        #region Constructor
        public CategoryBL(ICategoryDL categoryDL): base(categoryDL)
        {
            _categoryDL = categoryDL;
        }
        #endregion

        #region Method

        /// <summary>
        /// Validate cho các tính chất đặc biệt
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần validate</param>
        /// <returns>Danh sách chi tiết lỗi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public override List<ErrorDetail> ValidateForCustomFields(Category record)
        {
            // 1. Khởi tạo danh sách lỗi
            var listOfErrors = new List<ErrorDetail>();

            // 2. Kiểm tra mã nhóm nguyên vật liệu
            var message = "";
            if (!IsCorrectFormat(record.CategoryCode))
            {
                // Không đúng định dạng
                message = $"{CommonHelper.ParsePropertyName("CategoryCode")} " + ValidationError.incorrectFormat;
            }
            else
            {
                // Đúng định dạng, kiểm tra trùng lặp mã
                if (IsDuplicateCode(record.CategoryID, record.CategoryCode))
                {
                    message = $"{CommonHelper.ParsePropertyName("CategoryCode")} " + record.CategoryCode + " " + ValidationError.duplicateCode;
                }
            }

            if (message != "")
            {
                listOfErrors.Add(new ErrorDetail
                {
                    PropertyName = "CategoryCode",
                    Message = message
                });
            }

            return listOfErrors;
        }

        /// <summary>
        /// Kiểm tra định dạng mã nhóm nguyên vật liệu: Bắt đầu C- và kết thúc bằng chuỗi số
        /// </summary>
        /// <param name="categoryCode">Mã nhóm nguyên vật liệu</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool IsCorrectFormat(string? categoryCode)
        {
            // Không kiểm tra định dạng khi mã nhóm nguyên vật liệu trống
            if (categoryCode == "" || categoryCode == null) return true;

            if (categoryCode.StartsWith("C-"))
            {
                var str = categoryCode.Substring(2);
                if (String.IsNullOrEmpty(str)) return false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] > '9' || str[i] < '0') return false;
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
