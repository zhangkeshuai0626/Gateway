using Common.Extension;
using Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Login : DbBaseModel
    {
        [Required(ErrorMessage = "员工主键不能为空"), MaxLength(50)]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "员工登录帐号不能为空"), MaxLength(20, ErrorMessage = "登录帐号不能超过20个字符")]
        [Unique(TableName = "t_login", ColumnName = "LoginAccount", ErrorMessage = "帐号不能重复")]
        public string LoginAccount { get; set; }

        [Required(ErrorMessage = "员工登录密码不能为空"), MaxLength(50)]
        [Unique(TableName = "t_login", ColumnName = "LoginAccount", ErrorMessage = "帐号不能重复")]
        public string LoginPassword { get; set; }
        /// <summary>
        /// 登录邮箱
        /// </summary>
        [Required, RegularExpression(Regular.Email, ErrorMessage = "邮箱格式不合法")]
        public string Email { get; set; }
        /// <summary>
        /// 盐
        /// </summary>
        [MaxLength(10)]
        public string Salt { get; set; }
    }
}
