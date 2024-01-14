using HiringSonda.Domain.UserAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HiringSonda.Application.Person.Services;
using Microsoft.Data.SqlClient;
using HiringSonda.Infra.Data;
using Microsoft.EntityFrameworkCore;
using EFCoreSecondLevelCacheInterceptor;


namespace HiringSonda.Infra.Repository
{
    public static class NativeInjector
    {

        public static void AddLocalServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();


            #endregion

            #region Services

            services.AddScoped<IPersonService, PersonService>();

            #endregion
        }

        public static void AddLocalUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEFSecondLevelCache(options =>
                options.UseMemoryCacheProvider()
                    .DisableLogging(true)
                    .UseCacheKeyPrefix("EF_"));

            var connString = Builders.BuildConnectionStringACS(configuration);

            services.AddScoped<IUnitOfWork>(serviceProvider =>
            {
                var connection = new DbContextOptionsBuilder<ContextDatabase>();
                var conn = connString;

                return new UnitOfWork(
                    new ContextDatabase(
                        connection
                            .AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>())
                            .UseLazyLoadingProxies()
                            .UseSqlServer(conn).Options));
            });

            services.AddPooledDbContextFactory<ContextDatabase>(options => options.UseLazyLoadingProxies().UseSqlServer(connString).EnableSensitiveDataLogging());
        }

    }

    public static class Builders
    {
        public static string BuildConnectionStringACS(IConfiguration configuration)
        {
            // Partial Connection; only host,user,password
            var sqlBuilder = new SqlConnectionStringBuilder(configuration["App:Settings:ConnectionStringPartial"])
            {
                PersistSecurityInfo = true,
                InitialCatalog = "SondaLeandroKuranaga",
                MultipleActiveResultSets = true
            };
            return sqlBuilder.ConnectionString;
        }
    }
}
