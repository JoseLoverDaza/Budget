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
    /// Nombre: DepositRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositRepository : BaseRepository<Deposit>, IDepositRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public DepositRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositByIdDeposit(DepositDto deposit)
        {
            return (
                      from d in _context.Deposits.AsNoTracking()
                      join u in _context.UsersBudget.AsNoTracking()
                      on d.IdUserBudget equals u.IdUserBudget
                      join a in _context.Accounts.AsNoTracking()
                      on d.IdAccount equals a.IdAccount
                      join s in _context.StatusBudget.AsNoTracking()
                      on d.IdStatusBudget equals s.IdStatusBudget
                      where d.IdDeposit == deposit.IdDeposit
                      select new DepositExtendDto
                      {
                          IdDeposit = d.IdDeposit,
                          YearDeposit = d.YearDeposit,
                          MonthDeposit = d.MonthDeposit,
                          Amount = d.Amount,
                          IdUserBudget = d.IdUserBudget,
                          EmailUserBudget = u.Email,
                          UsernameUserBudget = u.Username,
                          IdAccount = d.IdAccount,
                          NameAccount = a.NameAccount,
                          DescriptionAccount = a.DescriptionAccount,
                          IdStatusBudget = d.IdStatusBudget,
                          NameStatusBudget = s.NameStatus,
                          DescriptionStatusBudget = s.DescriptionStatus,
                          CreationUser = d.CreationUser,
                          CreationDate = d.CreationDate,
                          ModificationUser = d.ModificationUser,
                          ModificationDate = d.ModificationDate
                      }
                  )
                  .FirstOrDefault();
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.YearDeposit == deposit.YearDeposit && d.MonthDeposit == deposit.MonthDeposit
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.YearDeposit == deposit.YearDeposit && d.IdUserBudget == deposit.IdUserBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByMonthUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.MonthDeposit == deposit.MonthDeposit && d.IdUserBudget == deposit.IdUserBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.YearDeposit == deposit.YearDeposit && d.MonthDeposit == deposit.MonthDeposit && d.IdUserBudget == deposit.IdUserBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.YearDeposit == deposit.YearDeposit && d.MonthDeposit == deposit.MonthDeposit && d.IdAccount == deposit.IdAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.YearDeposit == deposit.YearDeposit && d.MonthDeposit == deposit.MonthDeposit && d.IdStatusBudget == deposit.IdStatusBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudgetAccount(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.YearDeposit == deposit.YearDeposit && d.MonthDeposit == deposit.MonthDeposit && d.IdUserBudget == deposit.IdUserBudget && d.IdAccount == deposit.IdAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.IdUserBudget == deposit.IdUserBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByAccount(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.IdAccount == deposit.IdAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.IdStatusBudget == deposit.IdStatusBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByUserBudgetStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.IdUserBudget == deposit.IdUserBudget && d.IdStatusBudget == deposit.IdStatusBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<DepositExtendDto> GetDepositsByAccountStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on d.IdUserBudget equals u.IdUserBudget
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.StatusBudget.AsNoTracking()
                    on d.IdStatusBudget equals s.IdStatusBudget
                    where d.IdAccount == deposit.IdAccount && d.IdStatusBudget == deposit.IdStatusBudget
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        YearDeposit = d.YearDeposit,
                        MonthDeposit = d.MonthDeposit,
                        Amount = d.Amount,
                        IdUserBudget = d.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdStatusBudget = d.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = d.CreationUser,
                        CreationDate = d.CreationDate,
                        ModificationUser = d.ModificationUser,
                        ModificationDate = d.ModificationDate
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}