using Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Application : DbBaseModel
    {
        [Required, MaxLength(50), Display(Name = "应用程序Id")]
        public string ApplicationId { get; set; }
        [Required, MaxLength(50), Display(Name = "应用程序名称")]
        public string ApplicationName { get; set; }

        [Required, MaxLength(50), Display(Name = "应用程序编号")]
        [Unique(TableName = "t_application", ColumnName = "ApplicationCode", ErrorMessage = "应用程序编号不能为空")]
        public string ApplicationCode { get; set; }
        [Required,  Display(Name = "应用程序顺序")]
        public int Sort { get; set; }

        [Required, Display(Name = "应用程序类型")]
        public int ApplicationType { get; set; }
        [Required, MaxLength(50), Display(Name = "所属程序ID")]
        public string ParentId { get; set; }
        [MaxLength(200), Display(Name = "图标")]
        public string Icon { get; set; }
        [MaxLength(2000), Display(Name = "链接地址")]
        public string Url { get; set; }
        [MaxLength(50), Display(Name = "路由Action名称")]
        public string ActionName { get; set; }
        [MaxLength(50), Display(Name = "控制器名称")]
        public string ControllerName { get; set; }

        [Display(Name = "请求方式")]
        public int Method { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
