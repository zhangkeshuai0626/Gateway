using Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    /// <summary>
    /// 职务表
    /// </summary>
    public class Role : DbBaseModel
    {

        [Required(ErrorMessage = "职务Id不能为空"), MaxLength(50)]
        public string RoleId { get; set; }

        [Required(ErrorMessage = "职务名称不能为空"), MaxLength(50)]
        public string RoleName { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        [Required(ErrorMessage = "部门编号不能为空"), MaxLength(200)]
        [Unique(TableName = "t_role", ErrorMessage = "部门编号不能重复", ColumnName = "RoleCode")]
        public string RoleCode { get; set; }
        /// <summary>
        /// 部门顺序
        /// </summary>
        [Required(ErrorMessage = "部门顺序不能为空")]
        public int Sort { get; set; }
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
