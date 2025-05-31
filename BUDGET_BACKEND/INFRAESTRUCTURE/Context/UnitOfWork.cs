namespace INFRAESTRUCTURE.Context
{

    #region Librerias

    using CORE.Interfaces.Repositories;
    using CORE.Utils;
    using Domain.Context;
    using INFRAESTRUCTURE.Repository;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Context   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UnitOfWork : IUnitOfWork
    {

        #region Attributes

        private readonly EFContext _dbContext;

        #endregion Attributes

        #region Constructor

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Constructor

        #region Methods

        public IUnitOfWork GetNewInstanceUnitOfWork()
        {
            var config = new ConfigurationBuilder().AddJsonFile(Constants.General.APP_SETTIINGS_JSON_FILE_NAME).Build();
            var connectionString = config.GetConnectionString(Constants.General.CONNECTION_STRING_DATABASE_NAME);
            DbContextOptionsBuilder optionsBuilder = new();
            var options = optionsBuilder.UseSqlServer(connectionString!).Options;
            EFContext context = new(options);
            UnitOfWork unitOfWork = new(context);
            return unitOfWork;
        }

        public IBaseRepository<T> BaseRepository<T>() where T : class
        {
            return new BaseRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public IStatusRepository StatusRepository()
        {
            return new StatusRepository(_dbContext);
        }

        public IRoleRepository RoleRepository()
        {
            return new RoleRepository(_dbContext);
        }

        public IUserRepository UserRepository()
        {
            return new UserRepository(_dbContext);
        }

        public ITypeAccountRepository TypeAccountRepository()
        {
            return new TypeAccountRepository(_dbContext);
        }

        public ITypeExpenseRepository TypeExpenseRepository()
        {
            return new TypeExpenseRepository(_dbContext);
        }

        public IFinancialInstitutionRepository FinancialInstitutionRepository()
        {
            return new FinancialInstitutionRepository(_dbContext);
        }

        public IExpenseRepository ExpenseRepository()
        {
            return new ExpenseRepository(_dbContext);
        }

        public IDepositRepository DepositRepository()
        {
            return new DepositRepository(_dbContext);
        }

        public IAccountRepository AccountRepository()
        {
            return new AccountRepository(_dbContext);
        }

        public IBillingRepository BillingRepository()
        {
            return new BillingRepository(_dbContext);
        }

        public IBillingDetailsRepository BillingDetailsRepository()
        {
            return new BillingDetailsRepository(_dbContext);
        }

        public IBudgetRepository BudgetRepository()
        {
            return new BudgetRepository(_dbContext);
        }

        public IBudgetDetailsRepository BudgetDetailsRepository()
        {
            return new BudgetDetailsRepository(_dbContext);
        }

        #endregion Methods


    }
}