namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using Domain.Context;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;

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

        public AccountExtendDto? GetAccountById(int idAccount)
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
                     where a.IdAccount == idAccount
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
                         LoginUser = u.Login,                        
                         IdStatus = a.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                 )
                 .FirstOrDefault();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitution(int idFinancialInstitution)
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
                    where a.IdFinancialInstitution == idFinancialInstitution
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
                        LoginUser = u.Login,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccount(int idTypeAccount)
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
                    where a.IdTypeAccount == idTypeAccount
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
                        LoginUser = u.Login,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByUser(int idUser)
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
                    where a.IdUser == idUser
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
                        LoginUser = u.Login,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByStatus(int idStatus)
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
                    where a.IdStatus == idStatus
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
                        LoginUser = u.Login,
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatus(int idFinancialInstitution, int idStatus)
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
                   where a.IdFinancialInstitution == idFinancialInstitution && a.IdStatus == idStatus
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
                       LoginUser = u.Login,
                       IdStatus = a.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                 )
                .ToList();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatus(int idTypeAccount, int idStatus)
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
                  where a.IdTypeAccount == idTypeAccount && a.IdStatus == idStatus
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
                      LoginUser = u.Login,
                      IdStatus = a.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
                )
               .ToList();
        }

        public List<AccountExtendDto> GetAccountsByUserStatus(int idUser, int idStatus)
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
                  where a.IdUser == idUser && a.IdStatus == idStatus
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
                      LoginUser = u.Login,
                      IdStatus = a.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
                )
               .ToList();
        }

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUser(string name, int idFinancialInstitution, int idTypeAccount, int idUser)
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
                 where a.Name == name && a.IdFinancialInstitution == idFinancialInstitution && a.IdTypeAccount == idTypeAccount && a.IdUser == idUser
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
                     LoginUser = u.Login,
                     IdStatus = a.IdStatus,
                     NameStatus = s.Name,
                     DescriptionStatus = s.Description
                 }
               )
              .ToList();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUser(int idFinancialInstitution, int idTypeAccount, int idUser)
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
                 where a.IdFinancialInstitution == idFinancialInstitution && a.IdTypeAccount == idTypeAccount && a.IdUser == idUser
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
                     LoginUser = u.Login,
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