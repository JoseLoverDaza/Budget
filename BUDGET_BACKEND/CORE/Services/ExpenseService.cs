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
    /// Nombre: ExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseService : BaseService, IExpenseService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public ExpenseService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseByIdExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(expense), DateTime.Now, null);

            if (expenseSearch != null)
            {
                return expenseSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByTypeExpense(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(expense), DateTime.Now, null);

            if (expensesSearch.Count != 0)
            {
                return expensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByStatusBudget(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByStatusBudget(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(expense), DateTime.Now, null);

            if (expensesSearch.Count != 0)
            {
                return expensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByNameTypeExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByNameTypeExpense(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(expense), DateTime.Now, null);

            if (expensesSearch.Count != 0)
            {
                return expensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatusBudget(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByTypeExpenseStatusBudget(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(expense), DateTime.Now, null);

            if (expensesSearch.Count != 0)
            {
                return expensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public ExpenseDto SaveExpense(ExpenseDto expense)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            if (expense == null || string.IsNullOrWhiteSpace(expense.NameExpense.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(expense.NameExpense.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByNameTypeExpense(expense);

            if (expensesSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByIdTypeExpense(new TypeExpenseDto { IdTypeExpense = expense.IdTypeExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = expense.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Expense saveExpense = new()
            {
                NameExpense = expense.NameExpense.Trim(),
                DescriptionExpense = expense.DescriptionExpense?.Trim() ?? string.Empty,
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = expense.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = expense.ModificationDate
            };

            UnitOfWork.BaseRepository<Expense>().Add(saveExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveExpense), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return expense;
        }

        public ExpenseDto UpdateExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();

            if (expense == null || expense.IdExpense <= 0 || string.IsNullOrWhiteSpace(expense.NameExpense.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<ExpenseExtendDto> expenseDuplicados = expenseRepository.GetExpensesByNameTypeExpense(expense);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(expense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (expenseDuplicados.Count != 0 && expenseDuplicados.FirstOrDefault()!.IdExpense != expenseSearch.IdExpense)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Expense updateExpense = new()
            {
                IdExpense = expenseSearch.IdExpense,
                NameExpense = expense.NameExpense.Trim(),
                DescriptionExpense = expense.DescriptionExpense?.Trim() ?? string.Empty,
                IdTypeExpense = expenseSearch.IdTypeExpense,
                IdStatusBudget = expenseSearch.IdStatusBudget,
                CreationUser = expenseSearch.CreationUser,
                CreationDate = expenseSearch.CreationDate,
                ModificationUser = expenseSearch.ModificationUser,
                ModificationDate = expense.ModificationDate
            };

            UnitOfWork.BaseRepository<Expense>().Update(updateExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(expenseSearch), JsonSerializer.Serialize(updateExpense), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return expense;
        }

        public ExpenseDto DeleteExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(expense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = expense.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (expenseSearch.IdStatusBudget == expense.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Expense deleteExpense = new()
            {
                IdExpense = expenseSearch.IdExpense,
                NameExpense = expenseSearch.NameExpense.Trim(),
                DescriptionExpense = expenseSearch.DescriptionExpense?.Trim() ?? string.Empty,
                IdTypeExpense = expenseSearch.IdTypeExpense,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = expenseSearch.CreationUser,
                CreationDate = expenseSearch.CreationDate,
                ModificationUser = expenseSearch.ModificationUser,
                ModificationDate = expense.ModificationDate
            };

            UnitOfWork.BaseRepository<Expense>().Update(deleteExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Expense).Name, Constants.EntityAction.DELETE, JsonSerializer.Serialize(expenseSearch), JsonSerializer.Serialize(deleteExpense), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return expense;
        }

        #endregion

    }
}