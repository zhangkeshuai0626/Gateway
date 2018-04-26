using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validator
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DomainAttribute : ValidationAttribute
    {
        public IEnumerable<string> Values { get; private set; }
        public DomainAttribute(params string[] value)
        {
            if (null == value)
            {
                this.Values = new string[0];
            }
            else if (value.Length == 1)
            {
                this.Values = new string[] { value[0] };
            }
        }
        public override bool IsValid(object value)
        {
            if (null == value)
            {
                return true;
            }
            return this.Values.Any(item => value.ToString() == item);
        }
    }
}
