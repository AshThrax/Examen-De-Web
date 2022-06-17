using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Api.Policies;
using Api;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
ConfigurationManager configuration = builder.Configuration;


// Add services to the container.
var domain = configuration["Auth0:Domain"];
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Projet Examen",
        Version = "v1",
        Description = "Clean architecture build in .net6 set up for Examination",
        TermsOfService =new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Quentin Courcelles",
            Email = string.Empty,
            Url= new Uri("https://github.com/explore"),
        }, 
        License= new OpenApiLicense 
        { 
            Name="Ephec Licence Maybe",
            Url=new Uri("https://example.com/license"),
        }
    }); 
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddDependence(configuration);

//auth0 Api authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = configuration["Auth0:ApiIdentifier"];
   
});
builder.Services.AddAuthorization(options => 
{
    options.AddPolicy(AddPolicies.Admin, policy => policy.RequireClaim("https://film.com/roles","Admin"));
    options.AddPolicy(AddPolicies.Moderateur, policy => policy.RequireClaim("https://film.com/roles", "Moderator")); 
    options.AddPolicy(AddPolicies.User, policy => policy.RequireClaim("https://film.com/roles", "User"));
    options.AddPolicy(AddPolicies.Guest, policy => policy.RequireClaim("https://film.com/roles", "Guest"));
});

builder.Services.AddMvc(options => 
{
    options.Filters.Add(new ApiExceptionFilterAttribute());
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
    options.ReturnHttpNotAcceptable = true;
}).AddFluentValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
