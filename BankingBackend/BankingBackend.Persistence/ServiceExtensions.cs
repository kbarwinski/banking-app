using BankingBackend.Application.Repositories;
using BankingBackend.Persistence.Context;
using BankingBackend.Persistence.Repositories;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BankingBackend.Persistence.Migrations;
using FluentMigrator.Runner.Exceptions;
using BankingBackend.Application.Services;
using BankingBackend.Persistence.Services;

namespace BankingBackend.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionCategoryRepository, TransactionCategoryRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IAccountBalanceService, AccountBalanceService>();

            services.AddFluentMigratorCore()
                .ConfigureRunner(cfg => cfg
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(BaseMigration).Assembly).For.Migrations());
        }

        public static void UpdateDatabase(this IServiceProvider serviceProvider)
        {
            try
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
            catch (MissingMigrationsException) { }
        }
    }
}
