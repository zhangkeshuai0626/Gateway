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
        [Required(ErrorMessage = "部门DepartmentId不能为空"),MaxLength(50)]
        public string DepartmentId { get; set; }
        [Required(ErrorMessage = "部门类型不能为空")]
        public int DepartmentType { get; set; }



        [Required(ErrorMessage = "部门DepartmentName不能为空"), MaxLength(50)]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "父节点不能为空"), MaxLength(50)]
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
