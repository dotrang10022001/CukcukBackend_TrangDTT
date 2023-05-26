using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities
{
    /// <summary>
    /// Bảng thông tin dùng chung
    /// </summary>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class Base
    {
        #region Property
        /// <summary>
        /// ID người tạo
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// ID người sửa đổi gần nhất
        /// </summary>
        public Guid? ModifiedBy { get; set; }
        /// <summary>
        /// Thời gian sửa đổi gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
