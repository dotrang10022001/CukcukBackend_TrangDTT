using Cukcuk.Backend.Common.Attributes;
using Cukcuk.Backend.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities
{
    /// <summary>
    /// Thông tin nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class Material:Base
    {
        #region Property
        /// <summary>
        /// ID nguyên vật liệu
        /// </summary>
        [Required]
        public Guid MaterialID { get; set; }
        /// <summary>
        /// Mã nguyên vật liệu
        /// </summary>
        [Required]
        public string MaterialCode { get; set; }
        /// <summary>
        /// Tên nguyên vật liệu
        /// </summary>
        [Required]
        public string MaterialName { get; set; }
        /// <summary>
        /// Tính chất
        /// </summary>
        [Required]
        public MaterialProperty Property { get; set; }
        /// <summary>
        /// ID đơn vị
        /// </summary>
        [Required]
        public Guid UnitID { get; set; }
        /// <summary>
        /// ID nhóm nguyên vật liệu
        /// </summary>
        public Guid? CategoryID { get; set; }
        /// <summary>
        /// ID kho
        /// </summary>
        public Guid? StoreID { get; set; }
        /// <summary>
        /// Lượng tồn kho tối thiểu
        /// </summary>
        public decimal? MiniQuantity { get; set; }
        /// <summary>
        /// Giá trị thời hạn
        /// </summary>
        public int? ExpireValue { get; set; }
        /// <summary>
        /// Đơn vị thời hạn
        /// </summary>
        public ExpireUnit? ExpireUnit { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// Ngưng sử dụng
        /// </summary>
        public bool? IsStopUsing { get; set; }
        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string? UnitName { get; set; }
        /// <summary>
        /// Tên nhóm nguyên vật liệu
        /// </summary>
        public string? CategoryName { get; set; }
        #endregion
    }
}
