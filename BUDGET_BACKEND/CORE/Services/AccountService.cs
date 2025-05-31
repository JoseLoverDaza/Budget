namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AccountService : BaseService, IAccountService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public AccountExtendDto? GetAccountById(int idAccount)
        {
            throw new NotImplementedException();
        }

        public AccountExtendDto? GetAccountByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(int idFinancialInstitution)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(int idFinancialInstitution, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccount(int idTypeAccount)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(int idTypeAccount, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public List<AccountExtendDto> GetAccountsByUserStatus(int idUser, int idStatus)
        {
            throw new NotImplementedException();
        }

        public AccountExtendDto SaveAccount(AccountExtendDto account)
        {
            throw new NotImplementedException();
        }

        public AccountExtendDto UpdateAccount(AccountExtendDto account)
        {
            throw new NotImplementedException();
        }

        public AccountExtendDto DeleteAccount(AccountExtendDto account)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
