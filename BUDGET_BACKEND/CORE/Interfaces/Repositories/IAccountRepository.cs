namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAccountRepository
    {

        #region Métodos y Funciones

        public AccountExtendDto? GetAccountById(int id);

        public AccountExtendDto? GetAccountByName(string name);

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(int financialInstitution);

        public List<AccountExtendDto> GetAccountsByTypeAccount(int typeAccount);

        public List<AccountExtendDto> GetAccountsByUser(int user);

        public List<AccountExtendDto> GetAccountsByStatus(int status);

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(int financialInstitution, int status);

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(int typeAccount, int status);

        public List<AccountExtendDto> GetAccountsByUserStatus(int user, int status);

        #endregion Methods

    }
}