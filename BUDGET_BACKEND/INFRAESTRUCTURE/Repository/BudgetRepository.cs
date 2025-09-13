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

        public BudgetExtendDto? GetBudgetByIdBudget(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.IdBudget == budget.IdBudget
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,                         
                         DescriptionBudget = b.DescriptionBudget,
                         ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearMonth(BudgetDto budget)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on b.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on b.IdStatusBudget equals s.IdStatusBudget
                    where b.YearBudget == budget.YearBudget && b.MonthBudget == budget.MonthBudget
                    select new BudgetExtendDto
                    {
                        IdBudget = b.IdBudget,
                        YearBudget = b.YearBudget,
                        MonthBudget = b.MonthBudget,
                        DescriptionBudget = b.DescriptionBudget,
                        ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearMonthStatusBudget(BudgetDto budget)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on b.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on b.IdStatusBudget equals s.IdStatusBudget
                    where b.YearBudget == budget.YearBudget && b.MonthBudget == budget.MonthBudget
                    && b.IdStatusBudget == budget.IdStatusBudget
                    select new BudgetExtendDto
                    {
                        IdBudget = b.IdBudget,
                        YearBudget = b.YearBudget,
                        MonthBudget = b.MonthBudget,
                        DescriptionBudget = b.DescriptionBudget,
                        ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearUserBudget(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.YearBudget == budget.YearBudget && b.IdUserBudget == budget.IdUserBudget
                     select new BudgetExtendDto
                     {
                        IdBudget = b.IdBudget,
                        YearBudget = b.YearBudget,
                        MonthBudget = b.MonthBudget,
                        DescriptionBudget = b.DescriptionBudget,
                        ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByMonthUserBudget(BudgetDto budget)
        {
            return (
                      from b in _context.Budgets.AsNoTracking()
                      join u in _context.UsersBudget.AsNoTracking()
                      on b.IdUserBudget equals u.IdUserBudget
                      join s in _context.StatusBudget.AsNoTracking()
                      on b.IdStatusBudget equals s.IdStatusBudget
                      where b.MonthBudget == budget.MonthBudget && b.IdUserBudget == budget.IdUserBudget
                      select new BudgetExtendDto
                      {
                         IdBudget = b.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         DescriptionBudget = b.DescriptionBudget,
                         ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByYearMonthUserBudget(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.YearBudget == budget.YearBudget && b.MonthBudget == budget.MonthBudget && b.IdUserBudget == budget.IdUserBudget
                     select new BudgetExtendDto
                     {
                         IdBudget = b.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         DescriptionBudget = b.DescriptionBudget,
                         ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByUserBudget(BudgetDto budget)
        {
            return (
                      from b in _context.Budgets.AsNoTracking()
                      join u in _context.UsersBudget.AsNoTracking()
                      on b.IdUserBudget equals u.IdUserBudget
                      join s in _context.StatusBudget.AsNoTracking()
                      on b.IdStatusBudget equals s.IdStatusBudget
                      where b.IdUserBudget == budget.IdUserBudget
                      select new BudgetExtendDto
                      {
                         IdBudget = b.IdBudget,
                         YearBudget = b.YearBudget,
                         MonthBudget = b.MonthBudget,
                         DescriptionBudget = b.DescriptionBudget,
                         ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByStatusBudget(BudgetDto budget)
        {
            return (
                     from b in _context.Budgets.AsNoTracking()
                     join u in _context.UsersBudget.AsNoTracking()
                     on b.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on b.IdStatusBudget equals s.IdStatusBudget
                     where b.IdStatusBudget == budget.IdStatusBudget
                     select new BudgetExtendDto
                     {
                        IdBudget = b.IdBudget,
                        YearBudget = b.YearBudget,
                        MonthBudget = b.MonthBudget,
                        DescriptionBudget = b.DescriptionBudget,
                        ObservationBudget = b.ObservationBudget,
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

        public List<BudgetExtendDto> GetBudgetsByUserBudgetStatusBudget(BudgetDto budget)
        {
            return (
                    from b in _context.Budgets.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on b.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on b.IdStatusBudget equals s.IdStatusBudget
                    where b.IdUserBudget == budget.IdUserBudget && b.IdStatusBudget == budget.IdStatusBudget
                    select new BudgetExtendDto
                    {
                       IdBudget = b.IdBudget,
                       YearBudget = b.YearBudget,
                       MonthBudget = b.MonthBudget,
                       DescriptionBudget = b.DescriptionBudget,
                       ObservationBudget = b.ObservationBudget,
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