using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.Common.Entities.DTO
{
    /// <summary>
    /// Kết quả phân trang
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu đối tượng</typeparam>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class PagingResult<T>
    {
        #region Property
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public List<T>? Data { get; set; }
        /// <summary>
        /// Số bản ghi trả về
        /// </summary>
        public int NumberRecords { get; set; }
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecords { get; set; }
        #endregion
    }
}
