namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAccountRepository
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

        #endregion

    }
}