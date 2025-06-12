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

        public AccountExtendDto? GetAccountByIdAccount(AccountDto account)
        {
            return (
                     from a in _context.Accounts.AsNoTracking()
                     join f in _context.FinancialInstitutions.AsNoTracking()
                     on a.IdFinancialInstitution equals f.IdFinancialInstitution
                     join t in _context.TypeAccounts.AsNoTracking()
                     on a.IdTypeAccount equals t.IdTypeAccount
                     join u in _context.UsersBudget.AsNoTracking()
                     on a.IdUserBudget equals u.IdUserBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on a.IdStatusBudget equals s.IdStatusBudget
                     where a.IdAccount == account.IdAccount
                     select new AccountExtendDto
                     {
                         IdAccount = a.IdAccount,
                         NameAccount = a.NameAccount,
                         DescriptionAccount = a.DescriptionAccount,
                         IdFinancialInstitution = a.IdFinancialInstitution,
                         NameFinancialInstitution = f.NameFinancialInstitution,
                         DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                         IdTypeAccount = a.IdTypeAccount,
                         NameTypeAccount = t.NameTypeAccount,
                         DescriptionTypeAccount = t.DescriptionTypeAccount,
                         IdUserBudget = a.IdUserBudget,
                         EmailUserBudget = u.Email,
                         UsernameUserBudget = u.Username,
                         IdStatusBudget = a.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = a.CreationUser,
                         CreationDate = a.CreationDate,
                         ModificationUser = a.ModificationUser,
                         ModificationDate = a.ModificationDate
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
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdFinancialInstitution == account.IdFinancialInstitution
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdUserBudget = a.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
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
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdTypeAccount == account.IdTypeAccount
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdUserBudget = a.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByUserBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdUserBudget == account.IdUserBudget
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdUserBudget = a.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByStatusBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdStatusBudget == account.IdStatusBudget
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdUserBudget = a.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionStatusBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdFinancialInstitution == account.IdFinancialInstitution && a.IdStatusBudget == account.IdStatusBudget
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdUserBudget = a.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<AccountExtendDto> GetAccountsByTypeAccountStatusBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdTypeAccount == account.IdTypeAccount && a.IdStatusBudget == account.IdStatusBudget
                    select new AccountExtendDto
                    {
                        IdAccount = a.IdAccount,
                        NameAccount = a.NameAccount,
                        DescriptionAccount = a.DescriptionAccount,
                        IdFinancialInstitution = a.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdTypeAccount = a.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdUserBudget = a.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                   )
                   .ToList();
        }

        public List<AccountExtendDto> GetAccountsByUserBudgetStatusBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdUserBudget == account.IdUserBudget && a.IdStatusBudget == account.IdStatusBudget
                    select new AccountExtendDto
                    {
                      IdAccount = a.IdAccount,
                      NameAccount = a.NameAccount,
                      DescriptionAccount = a.DescriptionAccount,
                      IdFinancialInstitution = a.IdFinancialInstitution,
                      NameFinancialInstitution = f.NameFinancialInstitution,
                      DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                      IdTypeAccount = a.IdTypeAccount,
                      NameTypeAccount = t.NameTypeAccount,
                      DescriptionTypeAccount = t.DescriptionTypeAccount,
                      IdUserBudget = a.IdUserBudget,
                      EmailUserBudget = u.Email,
                      UsernameUserBudget = u.Username,
                      IdStatusBudget = a.IdStatusBudget,
                      NameStatusBudget = s.NameStatus,
                      DescriptionStatusBudget = s.DescriptionStatus,
                      CreationUser = a.CreationUser,
                      CreationDate = a.CreationDate,
                      ModificationUser = a.ModificationUser,
                      ModificationDate = a.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<AccountExtendDto> GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.NameAccount == account.NameAccount && a.IdFinancialInstitution == account.IdFinancialInstitution && a.IdTypeAccount == account.IdTypeAccount && a.IdUserBudget == account.IdUserBudget
                    select new AccountExtendDto
                    {
                     IdAccount = a.IdAccount,
                     NameAccount = a.NameAccount,
                     DescriptionAccount = a.DescriptionAccount,
                     IdFinancialInstitution = a.IdFinancialInstitution,
                     NameFinancialInstitution = f.NameFinancialInstitution,
                     DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                     IdTypeAccount = a.IdTypeAccount,
                     NameTypeAccount = t.NameTypeAccount,
                     DescriptionTypeAccount = t.DescriptionTypeAccount,
                     IdUserBudget = a.IdUserBudget,
                     EmailUserBudget = u.Email,
                     UsernameUserBudget = u.Username,
                     IdStatusBudget = a.IdStatusBudget,
                     NameStatusBudget = s.NameStatus,
                     DescriptionStatusBudget = s.DescriptionStatus,
                     CreationUser = a.CreationUser,
                     CreationDate = a.CreationDate,
                     ModificationUser = a.ModificationUser,
                     ModificationDate = a.ModificationDate
                   }
                 )
                 .ToList();
        }

        public List<AccountExtendDto> GetAccountsByFinancialInstitutionTypeAccountUserBudget(AccountDto account)
        {
            return (
                    from a in _context.Accounts.AsNoTracking()
                    join f in _context.FinancialInstitutions.AsNoTracking()
                    on a.IdFinancialInstitution equals f.IdFinancialInstitution
                    join t in _context.TypeAccounts.AsNoTracking()
                    on a.IdTypeAccount equals t.IdTypeAccount
                    join u in _context.UsersBudget.AsNoTracking()
                    on a.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdFinancialInstitution == account.IdFinancialInstitution && a.IdTypeAccount == account.IdTypeAccount && a.IdUserBudget == account.IdUserBudget
                    select new AccountExtendDto
                    {
                     IdAccount = a.IdAccount,
                     NameAccount = a.NameAccount,
                     DescriptionAccount = a.DescriptionAccount,
                     IdFinancialInstitution = a.IdFinancialInstitution,
                     NameFinancialInstitution = f.NameFinancialInstitution,
                     DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                     IdTypeAccount = a.IdTypeAccount,
                     NameTypeAccount = t.NameTypeAccount,
                     DescriptionTypeAccount = t.DescriptionTypeAccount,
                     IdUserBudget = a.IdUserBudget,
                     EmailUserBudget = u.Email,
                     UsernameUserBudget = u.Username,
                     IdStatusBudget = a.IdStatusBudget,
                     NameStatusBudget = s.NameStatus,
                     DescriptionStatusBudget = s.DescriptionStatus,
                     CreationUser = a.CreationUser,
                     CreationDate = a.CreationDate,
                     ModificationUser = a.ModificationUser,
                     ModificationDate = a.ModificationDate
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}