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
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AccountService : BaseService, IAccountService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public AccountService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public AccountExtendDto? GetAccountByIdAccount(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();            
            AccountExtendDto? accountSearch = accountRepository.GetAccountByIdAccount(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByUserBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByUserBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByStatusBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByStatusBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatusBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByFinancialInstitutionStatusBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatusBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByTypeAccountStatusBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByUserBudgetStatusBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByUserBudgetStatusBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (accountsSearch.Count != 0)
            {
                return accountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUserBudget(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByFinancialInstitutionTypeAccountUserBudget(account);

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (account == null || string.IsNullOrWhiteSpace(account.NameAccount.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<AccountExtendDto> accountsSearch = accountRepository.GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(account);

            if (accountsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByIdFinancialInstitution(new FinancialInstitutionDto { IdFinancialInstitution = account.IdFinancialInstitution }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByIdTypeAccount(new TypeAccountDto { IdTypeAccount = account.IdTypeAccount }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(new UserBudgetDto { IdUserBudget = account.IdUserBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = account.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Account saveAccount = new()
            {
                NameAccount = account.NameAccount.Trim(),
                DescriptionAccount = account.DescriptionAccount?.Trim() ?? string.Empty,
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                IdUserBudget = userBudgetSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = account.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = account.ModificationDate
            };

            UnitOfWork.BaseRepository<Account>().Add(saveAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveAccount), DateTime.Now, null);

            return account;
        }

        public AccountDto UpdateAccount(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();

            if (account == null || account.IdAccount <= 0 || string.IsNullOrWhiteSpace(account.NameAccount.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<AccountExtendDto> accountsDuplicados = accountRepository.GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(account);
            AccountExtendDto? accountSearch = accountRepository.GetAccountByIdAccount(account) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (accountsDuplicados.Count != 0 && accountsDuplicados.FirstOrDefault()!.IdAccount != accountSearch.IdAccount)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Account updateAccount = new()
            {
                IdAccount = accountSearch.IdAccount,
                NameAccount = account.NameAccount.Trim(),
                DescriptionAccount = account.DescriptionAccount?.Trim() ?? string.Empty,
                IdFinancialInstitution = accountSearch.IdFinancialInstitution,
                IdTypeAccount = accountSearch.IdTypeAccount,
                IdUserBudget = accountSearch.IdUserBudget,
                IdStatusBudget = accountSearch.IdStatusBudget,
                CreationUser = accountSearch.CreationUser,
                CreationDate = accountSearch.CreationDate,
                ModificationUser = accountSearch.ModificationUser,
                ModificationDate = account.ModificationDate
            };

            UnitOfWork.BaseRepository<Account>().Update(updateAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(accountSearch), JsonSerializer.Serialize(updateAccount), DateTime.Now, null);

            return account;
        }

        public AccountDto DeleteAccount(AccountDto account)
        {
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            AccountExtendDto? accountSearch = accountRepository.GetAccountByIdAccount(account) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = account.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (accountSearch.IdStatusBudget == account.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Account deleteAccount = new()
            {
                IdAccount = accountSearch.IdAccount,
                NameAccount = accountSearch.NameAccount.Trim(),
                DescriptionAccount = accountSearch.DescriptionAccount?.Trim() ?? string.Empty,
                IdFinancialInstitution = accountSearch.IdFinancialInstitution,
                IdTypeAccount = accountSearch.IdTypeAccount,
                IdUserBudget = accountSearch.IdUserBudget,
                IdStatusBudget = statusSearch.IdStatusBudget,
                CreationUser = accountSearch.CreationUser,
                CreationDate = accountSearch.CreationDate,
                ModificationUser = accountSearch.ModificationUser,
                ModificationDate = account.ModificationDate
            };

            UnitOfWork.BaseRepository<Account>().Update(deleteAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(accountSearch), JsonSerializer.Serialize(deleteAccount), DateTime.Now, null);

            return account;
        }

        #endregion

    }
}
