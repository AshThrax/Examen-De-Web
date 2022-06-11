using Api;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration=builder.Configuration;
builder.Services.AddDependence(configuration);
var app = builder.Build();
//authenticatepart
builder.Services.AddAuthentication(option => {
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect("Auth0", option =>
{
    option.Authority = $"https://{configuration["Auth0:Domain"]}";
    option.ClientId = configuration["Auth0:ClientId"];
    option.ClientSecret = configuration["Auth0:ClientSecret"];
    option.ResponseType = OpenIdConnectResponseType.Code;
    option.Scope.Clear();
    option.Scope.Add("openid");
    option.Scope.Add("profile");
    option.Scope.Add("email");
    option.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name"
    };
    option.CallbackPath = new PathString("/callback");
    option.ClaimsIssuer = "Auth0";

    option.SaveTokens = true;

    option.Events = new Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents
    {
        OnRedirectToIdentityProviderForSignOut = (context) =>
        {
            var logoutUri = $"https://{configuration["Auth0:Domain"]}/v2/logout?client_id={configuration["Auth0:ClientId"]}";
            var postLogoutUri = context.Properties.RedirectUri;
            if (!string.IsNullOrEmpty(postLogoutUri))
            {
                if (postLogoutUri.StartsWith("/"))
                {
                    var request = context.Request;
                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                }
                logoutUri += $"&returnTo{Uri.EscapeDataString(postLogoutUri)}";
            }
            context.Response.Redirect(logoutUri);
            context.HandleResponse();
            return Task.CompletedTask;
        }
    };
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
