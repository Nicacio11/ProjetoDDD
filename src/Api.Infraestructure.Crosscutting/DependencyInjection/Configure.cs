using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Infraestructure.Data.Context;
using Api.Infraestructure.Data.Repositories;
using Api.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Api.Infraestructure.Crosscutting.DependencyInjection
{
    public class ConfigureDependecy
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
        public static void ConfigureRepository(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString)
            );
            //services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
