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
    using System.Text.RegularExpressions;

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

        public ExpenseExtendDto? GetExpenseById(int idExpense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();

            ExpenseExtendDto? expense = expenseRepository.GetExpenseById(idExpense);

            if (expense != null)
            {
                return expense;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public ExpenseExtendDto? GetExpenseByName(string name)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();

            ExpenseExtendDto? expense = expenseRepository.GetExpenseByName(name);

            if (expense != null)
            {
                return expense;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<ExpenseExtendDto> GetExpensesByStatus(int idStatus)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            List<ExpenseExtendDto> expenses = expenseRepository.GetExpensesByStatus(idStatus);

            if (expenses.Count != 0)
            {
                return expenses;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public ExpenseExtendDto SaveExpense(ExpenseExtendDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (expense == null || string.IsNullOrWhiteSpace(expense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(expense.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByName(expense.Name.Trim());

            if (expenseSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(expense.IdTypeExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(expense.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Expense saveExpense = new()
            {
                Name = expense.Name.Trim(),
                Description = expense.Description!.Trim(),
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

        public ExpenseExtendDto UpdateExpense(ExpenseExtendDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();

            if (expense == null || expense.IdExpense <= 0 || string.IsNullOrWhiteSpace(expense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(expense.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            ExpenseExtendDto? expenseDuplicado = expenseRepository.GetExpenseByName(expense.Name);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(expense.IdExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (expenseDuplicado != null && expenseDuplicado.IdExpense != expenseSearch.IdExpense)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Expense updateExpense = new()
            {
                IdExpense = expenseSearch.IdExpense,
                Name = expense.Name.Trim(),
                Description = expense.Description!.Trim(),
                IdStatus = expenseSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Expense>().Update(updateExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return expense;
        }

        public ExpenseExtendDto DeleteExpense(ExpenseExtendDto expense)
        {
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(expense.IdExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Expense deleteExpense = new()
            {
                IdExpense = expenseSearch.IdExpense,
                Name = expenseSearch.Name.Trim(),
                Description = expenseSearch.Description!.Trim(),
                IdTypeExpense = expenseSearch.IdTypeExpense,
                IdStatus = Constants.Status.INACTIVO
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