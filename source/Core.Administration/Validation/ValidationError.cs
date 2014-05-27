using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.Administration.Validation
{
    public class ValidationResult
    {
        public static readonly ValidationResult SuccessResult = new ValidationResult();

        public bool Success
        {
            get
            {
                return Errors == null || !Errors.Any();
            }
        }

        public ValidationMessage[] Errors { get; set; }
    }

    public class ValidationMessage
    {
        public string Message { get; set; }
    }

    public class FieldValidationMessage : ValidationMessage
    {
        public string Field { get; set; }
    }
}
