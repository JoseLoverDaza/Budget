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
    /// Nombre: AccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public AccountRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public AccountExtendDto? GetAccountById(AccountDto account)
        {
            return (
                     from a in _context.Accounts.AsNoTracking()
                     join f in _context.FinancialInstitutions.AsNoTracking()
                     on a.IdFinancialInstitution equals f.IdFinancialInstitution
                     join t in _context.TypeAccounts.AsNoTracking()
                     on a.IdTypeAccount equals t.IdTypeAccount
                     join u in _context.Users.AsNoTracking()
                     on a.IdUser equals u.IdUser
                     join s in _context.Status.AsNoTracking()
                     on a.IdStatus equals s.IdStatus
                     where a.IdAccount == account.IdAccount
                     select new AccountExtendDto
                     {
                         IdAccount = a.IdAccount,
                         Name = a.Name,
                         Description = a.Description,
                         IdFinancialInstitution = a.IdFinancialInstitution,
                         NameFinancialInstitution = f.Name,
                         DescriptionFinancialInstitution = f.Description,
                         IdTypeAccount = a.IdTypeAccount,
                         NameTypeAccount = t.Name,
                         DescriptionTypeAccount = t.Description,
                         IdUser = a.IdUser,
                         EmailUser = u.Email,
                         UsernameUser = u.Username,
                         IdStatus = a.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                 )
                 .FirstOrDefault();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.Users.AsNoTracking()
                    on a.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on a.IdStatus equals s.IdStatus
                    where a.IdFinancialInstitution == account.IdFinancialInstitution
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        Name = a.Name,
                        Description = a.Description,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.Name,
                        DescriptionFinancialInstitution = f.Description,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.Name,
                        DescriptionTypeAccount = t.Description,
                        IdUser = a.IdUser,
                        EmailUser = u.Email,
                        UsernameUser = u.Username,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccount(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.Users.AsNoTracking()
                    on a.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on a.IdStatus equals s.IdStatus
                    where a.IdTypeAccount == account.IdTypeAccount
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        Name = a.Name,
                        Description = a.Description,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.Name,
                        DescriptionFinancialInstitution = f.Description,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.Name,
                        DescriptionTypeAccount = t.Description,
                        IdUser = a.IdUser,
                        EmailUser = u.Email,
                        UsernameUser = u.Username,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByUser(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.Users.AsNoTracking()
                    on a.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on a.IdStatus equals s.IdStatus
                    where a.IdUser == account.IdUser
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        Name = a.Name,
                        Description = a.Description,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.Name,
                        DescriptionFinancialInstitution = f.Description,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.Name,
                        DescriptionTypeAccount = t.Description,
                        IdUser = a.IdUser,
                        EmailUser = u.Email,
                        UsernameUser = u.Username,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByStatus(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.Users.AsNoTracking()
                    on a.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on a.IdStatus equals s.IdStatus
                    where a.IdStatus == account.IdStatus
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        Name = a.Name,
                        Description = a.Description,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.Name,
                        DescriptionFinancialInstitution = f.Description,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.Name,
                        DescriptionTypeAccount = t.Description,
                        IdUser = a.IdUser,
                        EmailUser = u.Email,
                        UsernameUser = u.Username,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(AccountDto account)
        {
            return (
                   from a in _context.Accounts.AsNoTracking()
                   join f in _context.FinancialInstitutions.AsNoTracking()
                   on a.IdFinancialInstitution equals f.IdFinancialInstitution
                   join t in _context.TypeAccounts.AsNoTracking()
                   on a.IdTypeAccount equals t.IdTypeAccount
                   join u in _context.Users.AsNoTracking()
                   on a.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on a.IdStatus equals s.IdStatus
                   where a.IdFinancialInstitution == account.IdFinancialInstitution && a.IdStatus == account.IdStatus
                   select new AccountExtendDto
                   {
                       IdAccount = a.IdAccount,
                       Name = a.Name,
                       Description = a.Description,
                       IdFinancialInstitution = a.IdFinancialInstitution,
                       NameFinancialInstitution = f.Name,
                       DescriptionFinancialInstitution = f.Description,
                       IdTypeAccount = a.IdTypeAccount,
                       NameTypeAccount = t.Name,
                       DescriptionTypeAccount = t.Description,
                       IdUser = a.IdUser,
                       EmailUser = u.Email,
                       UsernameUser = u.Username,
                       IdStatus = a.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                 )
                .ToList();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(AccountDto account)
        {
            return (
                  from a in _context.Accounts.AsNoTracking()
                  join f in _context.FinancialInstitutions.AsNoTracking()
                  on a.IdFinancialInstitution equals f.IdFinancialInstitution
                  join t in _context.TypeAccounts.AsNoTracking()
                  on a.IdTypeAccount equals t.IdTypeAccount
                  join u in _context.Users.AsNoTracking()
                  on a.IdUser equals u.IdUser
                  join s in _context.Status.AsNoTracking()
                  on a.IdStatus equals s.IdStatus
                  where a.IdTypeAccount == account.IdTypeAccount && a.IdStatus == account.IdStatus
                  select new AccountExtendDto
                  {
                      IdAccount = a.IdAccount,
                      Name = a.Name,
                      Description = a.Description,
                      IdFinancialInstitution = a.IdFinancialInstitution,
                      NameFinancialInstitution = f.Name,
                      DescriptionFinancialInstitution = f.Description,
                      IdTypeAccount = a.IdTypeAccount,
                      NameTypeAccount = t.Name,
                      DescriptionTypeAccount = t.Description,
                      IdUser = a.IdUser,
                      EmailUser = u.Email,
                      UsernameUser = u.Username,
                      IdStatus = a.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
                )
               .ToList();
        }

        public List<AccountExtendDto> GetAccountsByUserStatus(AccountDto account)
        {
            return (
                  from a in _context.Accounts.AsNoTracking()
                  join f in _context.FinancialInstitutions.AsNoTracking()
                  on a.IdFinancialInstitution equals f.IdFinancialInstitution
                  join t in _context.TypeAccounts.AsNoTracking()
                  on a.IdTypeAccount equals t.IdTypeAccount
                  join u in _context.Users.AsNoTracking()
                  on a.IdUser equals u.IdUser
                  join s in _context.Status.AsNoTracking()
                  on a.IdStatus equals s.IdStatus
                  where a.IdUser == account.IdUser && a.IdStatus == account.IdStatus
                  select new AccountExtendDto
                  {
                      IdAccount = a.IdAccount,
                      Name = a.Name,
                      Description = a.Description,
                      IdFinancialInstitution = a.IdFinancialInstitution,
                      NameFinancialInstitution = f.Name,
                      DescriptionFinancialInstitution = f.Description,
                      IdTypeAccount = a.IdTypeAccount,
                      NameTypeAccount = t.Name,
                      DescriptionTypeAccount = t.Description,
                      IdUser = a.IdUser,
                      EmailUser = u.Email,
                      UsernameUser = u.Username,
                      IdStatus = a.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
                )
               .ToList();
        }

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUser(AccountDto account)
        {
            return (
                 from a in _context.Accounts.AsNoTracking()
                 join f in _context.FinancialInstitutions.AsNoTracking()
                 on a.IdFinancialInstitution equals f.IdFinancialInstitution
                 join t in _context.TypeAccounts.AsNoTracking()
                 on a.IdTypeAccount equals t.IdTypeAccount
                 join u in _context.Users.AsNoTracking()
                 on a.IdUser equals u.IdUser
                 join s in _context.Status.AsNoTracking()
                 on a.IdStatus equals s.IdStatus
                 where a.Name == account.Name && a.IdFinancialInstitution == account.IdFinancialInstitution && a.IdTypeAccount == account.IdTypeAccount && a.IdUser == account.IdUser
                 select new AccountExtendDto
                 {
                     IdAccount = a.IdAccount,
                     Name = a.Name,
                     Description = a.Description,
                     IdFinancialInstitution = a.IdFinancialInstitution,
                     NameFinancialInstitution = f.Name,
                     DescriptionFinancialInstitution = f.Description,
                     IdTypeAccount = a.IdTypeAccount,
                     NameTypeAccount = t.Name,
                     DescriptionTypeAccount = t.Description,
                     IdUser = a.IdUser,
                     EmailUser = u.Email,
                     UsernameUser = u.Username,
                     IdStatus = a.IdStatus,
                     NameStatus = s.Name,
                     DescriptionStatus = s.Description
                 }
               )
              .ToList();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUser(AccountDto account)
        {
            return (
                 from a in _context.Accounts.AsNoTracking()
                 join f in _context.FinancialInstitutions.AsNoTracking()
                 on a.IdFinancialInstitution equals f.IdFinancialInstitution
                 join t in _context.TypeAccounts.AsNoTracking()
                 on a.IdTypeAccount equals t.IdTypeAccount
                 join u in _context.Users.AsNoTracking()
                 on a.IdUser equals u.IdUser
                 join s in _context.Status.AsNoTracking()
                 on a.IdStatus equals s.IdStatus
                 where a.IdFinancialInstitution == account.IdFinancialInstitution && a.IdTypeAccount == account.IdTypeAccount && a.IdUser == account.IdUser
                 select new AccountExtendDto
                 {
                     IdAccount = a.IdAccount,
                     Name = a.Name,
                     Description = a.Description,
                     IdFinancialInstitution = a.IdFinancialInstitution,
                     NameFinancialInstitution = f.Name,
                     DescriptionFinancialInstitution = f.Description,
                     IdTypeAccount = a.IdTypeAccount,
                     NameTypeAccount = t.Name,
                     DescriptionTypeAccount = t.Description,
                     IdUser = a.IdUser,
                     EmailUser = u.Email,
                     UsernameUser = u.Username,
                     IdStatus = a.IdStatus,
                     NameStatus = s.Name,
                     DescriptionStatus = s.Description
                 }
               )
              .ToList();
        }

        #endregion

    }
}