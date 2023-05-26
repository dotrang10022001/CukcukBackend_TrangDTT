using Cukcuk.Backend.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities
{
    /// <summary>
    /// Thông tin nhóm nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class Category : Base
    {
        /// <summary>
        /// ID nhóm nguyên vật liệu
        /// </summary>
        [Required]
        public Guid CategoryID { get; set; }
        /// <summary>
        /// Mã nhóm nguyên vật liệu
        /// </summary>
        [Required]
        public string CategoryCode { get; set; }
        /// <summary>
        /// Tên nhóm nguyên vật liệu
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
        /// <summary>
        /// ID nhóm nguyên vật liệu cha
        /// </summary>
        public Guid? ParentCategoryID { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }
    }
}
