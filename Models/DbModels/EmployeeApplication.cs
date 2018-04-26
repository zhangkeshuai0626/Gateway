using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class EmployeeApplication : DbBaseModel
    {
        [Required,MaxLength(50)]
        public string EmployeeId { get; set; }
        [Required, MaxLength(50)]
        public string ApplicationId { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
