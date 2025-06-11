namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using Domain.Context;
    using Domain.Dto;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public ExpenseRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseByIdExpense(ExpenseDto expense)
        {
            return (
                       from e in _context.Expenses.AsNoTracking()
                       join t in _context.TypeExpenses.AsNoTracking()
                       on e.IdTypeExpense equals t.IdTypeExpense
                       join s in _context.Status.AsNoTracking()
                       on e.IdStatus equals s.IdStatus
                       where e.IdExpense == expense.IdExpense
                       select new ExpenseExtendDto
                       {
                           IdExpense = e.IdExpense,
                           Name = e.Name,
                           Description = e.Description,
                           IdTypeExpense = t.IdTypeExpense,
                           NameTypeExpense = t.Name,
                           DescriptionTypeExpense = t.Description,
                           IdStatus = e.IdStatus,
                           NameStatusBudget = s.Name,
                           DescriptionStatusBudget = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(ExpenseDto expense)
        {
            return (
                   from e in _context.Expenses.AsNoTracking()
                   join t in _context.TypeExpenses.AsNoTracking()
                   on e.IdTypeExpense equals t.IdTypeExpense
                   join s in _context.Status.AsNoTracking()
                   on e.IdStatus equals s.IdStatus
                   where e.IdTypeExpense == expense.IdTypeExpense
                   select new ExpenseExtendDto
                   {
                       IdExpense = e.IdExpense,
                       Name = e.Name,
                       Description = e.Description,
                       IdTypeExpense = t.IdTypeExpense,
                       NameTypeExpense = t.Name,
                       DescriptionTypeExpense = t.Description,
                       IdStatus = e.IdStatus,
                       NameStatusBudget = s.Name,
                       DescriptionStatusBudget = s.Description
                   }
                 )
                .ToList();
        }

        public List<ExpenseExtendDto> GetExpensesByStatus(ExpenseDto expense)
        {
            return (
                    from e in _context.Expenses.AsNoTracking()
                    join t in _context.TypeExpenses.AsNoTracking()
                    on e.IdTypeExpense equals t.IdTypeExpense
                    join s in _context.Status.AsNoTracking()
                    on e.IdStatus equals s.IdStatus
                    where e.IdStatus == expense.IdStatus
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        Name = e.Name,
                        Description = e.Description,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.Name,
                        DescriptionTypeExpense = t.Description,
                        IdStatus = e.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<ExpenseExtendDto> GetExpensesByNameTypeExpense(ExpenseDto expense)
        {
            return (
                   from e in _context.Expenses.AsNoTracking()
                   join t in _context.TypeExpenses.AsNoTracking()
                   on e.IdTypeExpense equals t.IdTypeExpense
                   join s in _context.Status.AsNoTracking()
                   on e.IdStatus equals s.IdStatus
                   where e.Name == expense.Name && e.IdTypeExpense == expense.IdTypeExpense
                   select new ExpenseExtendDto
                   {
                       IdExpense = e.IdExpense,
                       Name = e.Name,
                       Description = e.Description,
                       IdTypeExpense = t.IdTypeExpense,
                       NameTypeExpense = t.Name,
                       DescriptionTypeExpense = t.Description,
                       IdStatus = e.IdStatus,
                       NameStatusBudget = s.Name,
                       DescriptionStatusBudget = s.Description
                   }
                 )
                .ToList();
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatusBudget(ExpenseDto expense)
        {
            return (
                    from e in _context.Expenses.AsNoTracking()
                    join t in _context.TypeExpenses.AsNoTracking()
                    on e.IdTypeExpense equals t.IdTypeExpense
                    join s in _context.Status.AsNoTracking()
                    on e.IdStatus equals s.IdStatus
                    where e.IdTypeExpense == expense.IdTypeExpense && e.IdStatus == expense.IdStatus
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        Name = e.Name,
                        Description = e.Description,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.Name,
                        DescriptionTypeExpense = t.Description,
                        IdStatus = e.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}