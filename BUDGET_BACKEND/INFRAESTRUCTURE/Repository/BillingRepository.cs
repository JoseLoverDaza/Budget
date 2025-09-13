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
    /// Nombre: BillingRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingRepository : BaseRepository<Billing>, IBillingRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public BillingRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingByIdBilling(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.IdBilling == billing.IdBilling
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,                         
                         DescriptionBilling = b.DescriptionBilling,
                         ObservationBilling = b.ObservationBilling,
                         IdUserBudget = b.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByYearMonth(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.YearBilling == billing.YearBilling && b.MonthBilling == billing.MonthBilling
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
                         DescriptionBilling = b.DescriptionBilling,
                         ObservationBilling = b.ObservationBilling,
                         IdUserBudget = b.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByYearMonthStatusBudget(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.YearBilling == billing.YearBilling && b.MonthBilling == billing.MonthBilling
                     && b.IdStatusBudget == billing.IdStatusBudget
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
                         DescriptionBilling = b.DescriptionBilling,
                         ObservationBilling = b.ObservationBilling,
                         IdUserBudget = b.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByYearUserBudget(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.YearBilling == billing.YearBilling && b.IdUserBudget == billing.IdUserBudget
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
                         DescriptionBilling = b.DescriptionBilling,
                         ObservationBilling = b.ObservationBilling,
                         IdUserBudget = b.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByMonthUserBudget(BillingDto billing)
        {
            return (
                    from b in _context.Billings.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on b.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on b.IdStatusBudget equals s.IdStatusBudget
                    where b.MonthBilling == billing.MonthBilling && b.IdUserBudget == billing.IdUserBudget
                    select new BillingExtendDto
                    {
                        IdBilling = b.IdBilling,
                        YearBilling = b.YearBilling,
                        MonthBilling = b.MonthBilling,
                        DescriptionBilling = b.DescriptionBilling,
                        ObservationBilling = b.ObservationBilling,
                        IdUserBudget = b.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByYearMonthUserBudget(BillingDto billing)
        {
            return (
                    from b in _context.Billings.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on b.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on b.IdStatusBudget equals s.IdStatusBudget
                    where b.YearBilling == billing.YearBilling && b.MonthBilling == billing.MonthBilling && b.IdUserBudget == billing.IdUserBudget
                    select new BillingExtendDto
                    {
                        IdBilling = b.IdBilling,
                        YearBilling = b.YearBilling,
                        MonthBilling = b.MonthBilling,
                        DescriptionBilling = b.DescriptionBilling,
                        ObservationBilling = b.ObservationBilling,
                        IdUserBudget = b.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByUserBudget(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.IdUserBudget == billing.IdUserBudget
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
                         DescriptionBilling = b.DescriptionBilling,
                         ObservationBilling = b.ObservationBilling,
                         IdUserBudget = b.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByStatusBudget(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.IdStatusBudget == billing.IdStatusBudget
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         YearBilling = b.YearBilling,
                         MonthBilling = b.MonthBilling,
                         DescriptionBilling = b.DescriptionBilling,
                         ObservationBilling = b.ObservationBilling,
                         IdUserBudget = b.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = b.IdStatusBudget,
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

        public List<BillingExtendDto> GetBillingsByUserBudgetStatusBudget(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.IdUserBudget == billing.IdUserBudget && b.IdStatusBudget == billing.IdStatusBudget
                     select new BillingExtendDto
                     {
                        IdBilling = b.IdBilling,
                        YearBilling = b.YearBilling,
                        MonthBilling = b.MonthBilling,
                        DescriptionBilling = b.DescriptionBilling,
                        ObservationBilling = b.ObservationBilling,
                        IdUserBudget = b.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = b.IdStatusBudget,
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