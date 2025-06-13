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
    using System.Security.Principal;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositService : BaseService, IDepositService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public DepositService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositByIdDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            DepositExtendDto? depositSearch = depositRepository.GetDepositByIdDeposit(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositSearch != null)
            {
                return depositSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonth(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearUserBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearUserBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByMonthUserBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByMonthUserBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonthUserBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonthAccount(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatusBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonthStatusBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudgetAccount(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByYearMonthUserBudgetAccount(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByUserBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByUserBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByAccount(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByAccount(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByStatusBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByStatusBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByUserBudgetStatusBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByUserBudgetStatusBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByAccountStatusBudget(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByAccountStatusBudget(deposit);

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(deposit), DateTime.Now, null);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public DepositDto SaveDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (deposit == null || string.IsNullOrWhiteSpace(deposit.Amount.ToString().Trim()) || deposit.YearDeposit <= 0 || deposit.MonthDeposit <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            AccountExtendDto? accountSearch = accountRepository.GetAccountByIdAccount(new AccountDto { IdAccount = deposit.IdAccount }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(new UserBudgetDto { IdUserBudget = deposit.IdUserBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = deposit.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<DepositExtendDto>? depositSearch = depositRepository.GetDepositsByYearMonthUserBudgetAccount(deposit);

            if (depositSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Deposit saveDeposit = new()
            {
                YearDeposit = deposit.YearDeposit,
                MonthDeposit = deposit.MonthDeposit,
                Amount = deposit.Amount,
                IdUserBudget = userSearch.IdUserBudget,
                IdAccount = accountSearch.IdAccount,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = deposit.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = deposit.ModificationDate
            };

            UnitOfWork.BaseRepository<Deposit>().Add(saveDeposit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveDeposit), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return deposit;
        }

        public DepositDto UpdateDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();

            if (deposit == null || string.IsNullOrWhiteSpace(deposit.Amount.ToString().Trim()) || deposit.YearDeposit <= 0 || deposit.MonthDeposit <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            DepositExtendDto? depositSearch = depositRepository.GetDepositByIdDeposit(deposit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Deposit updateDeposit = new()
            {
                IdDeposit = depositSearch.IdDeposit,
                YearDeposit = depositSearch.YearDeposit,
                MonthDeposit = depositSearch.MonthDeposit,
                Amount = deposit.Amount,
                IdUserBudget = depositSearch.IdUserBudget,
                IdAccount = depositSearch.IdAccount,
                IdStatusBudget = depositSearch.IdStatusBudget,
                CreationUser = depositSearch.CreationUser,
                CreationDate = depositSearch.CreationDate,
                ModificationUser = depositSearch.ModificationUser,
                ModificationDate = deposit.ModificationDate
            };

            UnitOfWork.BaseRepository<Deposit>().Update(updateDeposit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(depositSearch), JsonSerializer.Serialize(updateDeposit), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return deposit;
        }

        public DepositDto DeleteDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            DepositExtendDto? depositSearch = depositRepository.GetDepositByIdDeposit(deposit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = deposit.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (depositSearch.IdStatusBudget == deposit.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Deposit deleteDeposit = new()
            {
                IdDeposit = depositSearch.IdDeposit,
                YearDeposit = depositSearch.YearDeposit,
                MonthDeposit = depositSearch.MonthDeposit,
                Amount = depositSearch.Amount,
                IdUserBudget = depositSearch.IdUserBudget,
                IdAccount = depositSearch.IdAccount,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = depositSearch.CreationUser,
                CreationDate = depositSearch.CreationDate,
                ModificationUser = depositSearch.ModificationUser,
                ModificationDate = deposit.ModificationDate
            };

            UnitOfWork.BaseRepository<Deposit>().Update(deleteDeposit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.EntityAction.DELETE, JsonSerializer.Serialize(depositSearch), JsonSerializer.Serialize(deleteDeposit), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return deposit;
        }

        #endregion

    }
}