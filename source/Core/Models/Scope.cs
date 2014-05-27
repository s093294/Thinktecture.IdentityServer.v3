/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Thinktecture.IdentityServer.Core.Models
{
    public class Scope
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool IsOpenIdScope { get; set; }
        public IEnumerable<ScopeClaim> Claims { get; set; }
    }
}