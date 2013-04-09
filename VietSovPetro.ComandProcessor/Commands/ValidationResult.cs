using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietSovPetro.ComandProcessor.Commands
{
    public class ValidationResult
    {
        public string MemberName { get; set; }
        public string Message { get; set; }
        public ValidationResult(string memberName, string message)
        {
            this.MemberName = memberName;
            this.Message = message;
        }
        public ValidationResult(string message)
        {
            this.Message = message;
        }
        public ValidationResult() { }
    }
}
