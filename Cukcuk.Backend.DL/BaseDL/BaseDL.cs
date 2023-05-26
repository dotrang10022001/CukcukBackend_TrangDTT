using Cukcuk.Backend.DL.Database;
using Dapper;
using MySqlConnector;
using System.Data;
using static Dapper.SqlMapper;

namespace Cukcuk.Backend.DL.BaseDL
{
    #region Method
    /// <summary>
    /// Thực thi giao diện data layer cơ sở
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu đối tượng thao tác</typeparam>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class BaseDL<T>: IBaseDL<T>
    {
        /// <summary>
        /// Kết nối tới database
        /// </summary>
        /// <returns>Thông tin kết nối</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public IDbConnection GetConnection()
        {
            var dbConnection = new MySqlConnection(DatabaseContext.connectionString);
            return dbConnection;
        }

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
        public T QueryFirstOrDefault(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.QueryFirstOrDefault(sql, param, transaction, commandTimeout, commandType);
        }

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
        public IEnumerable<T> Query(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

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
        public GridReader QueryMultiple(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.QueryMultiple(sql, param, transaction, commandTimeout, commandType);
        }

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
        public int Execute(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public IEnumerable<T> GetAllRecords()
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetAll";

            // 2. Kết nối tới database
            var connection = GetConnection();

            // 3. Thực thi truy vấn
            var result = Query(connection, storedProcedureName, commandType: CommandType.StoredProcedure);

            // 4. Xử lý kết quả trả về
            return result;
        }

        /// <summary>
        /// Lấy thông tin bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Thông tin bản ghi</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public virtual T GetRecordById(Guid recordId)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetById";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", recordId);

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực thi truy vấn
            var result = QueryFirstOrDefault(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 5. Xử lý kết quả trả về
            return result;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi đã thêm mới</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public int InsertRecord(T record)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = $"Proc_{typeof(T).Name}_Insert";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record);

                parameters.Add($"v_{propertyName}", propertyValue);
            }

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực thi truy vấn
            var affectedRows = Execute(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 5. Xử lý kết quả trả về
            return affectedRows;
        }

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>Số bản ghi được cập nhật</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public int UpdateRecord(T record)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = $"Proc_{typeof(T).Name}_Update";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record);

                parameters.Add($"v_{propertyName}", propertyValue);
            }

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực thi truy vấn
            var affectedRows = Execute(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 5. Xử lý kết quả trả về
            return affectedRows;
        }

        /// <summary>
        /// Xóa bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi cần xóa</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public virtual int DeleteRecordById(Guid recordId)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = $"Proc_{typeof(T).Name}_DeleteById";

            // 2. Chuẩn bị tham số
            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", recordId);

            // 3. Kết nối tới database
            var connection = GetConnection();

            // 4. Thực thi truy vấn
            var affectedRows = Execute(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 5. Xử lý kết quả trả về
            return affectedRows;
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        public string GetNewCode()
        {
            // 1. Chuẩn bị tên procedure
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetNewCode";

            // 2. Khởi tạo kết nối đến database
            var connection = GetConnection();

            // 3. Thực hiện câu lệnh sql
            var newCode = QueryMultiple(connection, storedProcedureName, commandType: CommandType.StoredProcedure).ReadFirst<string>();

            return newCode;
        }

        /// <summary>
        /// Kiểm tra trùng lặp mã
        /// </summary>
        /// <param name="recordID">ID bản ghi cần kiểm tra</param>
        /// <param name="recordCode">Mã bản ghi cần kiểm tra</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        public bool CheckDuplicateCode(Guid recordID, string recordCode)
        {
            // 1. Chuẩn bị tên thủ tục
            string storedProcedureName = $"Proc_{typeof(T).Name}_CheckDuplicateCode";

            // 2. Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", recordID);
            parameters.Add($"v_{typeof(T).Name}Code", recordCode);

            // 3. Khởi tạo kết nối đến database
            var connection = GetConnection();
            var result = QueryFirstOrDefault(connection, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // 4. Xử lý kết quả trả về
            if (result != null) return true;
            return false;
        }
        #endregion
    }
}
