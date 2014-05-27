using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Stores;

namespace Thinktecture.IdentityServer.Core.Administration.EntityFramework
{
    public class Factory
    {
        string connectionString;
        public Factory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IClientStore CreateClientStore()
        {
            return new DisposableClientStore(connectionString);
        }

        public IScopeStore CreateScopeStore()
        {
            return new DisposableScopeStore(connectionString);
        }

        class DisposableClientStore : ClientStore, IDisposable
        {
            public DisposableClientStore(string connectionString)
                : base(new Core.EntityFramework.CoreDbContext(connectionString))
            {
            }

            public void Dispose()
            {
                db.Dispose();
            }
        }

        class DisposableScopeStore : ScopeStore, IDisposable
        {
            public DisposableScopeStore(string connectionString)
                : base(new Core.EntityFramework.CoreDbContext(connectionString))
            {
            }

            public void Dispose()
            {
                db.Dispose();
            }
        }


    }
}
