using System.Text.Json.Serialization;

namespace Saul.Test.Services.WebAPI.Modules.Feature
{
    public static class FeatureExtension
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration, string myPolicy)
        {
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod()
                                                                            ));

            services.AddMvc();
            services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            return services;
        }

    }
}
