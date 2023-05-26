using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Enums
{
    /// <summary>
    /// Tính chất nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public enum MaterialProperty
    {
        /// <summary>
        /// Nguyên vật liệu
        /// </summary>
        Material = 0,
        /// <summary>
        /// Đồ uống đóng chai
        /// </summary>
        BottledDrink = 1,
        /// <summary>
        /// Mặt hàng khác
        /// </summary>
        OtherItem = 2,
        /// <summary>
        /// Bán thành phẩm
        /// </summary>
        SemiFinishedProduct = 3
    }
}
