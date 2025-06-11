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
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBillingDetails == billingDetails.IdBillingDetails
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBilling == billingDetails.IdBilling
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == billingDetails.IdExpense
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByStatusBudget(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdStatus == billingDetails.IdStatus
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBilling == billingDetails.IdBilling && bd.IdExpense == billingDetails.IdExpense
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatusBudget(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == billingDetails.IdExpense && bd.IdStatus == billingDetails.IdStatus
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpenseStatusBudget(BillingDetailsDto billingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBilling == billingDetails.IdBilling && bd.IdExpense == billingDetails.IdExpense && bd.IdStatus == billingDetails.IdStatus
                     select new BillingDetailExtendDto
                     {
                         IdBillingDetails = bd.IdBillingDetails,
                         IdBilling = bd.IdBilling,
                         YearBilling = b.Year,
                         MonthBilling = b.Month,
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