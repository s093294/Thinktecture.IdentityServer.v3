using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.EntityFramework.Entities
{
    public class ClientScopeRestriction
    {
        public virtual int ID { get; set; }
        public virtual string Scope { get; set; }

        public virtual Client Client { get; set; }
    }
}
