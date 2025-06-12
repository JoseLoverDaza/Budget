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
    /// Nombre: BillingDetailsRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDetailsRepository : BaseRepository<BillingDetails>, IBillingDetailsRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public BillingDetailsRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public BillingDetailExtendDto? GetBillingDetailsByIdBillingDetails(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBillingDetails == billingDetails.IdBillingDetails
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,                       
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

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBilling == billingDetails.IdBilling
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdExpense == billingDetails.IdExpense
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByStatusBudget(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdStatusBudget == billingDetails.IdStatusBudget
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBilling == billingDetails.IdBilling && bd.IdExpense == billingDetails.IdExpense
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatusBudget(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdExpense == billingDetails.IdExpense && bd.IdStatusBudget == billingDetails.IdStatusBudget
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpenseStatusBudget(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where bd.IdBilling == billingDetails.IdBilling && bd.IdExpense == billingDetails.IdExpense && bd.IdStatusBudget == billingDetails.IdStatusBudget
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
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