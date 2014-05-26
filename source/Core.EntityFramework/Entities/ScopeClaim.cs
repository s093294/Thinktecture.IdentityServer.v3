using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.EntityFramework.Entities
{
    public class ScopeClaim
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool AlwaysIncludeInIdToken { get; set; }

        public virtual Scope Scope { get; set; }
    }
}
