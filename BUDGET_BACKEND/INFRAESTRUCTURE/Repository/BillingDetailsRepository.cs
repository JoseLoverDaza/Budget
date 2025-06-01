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

        public BillingDetailExtendDto? GetBillingDetailsById(int idBillingDetails)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBillingDetails == idBillingDetails
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
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .FirstOrDefault();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(int idBilling)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBilling == idBilling
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
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(int idExpense)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == idExpense
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
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByStatus(int idStatus)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdStatus == idStatus
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
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(int idBilling, int idExpense)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdBilling == idBilling && bd.IdExpense == idExpense
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
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatus(int idExpense, int idStatus)
        {
            return (
                     from bd in _context.BillingDetails.AsNoTracking()
                     join b in _context.Billings.AsNoTracking()
                     on bd.IdBilling equals b.IdBilling
                     join e in _context.Expenses.AsNoTracking()
                     on bd.IdExpense equals e.IdExpense
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where bd.IdExpense == idExpense && bd.IdStatus == idStatus
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
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        #endregion

    }
}