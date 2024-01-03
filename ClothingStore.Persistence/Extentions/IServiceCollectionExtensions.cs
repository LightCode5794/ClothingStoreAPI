using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Persistence.Context;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Interfaces.Repositories.GenericRepository;
using ClothingStore.Persistence.Repositories;
using ClothingStore.Persistence.Repositories.GenericRepository;

namespace ClothingStore.Persistence.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IOrderRepository, OrderRepository>();
            //.AddTransient<IPlayerRepository, PlayerRepository>()
            //.AddTransient<IClubRepository, ClubRepository>()
            //.AddTransient<IStadiumRepository, StadiumRepository>()
            //.AddTransient<ICountryRepository, CountryRepository>();
        }
    }
}
