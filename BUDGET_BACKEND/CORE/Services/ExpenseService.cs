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

        public ExpenseExtendDto? GetExpenseById(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(Expense).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (expensesSearch.Count != 0)
            {
                return expensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByStatus(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByStatus(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(Expense).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (expensesSearch.Count != 0)
            {
                return expensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatus(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByTypeExpenseStatusBudget(expense);

            _logApiService.TraceLog(typeof(Expense).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            if (expense == null || string.IsNullOrWhiteSpace(expense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(expense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByNameTypeExpense(expense);

            if (expensesSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByIdTypeExpense(new TypeExpenseDto { IdTypeExpense = expense.IdTypeExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = expense.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Expense saveExpense = new()
            {
                Name = expense.Name.Trim(),
                Description = expense.Description?.Trim() ?? string.Empty,
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Expense>().Add(saveExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Deposit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveExpense), DateTime.Now, null);

            return expense;
        }

        public ExpenseDto UpdateExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();

            if (expense == null || expense.IdExpense <= 0 || string.IsNullOrWhiteSpace(expense.Name.Trim()))
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
                Name = expense.Name.Trim(),
                Description = expense.Description?.Trim() ?? string.Empty,
                IdStatus = expenseSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Expense>().Update(updateExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.POST, JsonSerializer.Serialize(expenseSearch), JsonSerializer.Serialize(updateExpense), DateTime.Now, null);

            return expense;
        }

        public ExpenseDto DeleteExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(expense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = expense.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (expenseSearch.IdStatus == expense.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Expense deleteExpense = new()
            {
                IdExpense = expenseSearch.IdExpense,
                Name = expenseSearch.Name.Trim(),
                Description = expenseSearch.Description?.Trim() ?? string.Empty,
                IdTypeExpense = expenseSearch.IdTypeExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Expense>().Update(deleteExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Expense).Name, Constants.Method.POST, JsonSerializer.Serialize(expenseSearch), JsonSerializer.Serialize(deleteExpense), DateTime.Now, null);

            return expense;
        }

        #endregion

    }
}