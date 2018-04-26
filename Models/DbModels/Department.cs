using Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Department : DbBaseModel

    {
        [Required(ErrorMessage = "部门Id不能为空"), MaxLength(50)]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [Required(ErrorMessage = "部门编号不能为空"), MaxLength(200)]
        [Unique(TableName = "t_department", ErrorMessage = "部门编号不能重复", ColumnName = "DepartmentCode")]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 部门顺序
        /// </summary>
        [Required(ErrorMessage = "部门顺序不能为空")]
        public int Sort { get; set; }

        [Required(ErrorMessage = "部门DepartmentName不能为空"), MaxLength(50)]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        [MaxLength(50)]
        public string ParentId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(200)]
        public string Icon { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
