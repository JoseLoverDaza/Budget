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

        public BillingExtendDto? GetBillingById(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdBilling == billing.IdBilling
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .FirstOrDefault();
        }

        public List<BillingExtendDto> GetBillingsByYearMonth(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Year == billing.Year && b.Month == billing.Month
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByYearUser(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Year == billing.Year && b.IdUser == billing.IdUser
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByMonthUser(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Month == billing.Month && b.IdUser == billing.IdUser
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByYearMonthUser(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Year == billing.Year && b.Month == billing.Month && b.IdUser == billing.IdUser
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .ToList();
        }

        public List<BillingExtendDto> GetBillingsByUser(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdUser == billing.IdUser
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByStatus(BillingDto billing)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdStatus == billing.IdStatus
                     select new BillingExtendDto
                     {
                         IdBilling = b.IdBilling,
                         Year = b.Year,
                         Month = b.Month,
                         CreationDate = b.CreationDate,
                         Description = b.Description,
                         Observation = b.Observation,
                         IdUser = b.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByUserStatus(BillingDto billing)
        {
            return (
                    from b in _context.Billings.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on b.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where b.IdUser == billing.IdUser && b.IdStatus == billing.IdStatus
                    select new BillingExtendDto
                    {
                        IdBilling = b.IdBilling,
                        Year = b.Year,
                        Month = b.Month,
                        CreationDate = b.CreationDate,
                        Description = b.Description,
                        Observation = b.Observation,
                        IdUser = b.IdUser,
                        EmailUser = u.Email,
                        UsernameUser = u.Username,
                        IdStatus = b.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}