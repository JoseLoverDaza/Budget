namespace Domain.Context
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: EFContext   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class EFContext : DbContext
    {

        #region Atributos y Propiedades

        private readonly string _connectionString;
        
        #endregion

        #region Constructores

        public EFContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public EFContext(DbContextOptions options) : base(options)
        {
            _connectionString = string.Empty;
        }

        #endregion

        #region Métodos y Funciones

        public virtual DbSet<StatusBudget> StatusBudget { get; set; }

        public virtual DbSet<RoleBudget> RolesBudget { get; set; }
        public virtual DbSet<UserBudget> UsersBudget { get; set; }

        public virtual DbSet<AuditApi> AuditApis { get; set; }
        public virtual DbSet<TokenApi> TokenApis { get; set; }        
        public virtual DbSet<LogApi> LogApis { get; set; }
        
        public virtual DbSet<TypeAccount> TypeAccounts { get; set; }
        public virtual DbSet<TypeExpense> TypeExpenses { get; set; }
        public virtual DbSet<FinancialInstitution> FinancialInstitutions { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<BillingDetails> BillingDetails { get; set; }
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<BudgetDetails> BudgetDetails { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new Configurations.StatusBudgetConfiguration());

            modelBuilder.ApplyConfiguration(new Configurations.RoleBudgetConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserBudgetConfiguration());

            modelBuilder.ApplyConfiguration(new Configurations.AuditApiConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TokenApiConfiguration());                    
            modelBuilder.ApplyConfiguration(new Configurations.LogApiConfiguration());

            modelBuilder.ApplyConfiguration(new Configurations.TypeAccountConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TypeExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FinancialInstitutionConfiguration());
            
            modelBuilder.ApplyConfiguration(new Configurations.AccountConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.DepositConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BillingConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BillingDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BudgetConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BudgetDetailsConfiguration());
                 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        #endregion

    }
}