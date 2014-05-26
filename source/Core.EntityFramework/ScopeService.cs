using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Services;

namespace Thinktecture.IdentityServer.Core.EntityFramework
{
    public class ScopeService : IScopeService
    {
        protected CoreDbContext db;

        public ScopeService(CoreDbContext db)
        {
            this.db = db;
        }

        public Task<IEnumerable<Models.Scope>> GetScopesAsync()
        {
            var scopes = db.Scopes
                .Include("ScopeClaims")
                .ToArray();
            var models = scopes.Select(x => x.ToModel());
            return Task.FromResult(models);
        }
    }
}
