namespace API.Extensions
{
    using API.Helper;

    #region Librerias

    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
    using Domain.Context;
    using Microsoft.EntityFrameworkCore;
    using Serilog;
    using Serilog.Sinks.MSSqlServer;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ServiceCollectionExtensions   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public static class ServiceCollectionExtensions
    {

        #region Métodos y Funciones

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, INFRAESTRUCTURE.Context.UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string decryptedConnectionString = GetDecryptedConnectionString(configuration);

            return services.AddDbContext<EFContext>(options =>
             options.UseSqlServer(decryptedConnectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {            
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuditService, AuditService>();
            services.AddTransient<ITokenApiService, TokenApiService>();
            services.AddTransient<ILogApiService, LogApiService>();
            services.AddTransient<ITypeAccountService, TypeAccountService>();
            services.AddTransient<ITypeExpenseService, TypeExpenseService>();
            services.AddTransient<IFinancialInstitutionService, FinancialInstitutionService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IDepositService, DepositService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<IBillingDetailsService, BillingDetailsService>();
            services.AddTransient<IBudgetService, BudgetService>();
            services.AddTransient<IBudgetDetailsService, BudgetDetailsService>();

            return services;
        }

        public static IHostBuilder AddSerilogConfig(this IHostBuilder host, IConfiguration configuration)
        {
            string decryptedConn = GetDecryptedConnectionString(configuration);

            return host.UseSerilog((ctx, cfg) =>
            {
                cfg.ReadFrom.Configuration(ctx.Configuration)
                   .WriteTo.MSSqlServer(
                        connectionString: decryptedConn,
                        sinkOptions: new MSSqlServerSinkOptions
                        {
                            TableName = "logs_excepcion",
                            AutoCreateSqlTable = true
                        },
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error);
            });
        }

        private static string GetDecryptedConnectionString(IConfiguration configuration)
        {       
            EncryptionHelper.Configure(configuration); 
            string encrypted = configuration.GetConnectionString(Constants.General.CONNECTION_STRING_DATABASE_NAME)!;
            return EncryptionHelper.Decrypt(encrypted);
        }

        #endregion Methods

    }
}
