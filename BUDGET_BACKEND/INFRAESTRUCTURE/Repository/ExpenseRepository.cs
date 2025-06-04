namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using Domain.Context;
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

        public ExpenseExtendDto? GetExpenseById(int idExpense)
        {
            return (
                       from e in _context.Expenses.AsNoTracking()
                       join t in _context.TypeExpenses.AsNoTracking()
                       on e.IdTypeExpense equals t.IdTypeExpense
                       join s in _context.Status.AsNoTracking()
                       on e.IdStatus equals s.IdStatus
                       where e.IdExpense == idExpense
                       select new ExpenseExtendDto
                       {
                           IdExpense = e.IdExpense,
                           Name = e.Name,
                           Description = e.Description,
                           IdTypeExpense = t.IdTypeExpense,
                           NameTypeExpense = t.Name,
                           DescriptionTypeExpense = t.Description,
                           IdStatus = e.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public ExpenseExtendDto? GetExpenseByName(string name)
        {
            return (
                       from e in _context.Expenses.AsNoTracking()
                       join t in _context.TypeExpenses.AsNoTracking()
                       on e.IdTypeExpense equals t.IdTypeExpense
                       join s in _context.Status.AsNoTracking()
                       on e.IdStatus equals s.IdStatus
                       where e.Name == name
                       select new ExpenseExtendDto
                       {
                           IdExpense = e.IdExpense,
                           Name = e.Name,
                           Description = e.Description,
                           IdTypeExpense = t.IdTypeExpense,
                           NameTypeExpense = t.Name,
                           DescriptionTypeExpense = t.Description,
                           IdStatus = e.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(int idTypeExpense)
        {
            return (
                   from e in _context.Expenses.AsNoTracking()
                   join t in _context.TypeExpenses.AsNoTracking()
                   on e.IdTypeExpense equals t.IdTypeExpense
                   join s in _context.Status.AsNoTracking()
                   on e.IdStatus equals s.IdStatus
                   where e.IdTypeExpense == idTypeExpense
                   select new ExpenseExtendDto
                   {
                       IdExpense = e.IdExpense,
                       Name = e.Name,
                       Description = e.Description,
                       IdTypeExpense = t.IdTypeExpense,
                       NameTypeExpense = t.Name,
                       DescriptionTypeExpense = t.Description,
                       IdStatus = e.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                 )
                .ToList();
        }

        public List<ExpenseExtendDto> GetExpensesByStatus(int idStatus)
        {
            return (
                    from e in _context.Expenses.AsNoTracking()
                    join t in _context.TypeExpenses.AsNoTracking()
                    on e.IdTypeExpense equals t.IdTypeExpense
                    join s in _context.Status.AsNoTracking()
                    on e.IdStatus equals s.IdStatus
                    where e.IdStatus == idStatus
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        Name = e.Name,
                        Description = e.Description,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.Name,
                        DescriptionTypeExpense = t.Description,
                        IdStatus = e.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatus(int idTypeExpense, int idStatus)
        {
            return (
                    from e in _context.Expenses.AsNoTracking()
                    join t in _context.TypeExpenses.AsNoTracking()
                    on e.IdTypeExpense equals t.IdTypeExpense
                    join s in _context.Status.AsNoTracking()
                    on e.IdStatus equals s.IdStatus
                    where e.IdTypeExpense == idTypeExpense && e.IdStatus == idStatus
                    select new ExpenseExtendDto
                    {
                        IdExpense = e.IdExpense,
                        Name = e.Name,
                        Description = e.Description,
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.Name,
                        DescriptionTypeExpense = t.Description,
                        IdStatus = e.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}