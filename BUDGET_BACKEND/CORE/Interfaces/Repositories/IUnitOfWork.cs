namespace CORE.Interfaces.Repositories
{

    #region Librerias

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUnitOfWork   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUnitOfWork
    {

        #region Métodos y Funciones

        public IUnitOfWork GetNewInstanceUnitOfWork();

        public int SaveChanges();

        public Task<int> SaveChangesAsync();

        public IBaseRepository<T> BaseRepository<T>() where T : class;

        public IStatusRepository StatusRepository();

        public IRoleRepository RoleRepository();

        public IUserRepository UserRepository();

        public IFinancialInstitutionRepository FinancialInstitutionRepository();

        public ITypeAccountRepository TypeAccountRepository();

        public ITypeExpenseRepository TypeExpenseRepository();

        public IExpenseRepository ExpenseRepository();

        public IAccountRepository AccountRepository();

        public IDepositRepository DepositRepository();

        public IBillingRepository BillingRepository();

        public IBillingDetailsRepository BillingDetailsRepository();

        public IBudgetRepository BudgetRepository();

        public IBudgetDetailsRepository BudgetDetailsRepository();

        #endregion

    }
}