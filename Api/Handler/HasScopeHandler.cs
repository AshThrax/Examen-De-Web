using Microsoft.AspNetCore.Authorization;

namespace Api.Handler
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            var response = context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer);

            if(!response)
                return Task.CompletedTask;

            var scope = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

            if (scope.Any(s =>s==requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
