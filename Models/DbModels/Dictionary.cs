using Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{

    public class Dictionary : DbBaseModel
    {
        /// <summary>
        /// 数据类型Id
        /// </summary>
        [Display(Name = "数据类型Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "数据Id不能为空"), MaxLength(50)]
        [Unique(ColumnName = "DictionaryId", ErrorMessage = "数据Id不能重复", TableName = "T_Dictionary")]
        public string DictionaryId { get; set; }
        /// <summary>
        /// 数据类型Id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "数据类型Id不能为空"), MaxLength(50)]
        [Unique(ColumnName = "DictionaryTypeId", ErrorMessage = "数据类型不能重复", TableName = "T_Dictionary")]
        public string DictionaryTypeId { get; set; }
        /// <summary>
        /// 变量类型
        /// </summary>
        [Required(ErrorMessage = "变量名称不能为空"), MaxLength(50)]
        [Unique(ColumnName = "VarName", ErrorMessage = "数据名称重复", TableName = "T_Dictionary")]
        public string VarName { get; set; }
        /// <summary>
        /// 变量值
        /// </summary>
        [Required]
        public int VarValue { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
