/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license
 */

using System.ComponentModel.DataAnnotations;
namespace Thinktecture.IdentityServer.Core.Models
{
    public class ScopeClaim
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AlwaysIncludeInIdToken { get; set; }
    }
}