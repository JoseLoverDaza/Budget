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
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBudgetDetails == budgetDetails.IdBudgetDetails
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,                        
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.NameExpense,
                         DescriptionExpense = e.DescriptionExpense,
                         IdStatusBudget = bd.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = b.CreationUser,
                         CreationDate = b.CreationDate,
                         ModificationUser = b.ModificationUser,
                         ModificationDate = b.ModificationDate                         
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
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBudget == budgetDetails.IdBudget
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.NameExpense,
                         DescriptionExpense = e.DescriptionExpense,
                         IdStatusBudget = bd.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = b.CreationUser,
                         CreationDate = b.CreationDate,
                         ModificationUser = b.ModificationUser,
                         ModificationDate = b.ModificationDate
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
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdExpense == budgetDetails.IdExpense
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.NameExpense,
                         DescriptionExpense = e.DescriptionExpense,
                         IdStatusBudget = bd.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = b.CreationUser,
                         CreationDate = b.CreationDate,
                         ModificationUser = b.ModificationUser,
                         ModificationDate = b.ModificationDate
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
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdStatusBudget == budgetDetails.IdStatusBudget
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.NameExpense,
                         DescriptionExpense = e.DescriptionExpense,
                         IdStatusBudget = bd.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = b.CreationUser,
                         CreationDate = b.CreationDate,
                         ModificationUser = b.ModificationUser,
                         ModificationDate = b.ModificationDate
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
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBudget == budgetDetails.IdBudget && bd.IdExpense == budgetDetails.IdExpense
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.NameExpense,
                         DescriptionExpense = e.DescriptionExpense,
                         IdStatusBudget = bd.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = b.CreationUser,
                         CreationDate = b.CreationDate,
                         ModificationUser = b.ModificationUser,
                         ModificationDate = b.ModificationDate
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
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdExpense == budgetDetails.IdExpense && bd.IdStatusBudget == budgetDetails.IdStatusBudget
                     select new BudgetDetailExtendDto
                     {
                         IdBudgetDetails = bd.IdBudgetDetails,
                         IdBudget = bd.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         Amount = bd.Amount,
                         IdExpense = bd.IdExpense,
                         NameExpense = e.NameExpense,
                         DescriptionExpense = e.DescriptionExpense,
                         IdStatusBudget = bd.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = b.CreationUser,
                         CreationDate = b.CreationDate,
                         ModificationUser = b.ModificationUser,
                         ModificationDate = b.ModificationDate
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
                    join s in _context.StatusBudget.AsNoTracking()
                    on b.IdStatusBudget equals s.IdStatusBudget
                    where bd.IdBudget == budgetDetails.IdBudget && bd.IdExpense == budgetDetails.IdExpense && bd.IdStatusBudget == budgetDetails.IdStatusBudget
                    select new BudgetDetailExtendDto
                    {
                        IdBudgetDetails = bd.IdBudgetDetails,
                        IdBudget = bd.IdBudget,
                        YearBudget = b.YearBudget,
                        MonthBudget = b.MonthBudget,
                        Amount = bd.Amount,
                        IdExpense = bd.IdExpense,
                        NameExpense = e.NameExpense,
                        DescriptionExpense = e.DescriptionExpense,
                        IdStatusBudget = bd.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = b.CreationUser,
                        CreationDate = b.CreationDate,
                        ModificationUser = b.ModificationUser,
                        ModificationDate = b.ModificationDate
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}