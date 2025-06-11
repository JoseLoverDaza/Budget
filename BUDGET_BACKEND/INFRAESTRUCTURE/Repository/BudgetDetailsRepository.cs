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

        public BudgetDetailExtendDto? GetBudgetDetailsById(BudgetDetailsDto budgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBudgetDetails == budgetDetails.IdBudgetDetails
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
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .FirstOrDefault();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudget(BudgetDetailsDto budgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBudget == budgetDetails.IdBudget
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
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(BudgetDetailsDto budgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == budgetDetails.IdExpense
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
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(BudgetDetailsDto budgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdStatus == budgetDetails.IdStatus
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
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpense(BudgetDetailsDto budgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBudget == budgetDetails.IdBudget && bd.IdExpense == budgetDetails.IdExpense
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
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(BudgetDetailsDto budgetDetails)
        {
            return (
                     from bd in _context.BudgetDetails.AsNoTracking()
                     join b in _context.Budgets.AsNoTracking()
                     on bd.IdBudget equals b.IdBudget
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == budgetDetails.IdExpense && bd.IdStatus == budgetDetails.IdStatus
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
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .ToList();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpenseStatus(BudgetDetailsDto budgetDetails)
        {
            return (
                    from bd in _context.BudgetDetails.AsNoTracking()
                    join b in _context.Budgets.AsNoTracking()
                    on bd.IdBudget equals b.IdBudget
                    join e in _context.Expenses.AsNoTracking()
                    on bd.IdExpense equals e.IdExpense
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where bd.IdBudget == budgetDetails.IdBudget && bd.IdExpense == budgetDetails.IdExpense && bd.IdStatus == budgetDetails.IdStatus
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
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
               )
               .ToList();
        }

        #endregion

    }
}