using Customer.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infra
{
    public static class Cfg
    {
        public static void AddCfgDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CustomerContext>(x =>
                   x.EnableSensitiveDataLogging()
                    .UseSqlServer(connectionString: Configuration.GetConnectionString("Context"), sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure())
               );
        }

        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CustomerContext>().Database.Migrate();
            }
        }
    }
}
