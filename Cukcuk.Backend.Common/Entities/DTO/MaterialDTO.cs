using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities.DTO
{
    /// <summary>
    /// Thông tin nguyên vật liệu, có kèm theo danh sách đơn vị chuyển đổi tương ứng
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class MaterialDTO
    {
        /// <summary>
        /// Thông tin nguyên vật liệu
        /// </summary>
        public Material Material { get; set; }
        /// <summary>
        /// Danh sách đơn vị chuyển đổi
        /// </summary>
        public List<Conversion> ListOfConversions { get; set; }
    }
}
