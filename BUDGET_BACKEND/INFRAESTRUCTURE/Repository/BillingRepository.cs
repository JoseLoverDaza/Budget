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

        public BillingExtendDto? GetBillingById(int idBilling)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdBilling == idBilling
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
                         LoginUser = u.Login,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .FirstOrDefault();
        }

        public BillingExtendDto? GetBillingByYearMonthUser(int year, int month, int idUser)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Year == year && b.Month == month && b.IdUser == idUser
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
                         LoginUser = u.Login,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                )
                .FirstOrDefault();
        }

        public List<BillingExtendDto> GetBillingsByUser(int idUser)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdUser == idUser
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
                         LoginUser = u.Login,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByStatus(int idStatus)
        {
            return (
                     from b in _context.Billings.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdStatus == idStatus
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
                         LoginUser = u.Login,
                         IdStatus = b.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                   )
                   .ToList();
        }

        public List<BillingExtendDto> GetBillingsByUserStatus(int idUser, int idStatus)
        {
            return (
                    from b in _context.Billings.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on b.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where b.IdUser == idUser && b.IdStatus == idStatus
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
                        LoginUser = u.Login,
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