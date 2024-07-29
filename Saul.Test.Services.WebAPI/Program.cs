using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Saul.Test.Services.WebAPI.Modules.Authentication;
using Saul.Test.Services.WebAPI.Modules.Feature;
using Saul.Test.Services.WebAPI.Modules.HealthCheck;
using Saul.Test.Services.WebAPI.Modules.Injection;
using Saul.Test.Services.WebAPI.Modules.Mapper;
using Saul.Test.Services.WebAPI.Modules.Redis;
using Saul.Test.Services.WebAPI.Modules.Swagger;
using Saul.Test.Services.WebAPI.Modules.Validator;
using Saul.Test.Services.WebAPI.Modules.Versioning;
using Saul.Test.Services.WebAPI.Modules.Watch;
using WatchDog;

string myPolicy = "policySaulTest";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration, myPolicy);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDogLog(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }

    });
}

app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors(myPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});

app.Run();

public partial class Program { };