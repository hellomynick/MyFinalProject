using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityStore.API.Models
{
    public record ErrorViewModel
    {
        public ErrorMessage Error { get; set; }
    }
}
