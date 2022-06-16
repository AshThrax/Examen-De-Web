using Microsoft.AspNetCore.Authorization;

namespace Api.Handler
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public HasScopeRequirement(string scope,string issuer)
        {
            Scope =scope?? throw new ArgumentNullException("scope");
            Issuer= issuer?? throw new ArgumentNullException("issuer");
        }

        public string Scope { get; }
        public string Issuer { get; }

        
    }
}
