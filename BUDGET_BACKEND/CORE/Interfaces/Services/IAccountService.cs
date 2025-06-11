namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAccountService
    {

        #region Métodos y Funciones

        public AccountExtendDto? GetAccountByIdAccount(AccountDto account);

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(AccountDto account);

        public List<AccountExtendDto> GetAccountsByTypeAccount(AccountDto account);

        public List<AccountExtendDto> GetAccountsByUserBudget(AccountDto account);

        public List<AccountExtendDto> GetAccountsByStatusBudget(AccountDto account);

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatusBudget(AccountDto account);

        public List<AccountExtendDto> GetAccountsByTypeAccountStatusBudget(AccountDto account);

        public List<AccountExtendDto> GetAccountsByUserBudgetStatusBudget(AccountDto account);

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(AccountDto account);

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUserBudget(AccountDto account);

        public AccountDto SaveAccount(AccountDto account);

        public AccountDto UpdateAccount(AccountDto account);

        public AccountDto DeleteAccount(AccountDto account);

        #endregion

    }
}