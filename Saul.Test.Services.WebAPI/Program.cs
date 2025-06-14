﻿using Asp.Versioning.ApiExplorer;
using HealthChecks.UI.Client;
using Saul.Test.Application.UseCases;
using Saul.Test.Infrastructure;
using Saul.Test.Persistence;
using Saul.Test.Services.WebAPI.Modules.Authentication;
using Saul.Test.Services.WebAPI.Modules.Feature;
using Saul.Test.Services.WebAPI.Modules.HealthCheck;
using Saul.Test.Services.WebAPI.Modules.Injection;
using Saul.Test.Services.WebAPI.Modules.Middleware;
using Saul.Test.Services.WebAPI.Modules.RateLimiter;
using Saul.Test.Services.WebAPI.Modules.Redis;
using Saul.Test.Services.WebAPI.Modules.Swagger;
using Saul.Test.Services.WebAPI.Modules.Versioning;

string myPolicy = "policySaulTest";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFeature(builder.Configuration, myPolicy);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);
builder.WebHost.UseWebRoot("wwwroot");

var app = builder.Build();

app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });

    app.UseReDoc(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.DocumentTitle = "Saul Test API";
            options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
        }
    });
}


app.UseHttpsRedirection();
app.UseCors(myPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseRequestTimeouts();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.AddMiddleware();

app.Run();

public partial class Program { };