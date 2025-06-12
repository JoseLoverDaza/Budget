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
    /// Nombre: TypeAccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccountRepository : BaseRepository<TypeAccount>, ITypeAccountRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public TypeAccountRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountByIdTypeAccount(TypeAccountDto typeAccount)
        {
            return (
                     from t in _context.TypeAccounts.AsNoTracking()
                     join s in _context.StatusBudget.AsNoTracking()
                     on t.IdStatusBudget equals s.IdStatusBudget
                     where t.IdTypeAccount == typeAccount.IdTypeAccount
                     select new TypeAccountExtendDto
                     {
                        IdTypeAccount = t.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdStatusBudget = t.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = t.CreationUser,
                        CreationDate = t.CreationDate,
                        ModificationUser = t.ModificationUser,
                        ModificationDate = t.ModificationDate                        
                     }
                  )
                  .FirstOrDefault();
        }

        public TypeAccountExtendDto? GetTypeAccountByNameTypeAccount(TypeAccountDto typeAccount)
        {
            return (
                     from t in _context.TypeAccounts.AsNoTracking()
                     join s in _context.StatusBudget.AsNoTracking()
                     on t.IdStatusBudget equals s.IdStatusBudget
                     where t.NameTypeAccount == typeAccount.NameTypeAccount
                     select new TypeAccountExtendDto
                     {
                         IdTypeAccount = t.IdTypeAccount,
                         NameTypeAccount = t.NameTypeAccount,
                         DescriptionTypeAccount = t.DescriptionTypeAccount,
                         IdStatusBudget = t.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = t.CreationUser,
                         CreationDate = t.CreationDate,
                         ModificationUser = t.ModificationUser,
                         ModificationDate = t.ModificationDate
                     }
                  )
                  .FirstOrDefault();
        }

        public List<TypeAccountExtendDto> GetTypeAccountsByStatusBudget(TypeAccountDto typeAccount)
        {
            return (
                    from t in _context.TypeAccounts.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.IdStatusBudget == typeAccount.IdStatusBudget
                    select new TypeAccountExtendDto
                    {
                        IdTypeAccount = t.IdTypeAccount,
                        NameTypeAccount = t.NameTypeAccount,
                        DescriptionTypeAccount = t.DescriptionTypeAccount,
                        IdStatusBudget = t.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = t.CreationUser,
                        CreationDate = t.CreationDate,
                        ModificationUser = t.ModificationUser,
                        ModificationDate = t.ModificationDate
                    }
                  )
                 .ToList();
        }

        #endregion 

    }
}