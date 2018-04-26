using Common.Utils;
using Models.AppModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Models.DbModels
{
    /// <summary>
    /// 数据库模型基类,提供公有的属性
    /// </summary>
    public abstract class DbBaseModel : IValidatableObject
    {
        public DbBaseModel()
        {
            LoginSessionModel user = SessionHelper.Get(Enumer.Session.LoginInfo) as LoginSessionModel;
            if (user == null)
            {
                this.CreateBy = "";
            }
            else
            {
                this.CreateBy = user.Employee.EmployeeId;
            }
            this.CreateTime = DateTime.Now;
            this.Enable = true;

        }
        protected DbContext Db = DbFactory.CreateDbContext();
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键ID")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [Display(Name = "是否启用")]
        [Required(ErrorMessage = "Enable字段不能为空")]
        public bool Enable { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人Id")]
        [Required(ErrorMessage = "创建人不能为空"), MaxLength(50)]
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime CreateTime { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Display(Name = "最后修改人")]
        public string LastModifyBy { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display(Name = "最后修改时间")]
        public DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonIgnoreAttribute]
        public string Remark { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Timestamp, JsonIgnoreAttribute]
        public byte[] Version { get; set; }

        /// <summary>
        /// 模型验证的方法
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
