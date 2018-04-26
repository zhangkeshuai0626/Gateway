using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class DepartmentJob : DbBaseModel
    {
        [Required, MaxLength(50)]
        public string DepartmentId { get; set; }
        [Required, MaxLength(50)]
        public string JobId { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
