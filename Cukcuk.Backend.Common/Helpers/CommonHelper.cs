using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Helpers
{
    /// <summary>
    /// Tiện ích chung
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class CommonHelper
    {
        /// <summary>
        /// Kiểm tra chuỗi trống
        /// </summary>
        /// <param name="str">Chuỗi cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra: true/false</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public static bool CheckEmpty(string? str)
        {
            if (String.IsNullOrEmpty(str) || (str == Guid.Empty.ToString())) return true;
            return false;
        }

        /// <summary>
        /// Chuyển đổi tên thuộc tính để hiển thị cho người dùng
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính</param>
        /// <returns>Chuỗi sau khi chuyển đổi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public static string ParsePropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "CategoryCode":
                    return "Mã nhóm nguyên vật liệu";
                case "CategoryName":
                    return "Tên nhóm nguyên vật liệu";
                case "StoreCode":
                    return "Mã kho";
                case "StoreName":
                    return "Tên kho";
                case "UnitName":
                    return "Tên đơn vị";

                default:
                    return "";
            }
        }
    }
}
