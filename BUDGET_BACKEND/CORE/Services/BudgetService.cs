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
    /// Nombre: BudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetService : BaseService, IBudgetService
    {

        #region #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public BudgetService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetByIdBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetByIdBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetSearch != null)
            {
                return budgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByYearMonth(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByYearMonth(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByYearUserBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByYearUserBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByMonthUserBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByMonthUserBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByYearMonthUserBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByYearMonthUserBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByUserBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByUserBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByStatusBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByStatusBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByUserBudgetStatusBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByUserBudgetStatusBudget(budget);

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BudgetDto SaveBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (budget == null || budget.YearBudget <= 0 || budget.MonthBudget <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(new UserBudgetDto { IdUserBudget = budget.IdUserBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = budget.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<BudgetExtendDto> budgetsSearch = budgetRepository.GetBudgetsByYearMonthUserBudget(budget);

            if (budgetsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Budget saveBudget = new()
            {
                YearBudget = budget.YearBudget,
                MonthBudget = budget.MonthBudget,             
                DescriptionBudget = budget.DescriptionBudget?.Trim() ?? string.Empty,
                ObservationBudget = budget.ObservationBudget?.Trim() ?? string.Empty,
                IdUserBudget = userBudgetSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = budget.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = budget.ModificationDate
            };

            UnitOfWork.BaseRepository<Budget>().Add(saveBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveBudget), DateTime.Now, null);

            return budget;
        }

        public BudgetDto UpdateBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();

            if (budget == null || budget.YearBudget <= 0 || budget.MonthBudget <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetByIdBudget(budget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Budget updateBudget = new()
            {
                IdBudget = budgetSearch.IdBudget,
                YearBudget = budgetSearch.YearBudget,
                MonthBudget = budgetSearch.MonthBudget,              
                DescriptionBudget = budget.DescriptionBudget?.Trim() ?? string.Empty,
                ObservationBudget = budget.ObservationBudget?.Trim() ?? string.Empty,
                IdUserBudget = budgetSearch.IdUserBudget,
                IdStatusBudget = budgetSearch.IdStatusBudget,
                CreationUser = budgetSearch.CreationUser,
                CreationDate = budgetSearch.CreationDate,
                ModificationUser = budgetSearch.ModificationUser,
                ModificationDate = budget.ModificationDate
            };

            UnitOfWork.BaseRepository<Budget>().Update(updateBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(budgetSearch), JsonSerializer.Serialize(updateBudget), DateTime.Now, null);

            return budget;
        }

        public BudgetDto DeleteBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetByIdBudget(budget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = budget.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (budgetSearch.IdStatusBudget == budget.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Budget deleteBudget = new()
            {
                IdBudget = budgetSearch.IdBudget,
                YearBudget = budgetSearch.YearBudget,
                MonthBudget = budgetSearch.MonthBudget,
                DescriptionBudget = budgetSearch.DescriptionBudget?.Trim() ?? string.Empty,
                ObservationBudget = budgetSearch.ObservationBudget?.Trim() ?? string.Empty,
                IdUserBudget = budgetSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = budgetSearch.CreationUser,
                CreationDate = budgetSearch.CreationDate,
                ModificationUser = budgetSearch.ModificationUser,
                ModificationDate = budget.ModificationDate
            };

            UnitOfWork.BaseRepository<Budget>().Update(deleteBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Budget).Name, Constants.Method.POST, JsonSerializer.Serialize(budgetSearch), JsonSerializer.Serialize(deleteBudget), DateTime.Now, null);

            return budget;
        }

        #endregion Constructor

    }
}