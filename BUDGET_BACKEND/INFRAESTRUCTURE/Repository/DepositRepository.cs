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

        public DepositExtendDto? GetDepositById(int idDeposit)
        {
            return (
                      from d in _context.Deposits.AsNoTracking()
                      join u in _context.Users.AsNoTracking()
                      on d.IdUser equals u.IdUser
                      join a in _context.Accounts.AsNoTracking()
                      on d.IdAccount equals a.IdAccount
                      join s in _context.Status.AsNoTracking()
                      on d.IdStatus equals s.IdStatus
                      where d.IdDeposit == idDeposit
                      select new DepositExtendDto
                      {
                          IdDeposit = d.IdDeposit,
                          Year = d.Year,
                          Month = d.Month,
                          Amount = d.Amount,
                          IdUser = d.IdUser,
                          EmailUser = u.Email,
                          LoginUser = u.Login,
                          IdAccount = d.IdAccount,
                          NameAccount = a.Name,
                          DescriptionAccount = a.Description,
                          IdStatus = d.IdStatus,
                          NameStatus = s.Name,
                          DescriptionStatus = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(int year, int month)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == year && d.Month == month
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUser(int year, int month, int idUser)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == year && d.Month == month && d.IdUser == idUser
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(int year, int month, int idAccount)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == year && d.Month == month && d.IdAccount == idAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatus(int year, int month, int idStatus)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == year && d.Month == month && d.IdStatus == idStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserAccount(int year, int month, int idUser, int idAccount)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.Year == year && d.Month == month && d.IdUser == idUser && d.IdAccount == idAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByUser(int idUser)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdUser == idUser
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByAccount(int idAccount)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdAccount == idAccount
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByStatus(int idStatus)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdStatus == idStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByUserStatus(int idUser, int idStatus)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdUser == idUser && d.IdStatus == idStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<DepositExtendDto> GetDepositsByAccountStatus(int idAccount, int idStatus)
        {
            return (
                    from d in _context.Deposits.AsNoTracking()
                    join u in _context.Users.AsNoTracking()
                    on d.IdUser equals u.IdUser
                    join a in _context.Accounts.AsNoTracking()
                    on d.IdAccount equals a.IdAccount
                    join s in _context.Status.AsNoTracking()
                    on d.IdStatus equals s.IdStatus
                    where d.IdAccount == idAccount && d.IdStatus == idStatus
                    select new DepositExtendDto
                    {
                        IdDeposit = d.IdDeposit,
                        Year = d.Year,
                        Month = d.Month,
                        Amount = d.Amount,
                        IdUser = d.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdAccount = d.IdAccount,
                        NameAccount = a.Name,
                        DescriptionAccount = a.Description,
                        IdStatus = d.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}