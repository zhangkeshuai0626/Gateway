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
    public class Job : DbBaseModel
    {

        [Required(ErrorMessage = "职务Id不能为空"), MaxLength(50)]
        public string JobId { get; set; }

        [Required(ErrorMessage = "职务名称不能为空"), MaxLength(50)]
        public string JobName { get; set; }
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
