using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Models;

namespace Thinktecture.IdentityServer.Core.Administration.Validation
{
    public class ClientValidator
    {
        public ValidationResult Validate(Client client)
        {
            return ValidationResult.SuccessResult;
        }
    }
}
