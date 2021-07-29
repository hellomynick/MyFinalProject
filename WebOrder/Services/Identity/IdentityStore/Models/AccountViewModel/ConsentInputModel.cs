using System.Collections.Generic;

namespace IdentityStore.API.Models.AccountViewModel
{
    public record ConsentInputModel
    {
        public string Button { get; init; }
        public IEnumerable<string> ScopesConsented { get; init; }
        public bool RememberConsent { get; init; }
        public string ReturnUrl { get; init; }
    }
}
