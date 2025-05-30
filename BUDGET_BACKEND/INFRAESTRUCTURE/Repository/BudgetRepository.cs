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
    /// Nombre: BudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetRepository : BaseRepository<Budget>, IBudgetRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public BudgetRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetById(int idBudget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdBudget == idBudget
                     select new BudgetExtendDto
                     {
                        IdBudget = b.IdBudget,
                        Year = b.Year,
                        Month = b.Month,
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

        public BudgetExtendDto? GetBudgetByYearMonthUser(int year, int month, int idUser)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Year == year && b.Month == month && b.IdUser == idUser
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
                         Year = b.Year,
                         Month = b.Month,
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

        public List<BudgetExtendDto> GetBudgetsByUser(int idUser)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdUser == idUser
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
                         Year = b.Year,
                         Month = b.Month,
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

        public List<BudgetExtendDto> GetBudgetsByStatus(int idStatus)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on b.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where b.IdStatus == idStatus
                    select new BudgetExtendDto
                    {
                        IdBudget = b.IdBudget,
                        Year = b.Year,
                        Month = b.Month,
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

        public List<BudgetExtendDto> GetBudgetsByUserStatus(int idUser, int idStatus)
        {
            return (
                   from b in _context.Budgets.AsNoTracking()
                   join u in _context.Users.AsNoTracking()
                   on b.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on b.IdStatus equals s.IdStatus
                   where b.IdUser == idUser && b.IdStatus == idStatus
                   select new BudgetExtendDto
                   {
                       IdBudget = b.IdBudget,
                       Year = b.Year,
                       Month = b.Month,
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