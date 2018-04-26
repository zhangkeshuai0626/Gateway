using Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class DictionaryType : DbBaseModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "数据类型Id不能为空"), MaxLength(50)]
        [Unique(ColumnName = "DictionaryTypeId", ErrorMessage = "数据类型Id不能重复", TableName = "T_DictionaryType")]
        public string DictionaryTypeId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "数据类型名称不能为空"), MaxLength(50)]
        [Unique(ColumnName = "DictionaryTypeName", ErrorMessage = "数据类型名称不能重复", TableName = "T_DictionaryType")]
        public string DictionaryTypeName { get; set; }

    }
}
