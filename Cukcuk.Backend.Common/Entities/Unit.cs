using Cukcuk.Backend.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities
{
    /// <summary>
    /// Bảng thông tin đơn vị
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class Unit:Base
    {
        #region Property
        /// <summary>
        /// ID đơn vị
        /// </summary>
        [Required]
        public Guid UnitID { get; set; }
        /// <summary>
        /// Tên đơn vị
        /// </summary>
        [Required]
        public string UnitName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }
        #endregion
    }
}
