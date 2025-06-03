namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
   
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
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            AccountExtendDto? account = accountRepository.GetAccountById(idAccount);

            if (account != null)
            {
                return account;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public AccountExtendDto? GetAccountByName(string name)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            AccountExtendDto? account = accountRepository.GetAccountByName(name);

            if (account != null)
            {
                return account;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(int idFinancialInstitution)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByFinancialInstitution(idFinancialInstitution);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(int idFinancialInstitution, int idStatus)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByFinancialInstitutionStatus(idFinancialInstitution, idStatus);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByStatus(int idStatus)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByStatus(idStatus);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByTypeAccount(int idTypeAccount)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByTypeAccount(idTypeAccount);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(int idTypeAccount, int idStatus)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByTypeAccountStatus(idTypeAccount, idStatus);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByUser(int idUser)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByUser(idUser);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByUserStatus(int idUser, int idStatus)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accounts = accountRepository.GetAccountsByUserStatus(idUser, idStatus);

            if (accounts.Count != 0)
            {
                return accounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public AccountExtendDto SaveAccount(AccountExtendDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (account == null || string.IsNullOrWhiteSpace(account.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(account.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            AccountExtendDto? accountSearch = accountRepository.GetAccountByName(account.Name.Trim());

            if (accountSearch != null && accountSearch.IdFinancialInstitution == account.IdFinancialInstitution
                && accountSearch.IdTypeAccount == account.IdTypeAccount && accountSearch.IdUser == account.IdUser)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(account.IdFinancialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(account.IdTypeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserExtendDto? userSearch = userRepository.GetUserById(account.IdUser) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(account.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Account saveAccount = new()
            {
                Name = account.Name.Trim(),
                Description = account.Description!.Trim(),
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                IdUser = userSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Account>().Add(saveAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return account;
        }

        public AccountExtendDto UpdateAccount(AccountExtendDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();

            if (account == null || account.IdAccount <= 0 || string.IsNullOrWhiteSpace(account.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(account.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            AccountExtendDto? accountDuplicado = accountRepository.GetAccountByName(account.Name);
            AccountExtendDto? accountSearch = accountRepository.GetAccountById(account.IdAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (accountDuplicado != null && accountDuplicado.IdAccount != accountSearch.IdAccount)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Account updateAccount = new()
            {
                IdAccount = accountSearch.IdAccount,
                Name = account.Name.Trim(),
                Description = account.Description!.Trim(),
                IdFinancialInstitution = accountSearch.IdFinancialInstitution,
                IdTypeAccount = accountSearch.IdTypeAccount,
                IdUser = accountSearch.IdUser,
                IdStatus = accountSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Account>().Update(updateAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return account;
        }

        public AccountExtendDto DeleteAccount(AccountExtendDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            AccountExtendDto? accountSearch = accountRepository.GetAccountById(account.IdAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(account.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == account.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Account deleteAccount = new()
            {
                Name = accountSearch.Name.Trim(),
                Description = accountSearch.Description!.Trim(),
                IdFinancialInstitution = accountSearch.IdFinancialInstitution,
                IdTypeAccount = accountSearch.IdTypeAccount,
                IdUser = accountSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Account>().Update(deleteAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return account;
        }

        #endregion

    }
}
