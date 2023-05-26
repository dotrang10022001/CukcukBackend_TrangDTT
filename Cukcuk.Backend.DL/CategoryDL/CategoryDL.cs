using Cukcuk.Backend.Common.Entities;
using Cukcuk.Backend.DL.BaseDL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukcuk.Backend.DL.CategoryDL
{
    /// <summary>
    /// Thực thi giao diện data layer nhóm nguyên vật liệu
    /// </summary>
    /// CreatedBy: TrangDTT (24/05/2023)
    public class CategoryDL:BaseDL<Category>, ICategoryDL
    {
    }
}
