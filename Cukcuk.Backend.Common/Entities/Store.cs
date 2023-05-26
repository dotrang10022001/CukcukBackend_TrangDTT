using Cukcuk.Backend.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities
{
    /// <summary>
    /// Thông tin kho
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class Store:Base
    {
        #region Property
        /// <summary>
        /// ID kho
        /// </summary>
        [Required]
        public Guid StoreID { get; set; }
        /// <summary>
        /// Mã kho
        /// </summary>
        [Required]
        public string StoreCode { get; set; }
        /// <summary>
        /// Tên kho
        /// </summary>
        [Required]
        public string StoreName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        #endregion
    }
}
