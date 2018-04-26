using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Log : DbBaseModel
    {
        [Required, MaxLength(50)]
        public string LogId { get; set; }
        [Required]
        public int LogType { get; set; }
        [Required, MaxLength(200)]
        public string LogContent { get; set; }
        [MaxLength(50)]
        public string Ip { get; set; }
        [MaxLength(200)]
        public string UserAgent { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
