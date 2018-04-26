using Common.Extension;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models.DbModels
{
    [Table("Employee")]
    public class Employee : DbBaseModel
    {
        [Required(ErrorMessage = "员工主键不能为空"), MaxLength(50)]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "员工编号不能为空"), MaxLength(50)]
        public string EmployeeNo { get; set; }

       
        
        [Required(ErrorMessage = "员工姓名不能为空"), MaxLength(50)]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "性别不能为空")]
        public int Sex { get; set; }

        [Required(ErrorMessage = "部门Id不能为空"), MaxLength(50)]
        public string DepartmentId { get; set; }

        [Required(ErrorMessage = "职务Id不能为空"), MaxLength(50)]
        public string RoleId { get; set; }


        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [MaxLength(200)]
        public string EmployeeAddress { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
