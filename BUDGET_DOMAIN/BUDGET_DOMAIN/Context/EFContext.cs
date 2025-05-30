namespace Domain.Context
{

    #region Librerias

    using Domain.Entities;
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

        #region Atributos

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

        public virtual DbSet<Status> Status { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<FinancialInstitution> FinancialInstitutions { get; set; }
        public virtual DbSet<TypeAccount> TypeAccounts { get; set; }
        public virtual DbSet<TypeExpense> TypeExpenses { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<BudgetDetails> BudgetDetails { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<BillingDetails> BillingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.StatusConfiguration());

            modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());

            modelBuilder.ApplyConfiguration(new Configurations.FinancialInstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TypeAccountConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TypeExpenseConfiguration());

            modelBuilder.ApplyConfiguration(new Configurations.AccountConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.DepositConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BudgetConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BudgetDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BillingConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BillingDetailsConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion

    }
}