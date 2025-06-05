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

        public AccountExtendDto? GetAccountById(AccountDto account);

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(AccountDto account);

        public List<AccountExtendDto> GetAccountsByTypeAccount(AccountDto account);

        public List<AccountExtendDto> GetAccountsByUser(AccountDto account);

        public List<AccountExtendDto> GetAccountsByStatus(AccountDto account);

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(AccountDto account);

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(AccountDto account);

        public List<AccountExtendDto> GetAccountsByUserStatus(AccountDto account);

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUser(AccountDto account);

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUser(AccountDto account);

        public AccountDto SaveAccount(AccountDto account);

        public AccountDto UpdateAccount(AccountDto account);

        public AccountDto DeleteAccount(AccountDto account);

        #endregion

    }
}