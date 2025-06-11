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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByYearUserBudget(BillingDto billing)
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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByMonthUserBudget(BillingDto billing)
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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByYearMonthUserBudget(BillingDto billing)
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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                )
                .ToList();
        }

        public List<BillingExtendDto> GetBillingsByUserBudget(BillingDto billing)
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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByStatusBudget(BillingDto billing)
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
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatus = b.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByUserBudgetStatusBudget(BillingDto billing)
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
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatus = b.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}