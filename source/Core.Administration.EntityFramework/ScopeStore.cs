using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Stores;
using Thinktecture.IdentityServer.Core.EntityFramework;

namespace Thinktecture.IdentityServer.Core.Administration.EntityFramework
{
    public class ScopeStore : IScopeStore
    {
        protected CoreDbContext db;

        public ScopeStore(CoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Core.Models.Scope> Query(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
