using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Models;

namespace Thinktecture.IdentityServer.Core.Administration.Services
{
    public interface IScopeService
    {
        IEnumerable<Scope> Query(string filter);
    }
}
