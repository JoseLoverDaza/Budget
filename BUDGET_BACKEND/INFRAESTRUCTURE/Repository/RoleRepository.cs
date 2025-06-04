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
    /// Nombre: RoleRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public RoleRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public RoleExtendDto? GetRoleById(RoleDto role)
        {
            return (
                       from r in _context.Roles.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on r.IdStatus equals s.IdStatus
                       where r.IdRole == role.IdRole
                       select new RoleExtendDto
                       {
                           IdRole = r.IdRole,
                           Name = r.Name,
                           IdStatus = r.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public RoleExtendDto? GetRoleByName(RoleDto role)
        {
            return (
                      from r in _context.Roles.AsNoTracking()
                      join s in _context.Status.AsNoTracking()
                      on r.IdStatus equals s.IdStatus
                      where r.Name == role.Name
                      select new RoleExtendDto
                      {
                          IdRole = r.IdRole,
                          Name = r.Name,
                          IdStatus = r.IdStatus,
                          NameStatus = s.Name,
                          DescriptionStatus = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public List<RoleExtendDto> GetRolesByStatus(RoleDto role)
        {
            return (
                     from r in _context.Roles.AsNoTracking()
                     join s in _context.Status.AsNoTracking()
                     on r.IdStatus equals s.IdStatus
                     where r.IdStatus == role.IdStatus
                     select new RoleExtendDto
                     {
                         IdRole = r.IdRole,
                         Name = r.Name,
                         IdStatus = r.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                  )
                 .ToList();
        }

        #endregion 

    }
}