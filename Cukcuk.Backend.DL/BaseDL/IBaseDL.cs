using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Cukcuk.Backend.DL.BaseDL
{
    #region Method
    /// <summary>
    /// Giao diện data layer cơ sở
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu đối tượng thao tác</typeparam>
    /// CreatedBy: TrangDTT (23/05/2023)
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Kết nối tới database
        /// </summary>
        /// <returns>Thông tin kết nối</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public IDbConnection GetConnection();

        /// <summary>
        /// Thực hiện truy vấn/thủ tục tới database
        /// </summary>
        /// <param name="cnn">Kết nối</param>
        /// <param name="sql">Câu truy vấn/tên thủ tục</param>
        /// <param name="param">Tham số truyền vào</param>
        /// <param name="transaction">Giao dịch</param>
        /// <param name="commandTimeout">Timeout cho truy vấn/thủ tục</param>
        /// <param name="commandType">Loại: text, stored procedure</param>
        /// <returns>Thông tin đối tượng cần truy vấn</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public T QueryFirstOrDefault(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <param name="cnn">Kết nối tới database</param>
        /// <param name="sql">Truy vấn/Tên thủ tục</param>
        /// <param name="param">Tham số truyền vào</param>
        /// <param name="transaction">Giao dịch</param>
        /// <param name="buffered">Đệm dữ liệu</param>
        /// <param name="commandTimeout">Timeout cho truy vấn/thủ tục</param>
        /// <param name="commandType">Loại truy vấn</param>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public IEnumerable<T> Query(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Truy vấn cho một tập kết quả
        /// </summary>
        /// <param name="cnn">Kết nối tới database</param>
        /// <param name="sql">Truy vấn/Tên thủ tục</param>
        /// <param name="param">Tham số truyền vào</param>
        /// <param name="transaction">Giao dịch sử dụng</param>
        /// <param name="commandTimeout">Timeout cho truy vấn</param>
        /// <param name="commandType">Loại command: thủ tục, lệnh text, ...</param>
        /// <returns></returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public GridReader QueryMultiple(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Thực thi truy vấn/thủ tục
        /// </summary>
        /// <param name="cnn">Kết nối tới database</param>
        /// <param name="sql">Truy vấn/tên thủ tục</param>
        /// <param name="param">Tham số truyền vào</param>
        /// <param name="transaction">Giao dịch sử dụng</param>
        /// <param name="commandTimeout">Timeout cho truy vấn/thủ tục</param>
        /// <param name="commandType">Loại: truy vấn, thủ tục, ...</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: TrangDTT (25/03/2023)
        public int Execute(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Lấy thông tin bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Thông tin bản ghi</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public T GetRecordById(Guid recordId);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi đã thêm mới</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public int InsertRecord(T record);
        
        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>Số bản ghi được cập nhật</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public int UpdateRecord(T record);

        /// <summary>
        /// Xóa bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi cần xóa</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public int DeleteRecordById(Guid recordId);

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        public string GetNewCode();

        /// <summary>
        /// Kiểm tra trùng lặp mã
        /// </summary>
        /// <param name="recordID">ID bản ghi cần kiểm tra</param>
        /// <param name="recordCode">Mã bản ghi cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool CheckDuplicateCode(Guid recordID, string recordCode);
        #endregion
    }
}
