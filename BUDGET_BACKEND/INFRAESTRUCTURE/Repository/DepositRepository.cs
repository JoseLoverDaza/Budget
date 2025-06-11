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
                      join u in _context.Users.AsNoTracking()
                      on d.IdUser equals u.IdUser
                      join a in _context.Accounts.AsNoTracking()
                      on d.IdAccount equals a.IdAccount
                      join s in _context.Status.AsNoTracking()
                      on d.IdStatus equals s.IdStatus
                      where d.IdDeposit == deposit.IdDeposit
                      select new DepositExtendDto
                      {
                          IdDeposit = d.IdDeposit,
                          Year = d.Year,
                          Month = d.Month,
                          Amount = d.Amount,
                          IdUser = d.IdUser,
                          EmailUserBudget = u.Email,
                          UsernameUserBudget = u.Username,
                          IdAccount = d.IdAccount,
                          NameAccount = a.Name,
                          DescriptionAccount = a.Description,
                          IdStatus = d.IdStatus,
                          NameStatusBudget = s.Name,
                          DescriptionStatusBudget = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == deposit.Year && d.Month == deposit.Month
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == deposit.Year && d.IdUser == deposit.IdUser
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByMonthUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Month == deposit.Month && d.IdUser == deposit.IdUser
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == deposit.Year && d.Month == deposit.Month && d.IdUser == deposit.IdUser
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == deposit.Year && d.Month == deposit.Month && d.IdAccount == deposit.IdAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == deposit.Year && d.Month == deposit.Month && d.IdStatus == deposit.IdStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudgetAccount(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == deposit.Year && d.Month == deposit.Month && d.IdUser == deposit.IdUser && d.IdAccount == deposit.IdAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByUserBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdUser == deposit.IdUser
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByAccount(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdAccount == deposit.IdAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdStatus == deposit.IdStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByUserBudgetStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdUser == deposit.IdUser && d.IdStatus == deposit.IdStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByAccountStatusBudget(DepositDto deposit)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdAccount == deposit.IdAccount && d.IdStatus == deposit.IdStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatusBudget = s.Name,
                        DescriptionStatusBudget = s.Description
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}