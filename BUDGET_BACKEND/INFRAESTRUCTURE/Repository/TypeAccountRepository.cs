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

        public TypeAccountExtendDto? GetTypeAccountById(int idTypeAccount)
        {
            return (
                       from t in _context.TypeAccounts.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on t.IdStatus equals s.IdStatus
                       where t.IdTypeAccount == idTypeAccount
                       select new TypeAccountExtendDto
                       {
                           IdTypeAccount = t.IdTypeAccount,
                           Name = t.Name,
                           IdStatus = t.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public TypeAccountExtendDto? GetTypeAccountByName(string name)
        {
            return (
                      from t in _context.TypeAccounts.AsNoTracking()
                      join s in _context.Status.AsNoTracking()
                      on t.IdStatus equals s.IdStatus
                      where t.Name == name
                      select new TypeAccountExtendDto
                      {
                          IdTypeAccount = t.IdTypeAccount,
                          Name = t.Name,
                          IdStatus = t.IdStatus,
                          NameStatus = s.Name,
                          DescriptionStatus = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(int idStatus)
        {
            return (
                     from t in _context.TypeAccounts.AsNoTracking()
                     join s in _context.Status.AsNoTracking()
                     on t.IdStatus equals s.IdStatus
                     where t.IdStatus == idStatus
                     select new TypeAccountExtendDto
                     {
                         IdTypeAccount = t.IdTypeAccount,
                         Name = t.Name,
                         IdStatus = t.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                  )
                 .ToList();
        }

        #endregion 

    }
}