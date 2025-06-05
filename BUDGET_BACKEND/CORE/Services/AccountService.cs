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

        public AccountExtendDto? GetAccountById(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            AccountExtendDto? accountSearch = accountRepository.GetAccountById(account);

            if (accountSearch != null)
            {
                return accountSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByFinancialInstitution(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByTypeAccount(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByTypeAccount(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByUser(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByUser(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByStatus(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByStatus(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByFinancialInstitutionStatus(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByTypeAccountStatus(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByUserStatus(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByUserStatus(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUser(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByNameFinancialInstitutionTypeAccountUser(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUser(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByFinancialInstitutionTypeAccountUser(account);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }


        public AccountDto SaveAccount(AccountDto account)
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

            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByNameFinancialInstitutionTypeAccountUser(account);

            if (accountsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(new FinancialInstitutionDto { IdFinancialInstitution = account.IdFinancialInstitution }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(new TypeAccountDto { IdTypeAccount = account.IdTypeAccount }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserExtendDto? userSearch = userRepository.GetUserById(new UserDto { IdUser = account.IdUser }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = account.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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

        public AccountDto UpdateAccount(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();

            if (account == null || account.IdAccount <= 0 || string.IsNullOrWhiteSpace(account.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<AccountExtendDto> accountsDuplicados = accountRepository.GetAccountsByNameFinancialInstitutionTypeAccountUser(account);
            AccountExtendDto? accountSearch = accountRepository.GetAccountById(account) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (accountsDuplicados.Count != 0 && accountsDuplicados.FirstOrDefault()!.IdAccount != accountSearch.IdAccount)
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

        public AccountDto DeleteAccount(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            AccountExtendDto? accountSearch = accountRepository.GetAccountById(account) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = account.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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
