using Cukcuk.Backend.Common.Attributes;
using Cukcuk.Backend.Common.Entities.DTO;
using Cukcuk.Backend.Common.Helpers;
using Cukcuk.Backend.Common.Resources;
using Cukcuk.Backend.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.BL.BaseBL
{
    /// <summary>
    /// Thực thi giao diện business layer cơ sở
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu đối tượng thao tác</typeparam>
    /// CreatedBy: TrangDTT (23/05/2023)
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field
        private readonly IBaseDL<T> _baseDL;
        #endregion

        #region Constructor
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult GetAllRecords()
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Data = _baseDL.GetAllRecords()
            };
        }

        /// <summary>
        /// Lấy thông tin bản ghi bởi id
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult GetRecordById(Guid recordId)
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Data = _baseDL.GetRecordById(recordId)
            };
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần thêm mới</param>
        /// <returns>Kết quả gọi service</returns>
        public ServiceResult InsertRecord(T record)
        {
            // 1. Validate dữ liệu
            // 1.1. Khởi tạo đối tượng chứa thông tin lỗi
            var errorInfo = new ErrorInfo
            {
                ErrorCode = Common.Enums.ErrorCode.InvalidData,
                UserMsg = new List<string>(),
                DevMsg = ResponseMessage.invalidDataDevMsg,
                MoreInfo = new List<ErrorDetail>(),
                TraceId = null
            };
            var listOfValidateErrors = new List<ErrorDetail>();

            // 1.2. Validate cho các tính chất thường
            var listOfCommonErrors = ValidateForCommonFields(record);
            if (listOfCommonErrors.Count() > 0)
            {
                listOfValidateErrors = listOfValidateErrors.Concat(listOfCommonErrors).ToList();
            }

            // 1.3. Validate cho các tính chất đặc biệt
            var listOfCustomErrors = ValidateForCustomFields(record);
            if (listOfCustomErrors.Count() > 0)
            {
                listOfValidateErrors = listOfValidateErrors.Concat(listOfCustomErrors).ToList();
            }

            // 1.4. Xử lý tất cả lỗi trả về

            if (listOfValidateErrors.Count() > 0)
            {
                errorInfo.MoreInfo = listOfValidateErrors;
                foreach (var error in listOfValidateErrors)
                {
                    errorInfo.UserMsg.Add(error.Message);
                }

                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = errorInfo
                };
            }

            // 2. Thực hiện thêm mới thông tin bản ghi
            var affectedRows = _baseDL.InsertRecord(record);

            // 3. Xử lý kết quả trả về
            return new ServiceResult
            {
                IsSuccess = true,
                Data = affectedRows
            };
        }

        /// <summary>
        /// Validate cho các tính chất thường
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần validate</param>
        /// <returns>Danh sách chi tiết lỗi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public List<ErrorDetail> ValidateForCommonFields(T record)
        {
            // 1. Khởi tạo danh sách lỗi
            var listOfErrors = new List<ErrorDetail>();

            // 2. Lấy và duyệt danh sách thuộc tính
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record);

                var listOfAttributes = property.GetCustomAttributes(true);

                var isValid = true;
                var error = "";
                for (var i = 0; i < listOfAttributes.Count(); i++)
                {
                    var attr = listOfAttributes[i];

                    // Kiểm tra tính bắt buộc
                    if (attr.GetType() == typeof(RequiredAttribute))
                    {
                        error = ValidationError.notAllowEmpty;
                        isValid = !CommonHelper.CheckEmpty((propertyValue ?? "").ToString());
                    }

                    if (!isValid)
                    {
                        var errorDetail = new ErrorDetail
                        {
                            PropertyName = propertyName,
                            Message = $"{CommonHelper.ParsePropertyName(propertyName)} " + error
                        };
                        listOfErrors.Add(errorDetail);
                        break;
                    }
                }
            }
            // 3. Trả về danh sách lỗi
            return listOfErrors;
        }

        /// <summary>
        /// Validate cho các tính chất đặc biệt
        /// </summary>
        /// <param name="record">Thông tin bản ghi cần validate</param>
        /// <returns>Danh sách chi tiết lỗi</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public virtual List<ErrorDetail> ValidateForCustomFields(T record)
        {
            return new List<ErrorDetail>();
        }


        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult UpdateRecord(T record)
        {
            // 1. Validate dữ liệu
            // 1.1. Khởi tạo đối tượng chứa thông tin lỗi
            var errorInfo = new ErrorInfo
            {
                ErrorCode = Common.Enums.ErrorCode.InvalidData,
                UserMsg = new List<string>(),
                DevMsg = ResponseMessage.invalidDataDevMsg,
                MoreInfo = new List<ErrorDetail>(),
                TraceId = null
            };
            var listOfValidateErrors = new List<ErrorDetail>();

            // 1.2. Validate cho các tính chất thường
            var listOfCommonErrors = ValidateForCommonFields(record);
            if (listOfCommonErrors.Count() > 0)
            {
                listOfValidateErrors = listOfValidateErrors.Concat(listOfCommonErrors).ToList();
            }

            // 1.3. Validate cho các tính chất đặc biệt
            var listOfCustomErrors = ValidateForCustomFields(record);
            if (listOfCustomErrors.Count() > 0)
            {
                listOfValidateErrors = listOfValidateErrors.Concat(listOfCustomErrors).ToList();
            }

            // 1.4. Xử lý tất cả lỗi trả về

            if (listOfValidateErrors.Count() > 0)
            {
                errorInfo.MoreInfo = listOfValidateErrors;
                foreach (var error in listOfValidateErrors)
                {
                    errorInfo.UserMsg.Add(error.Message);
                }

                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = errorInfo
                };
            }

            // 2. Thực hiện cập nhật thông tin bản ghi
            var affectedRows = _baseDL.UpdateRecord(record);

            // 3. Xử lý kết quả trả về
            return new ServiceResult
            {
                IsSuccess = true,
                Data = affectedRows
            };
        }

        /// <summary>
        /// Xóa bản ghi bởi ID
        /// </summary>
        /// <param name="recordId">ID bản ghi</param>
        /// <returns>Kết quả gọi service</returns>
        /// CreatedBy: TrangDTT (23/05/2023)
        public ServiceResult DeleteRecordById(Guid recordId)
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Data = _baseDL.DeleteRecordById(recordId)
            };
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Kết quả gọi dịch vụ</returns>
        /// CreatedBy: TrangDTT (24/05/2023)
        public ServiceResult GetNewCode()
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Data = _baseDL.GetNewCode()
            };
        }

        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="recordID">ID bản ghi cần kiểm tra</param>
        /// <param name="recordCode">Mã bản ghi</param>
        /// <returns>Kết quả kiểm tra</returns>
        /// CreatedBy: TrangDTT (25/05/2023)
        public bool IsDuplicateCode(Guid recordID, string recordCode)
        {
            return _baseDL.CheckDuplicateCode(recordID, recordCode);
        }
        #endregion
    }
}
