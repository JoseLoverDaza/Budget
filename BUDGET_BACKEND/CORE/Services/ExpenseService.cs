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
    /// Nombre: ExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseService : BaseService, IExpenseService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public ExpenseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {           
        }

        #endregion

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseById(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();

            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(expense);

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
            List<ExpenseExtendDto> expensesSearch = expenseRepository.GetExpensesByTypeExpenseStatus(expense);

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
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

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

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(new TypeExpenseDto { IdTypeExpense = expense.IdTypeExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
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
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(expense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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
            return expense;
        }

        public ExpenseDto DeleteExpense(ExpenseDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(expense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
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
            return expense;
        }

        #endregion

    }
}