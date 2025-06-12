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
    /// Nombre: TypeAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccountService : BaseService, ITypeAccountService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public TypeAccountService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountByIdTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByIdTypeAccount(typeAccount);

            _logApiService.TraceLog(typeof(TypeAccount).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (typeAccountSearch != null)
            {
                return typeAccountSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeAccountExtendDto? GetTypeAccountByNameTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByNameTypeAccount(typeAccount);

            _logApiService.TraceLog(typeof(TypeAccount).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (typeAccountSearch != null)
            {
                return typeAccountSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TypeAccountExtendDto> GetTypeAccountsByStatusBudget(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            List<TypeAccountExtendDto> typeAccountsSearch = typeAccountRepository.GetTypeAccountsByStatusBudget(typeAccount);

            _logApiService.TraceLog(typeof(TypeAccount).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (typeAccountsSearch.Count != 0)
            {
                return typeAccountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeAccountDto SaveTypeAccount(TypeAccountDto typeAccount)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (typeAccount == null || string.IsNullOrWhiteSpace(typeAccount.NameTypeAccount.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByNameTypeAccount(typeAccount);
            
            if (typeAccountSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = typeAccount.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            
            TypeAccount saveTypeAccount = new()
            {
                NameTypeAccount = typeAccount.NameTypeAccount.Trim(),
                DescriptionTypeAccount = typeAccount.DescriptionTypeAccount?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = typeAccount.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = typeAccount.ModificationDate
            };

            UnitOfWork.BaseRepository<TypeAccount>().Add(saveTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TypeAccount).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveTypeAccount), DateTime.Now, null);

            return typeAccount;
        }

        public TypeAccountDto UpdateTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();

            if (typeAccount == null || typeAccount.IdTypeAccount <= 0 || string.IsNullOrWhiteSpace(typeAccount.NameTypeAccount.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccountExtendDto? typeAccountDuplicado = typeAccountRepository.GetTypeAccountByNameTypeAccount(typeAccount);
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByIdTypeAccount(typeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeAccountDuplicado != null && typeAccountDuplicado.IdTypeAccount != typeAccount.IdTypeAccount)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccount updateTypeAccount = new()
            {
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                NameTypeAccount = typeAccount.NameTypeAccount.Trim(),
                DescriptionTypeAccount = typeAccount.DescriptionTypeAccount?.Trim() ?? string.Empty,
                IdStatusBudget = typeAccountSearch.IdStatusBudget,
                CreationUser = typeAccountSearch.CreationUser,
                CreationDate = typeAccountSearch.CreationDate,
                ModificationUser = typeAccountSearch.ModificationUser,
                ModificationDate = typeAccount.ModificationDate
            };

            UnitOfWork.BaseRepository<TypeAccount>().Update(updateTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TypeAccount).Name, Constants.Method.POST, JsonSerializer.Serialize(typeAccountSearch), JsonSerializer.Serialize(updateTypeAccount), DateTime.Now, null);

            return typeAccount;
        }

        public TypeAccountDto DeleteTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByIdTypeAccount(typeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = typeAccount.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeAccountSearch.IdStatusBudget == typeAccount.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccount deleteTypeAccount = new()
            {
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                NameTypeAccount = typeAccountSearch.NameTypeAccount.Trim(),
                DescriptionTypeAccount = typeAccountSearch.DescriptionTypeAccount?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = typeAccountSearch.CreationUser,
                CreationDate = typeAccountSearch.CreationDate,
                ModificationUser = typeAccountSearch.ModificationUser,
                ModificationDate = typeAccount.ModificationDate
            };

            UnitOfWork.BaseRepository<TypeAccount>().Update(deleteTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TypeAccount).Name, Constants.Method.POST, JsonSerializer.Serialize(typeAccountSearch), JsonSerializer.Serialize(deleteTypeAccount), DateTime.Now, null);

            return typeAccount;
        }

        #endregion

    }
}