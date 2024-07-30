using WatchDog;

namespace Saul.Test.Services.WebAPI.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDogLog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(opt =>
            {
                opt.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
                opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
                opt.IsAutoClear = true;
                opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });

            return services;
        }
    }
}
