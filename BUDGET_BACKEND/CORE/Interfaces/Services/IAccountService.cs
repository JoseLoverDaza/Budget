namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAccountService
    {

        #region Métodos y Funciones

        public AccountExtendDto? GetAccountById(int idAccount);

        public AccountExtendDto? GetAccountByName(string name);

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(int idFinancialInstitution);

        public List<AccountExtendDto> GetAccountsByTypeAccount(int idTypeAccount);

        public List<AccountExtendDto> GetAccountsByUser(int idUser);

        public List<AccountExtendDto> GetAccountsByStatus(int idStatus);

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(int idFinancialInstitution, int idStatus);

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(int idTypeAccount, int idStatus);

        public List<AccountExtendDto> GetAccountsByUserStatus(int idUser, int idStatus);

        public AccountExtendDto SaveAccount(AccountExtendDto account);

        public AccountExtendDto UpdateAccount(AccountExtendDto account);

        public AccountExtendDto DeleteAccount(AccountExtendDto account);

        #endregion

    }
}