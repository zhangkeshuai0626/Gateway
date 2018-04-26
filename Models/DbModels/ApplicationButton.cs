using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class ApplicationButton : DbBaseModel
    {
        /// <summary>
        /// 所属的页面Id
        /// </summary>
        [Required, MaxLength(50)]
        public string ApplicationId { get; set; }
        /// <summary>
        /// 按钮Id
        /// </summary>
        [Required, MaxLength(50)]
        public string ButtonId { get; set; }
        /// <summary>
        /// 处理程序Id
        /// </summary>
        [MaxLength(50)]
        public string HandlerApplicationId { get; set; }
        /// <summary>
        /// 标签的其他属性
        /// </summary>
        public string Attr { get; set; }
        /// <summary>
        /// 按钮位置 
        /// </summary>
        public int ButtonPosition { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
