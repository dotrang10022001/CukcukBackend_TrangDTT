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
    /// Thông tin đơn vị chuyển đổi
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class Conversion:Base
    {
        #region Property
        /// <summary>
        /// ID chuyển đổi
        /// </summary>
        [Required]
        public Guid ConversionID { get; set; }
        /// <summary>
        /// ID đơn vị
        /// </summary>
        [Required]
        public Guid UnitID { get; set; }
        /// <summary>
        /// Tỉ lệ chuyển đổi
        /// </summary>
        [Required]
        public decimal ConversionRate { get; set; }
        /// <summary>
        /// Phép tính
        /// </summary>
        [Required]
        public Calculator Calculator { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Là đơn vị bán
        /// </summary>
        public bool? IsVendor { get; set; }
        #endregion
    }
}
