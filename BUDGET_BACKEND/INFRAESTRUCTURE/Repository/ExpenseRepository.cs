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
                    join s in _context.StatusBudget.AsNoTracking()
                    on e.IdStatusBudget equals s.IdStatusBudget
                    where e.IdExpense == expense.IdExpense
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        NameExpense = e.NameExpense,
                        DescriptionExpense = e.DescriptionExpense,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.NameTypeExpense,
                        DescriptionTypeExpense = t.DescriptionTypeExpense,
                        IdStatusBudget = e.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = e.CreationUser,
                        CreationDate = e.CreationDate,
                        ModificationUser = e.ModificationUser,
                        ModificationDate = e.ModificationDate                        
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
                    join s in _context.StatusBudget.AsNoTracking()
                    on e.IdStatusBudget equals s.IdStatusBudget
                    where e.IdTypeExpense == expense.IdTypeExpense
                    select new ExpenseExtendDto
                    {
                       IdExpense = e.IdExpense,
                       NameExpense = e.NameExpense,
                       DescriptionExpense = e.DescriptionExpense,
                       IdTypeExpense = t.IdTypeExpense,
                       NameTypeExpense = t.NameTypeExpense,
                       DescriptionTypeExpense = t.DescriptionTypeExpense,
                       IdStatusBudget = e.IdStatusBudget,
                       NameStatusBudget = s.NameStatus,
                       DescriptionStatusBudget = s.DescriptionStatus,
                       CreationUser = e.CreationUser,
                       CreationDate = e.CreationDate,
                       ModificationUser = e.ModificationUser,
                       ModificationDate = e.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<ExpenseExtendDto> GetExpensesByStatusBudget(ExpenseDto expense)
        {
            return (
                    from e in _context.Expenses.AsNoTracking()
                    join t in _context.TypeExpenses.AsNoTracking()
                    on e.IdTypeExpense equals t.IdTypeExpense
                    join s in _context.StatusBudget.AsNoTracking()
                    on e.IdStatusBudget equals s.IdStatusBudget
                    where e.IdStatusBudget == expense.IdStatusBudget
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        NameExpense = e.NameExpense,
                        DescriptionExpense = e.DescriptionExpense,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.NameTypeExpense,
                        DescriptionTypeExpense = t.DescriptionTypeExpense,
                        IdStatusBudget = e.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = e.CreationUser,
                        CreationDate = e.CreationDate,
                        ModificationUser = e.ModificationUser,
                        ModificationDate = e.ModificationDate
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
                    join s in _context.StatusBudget.AsNoTracking()
                    on e.IdStatusBudget equals s.IdStatusBudget
                    where e.NameExpense == expense.NameExpense && e.IdTypeExpense == expense.IdTypeExpense
                    select new ExpenseExtendDto
                    {
                       IdExpense = e.IdExpense,
                       NameExpense = e.NameExpense,
                       DescriptionExpense = e.DescriptionExpense,
                       IdTypeExpense = t.IdTypeExpense,
                       NameTypeExpense = t.NameTypeExpense,
                       DescriptionTypeExpense = t.DescriptionTypeExpense,
                       IdStatusBudget = e.IdStatusBudget,
                       NameStatusBudget = s.NameStatus,
                       DescriptionStatusBudget = s.DescriptionStatus,
                       CreationUser = e.CreationUser,
                       CreationDate = e.CreationDate,
                       ModificationUser = e.ModificationUser,
                       ModificationDate = e.ModificationDate
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
                    join s in _context.StatusBudget.AsNoTracking()
                    on e.IdStatusBudget equals s.IdStatusBudget
                    where e.IdTypeExpense == expense.IdTypeExpense && e.IdStatusBudget == expense.IdStatusBudget
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        NameExpense = e.NameExpense,
                        DescriptionExpense = e.DescriptionExpense,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.NameTypeExpense,
                        DescriptionTypeExpense = t.DescriptionTypeExpense,
                        IdStatusBudget = e.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = e.CreationUser,
                        CreationDate = e.CreationDate,
                        ModificationUser = e.ModificationUser,
                        ModificationDate = e.ModificationDate
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}