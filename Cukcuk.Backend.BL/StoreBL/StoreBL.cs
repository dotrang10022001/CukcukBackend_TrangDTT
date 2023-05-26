using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Helpers;
using Cukcuk.Backend.Common.Resources;
using Cukcuk.Backend.DL.BaseDL;
using Cukcuk.Backend.DL.StoreDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.StoreBL
{
    /// <summary>
    /// Thực thi giao diện business layer kho
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class StoreBL: BaseBL<Store>, IStoreBL
    {
        #region Field
        private readonly IStoreDL _storeDL;
        #endregion

        #region Constructor
        public StoreBL(IStoreDL storeDL): base(storeDL)
        {
            _storeDL = storeDL;
        }
        #endregion

        #region Method
        /// <summary>
        /// Validate cho các tính chất đặc biệt
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần validate</param>
        /// <returns>Danh sách chi tiết lỗi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public override List<ErrorDetail> ValidateForCustomFields(Store record)
        {
            // 1. Khởi tạo danh sách lỗi
            var listOfErrors = new List<ErrorDetail>();

            // 2. Kiểm tra mã nhóm nguyên vật liệu
            var message = "";
            if (!IsCorrectFormat(record.StoreCode))
            {
                // Không đúng định dạng
                message = $"{CommonHelper.ParsePropertyName("StoreCode")} " + ValidationError.incorrectFormat;
            }
            else
            {
                // Đúng định dạng, kiểm tra trùng lặp mã
                if (IsDuplicateCode(record.StoreID, record.StoreCode))
                {
                    message = $"{CommonHelper.ParsePropertyName("StoreCode")} " + record.StoreCode + " " + ValidationError.duplicateCode;
                }
            }

            if (message != "")
            {
                listOfErrors.Add(new ErrorDetail
                {
                    PropertyName = "StoreCode",
                    Message = message
                });
            }

            return listOfErrors;
        }

        /// <summary>
        /// Kiểm tra định dạng mã kho: Bắt đầu S- và kết thúc bằng chuỗi số
        /// </summary>
        /// <param name="storeCode">Mã nhóm nguyên vật liệu</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool IsCorrectFormat(string? storeCode)
        {
            // Không kiểm tra định dạng khi mã kho trống
            if (storeCode == "" || storeCode == null) return true;

            if (storeCode.StartsWith("S-"))
            {
                var str = storeCode.Substring(2);
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
