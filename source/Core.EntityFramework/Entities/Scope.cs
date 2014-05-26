using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.EntityFramework.Entities
{
    public class Scope
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Required { get; set; }
        public virtual bool Emphasize { get; set; }
        public virtual bool IsOpenIdScope { get; set; }

        public virtual ICollection<ScopeClaim> ScopeClaims { get; set; }
    }
}
