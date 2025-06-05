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

        public BudgetExtendDto? GetBudgetById(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdBudget == budget.IdBudget
                     select new BudgetExtendDto
                     {
                        IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearMonth(BudgetDto budget)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on b.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where b.Year == budget.Year && b.Month == budget.Month
                    select new BudgetExtendDto
                    {
                        IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearUser(BudgetDto budget)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on b.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where b.Year == budget.Year && b.IdUser == budget.IdUser
                    select new BudgetExtendDto
                    {
                        IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByMonthUser(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Month == budget.Month && b.IdUser == budget.IdUser
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearMonthUser(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.Year == budget.Year && b.Month == budget.Month && b.IdUser == budget.IdUser
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByUser(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.Users.AsNoTracking()
                     on b.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on b.IdStatus equals s.IdStatus
                     where b.IdUser == budget.IdUser
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByStatus(BudgetDto budget)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on b.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on b.IdStatus equals s.IdStatus
                    where b.IdStatus == budget.IdStatus
                    select new BudgetExtendDto
                    {
                        IdBudget = b.IdBudget,
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

        public List<BudgetExtendDto> GetBudgetsByUserStatus(BudgetDto budget)
        {
            return (
                   from b in _context.Budgets.AsNoTracking()
                   join u in _context.Users.AsNoTracking()
                   on b.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on b.IdStatus equals s.IdStatus
                   where b.IdUser == budget.IdUser && b.IdStatus == budget.IdStatus
                   select new BudgetExtendDto
                   {
                       IdBudget = b.IdBudget,
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