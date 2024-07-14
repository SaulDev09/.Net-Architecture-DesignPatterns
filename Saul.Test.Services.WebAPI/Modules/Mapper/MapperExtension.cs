using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Transversal.Mapper;

namespace Saul.Test.Services.WebAPI.Modules.Mapper
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
