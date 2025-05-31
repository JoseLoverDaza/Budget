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
    /// Nombre: BudgetDetailsRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDetailsRepository : BaseRepository<BudgetDetails>, IBudgetDetailsRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public BudgetDetailsRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsById(int idBudgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBudgetDetails == idBudgetDetails
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.Year,
                         MonthBudget = b.Month,
                         CreationDate = bd.CreationDate,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,                         
                         NameExpense = e.Name,
                         DescriptionExpense = e.Description,
                         IdStatus = bd.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .FirstOrDefault();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(int idExpense)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == idExpense
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.Year,
                         MonthBudget = b.Month,
                         CreationDate = bd.CreationDate,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.Name,
                         DescriptionExpense = e.Description,
                         IdStatus = bd.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(int idStatus)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdStatus == idStatus
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.Year,
                         MonthBudget = b.Month,
                         CreationDate = bd.CreationDate,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.Name,
                         DescriptionExpense = e.Description,
                         IdStatus = bd.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(int idExpense, int idStatus)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == idExpense && bd.IdStatus == idStatus
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.Year,
                         MonthBudget = b.Month,
                         CreationDate = bd.CreationDate,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.Name,
                         DescriptionExpense = e.Description,
                         IdStatus = bd.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        #endregion

    }
}