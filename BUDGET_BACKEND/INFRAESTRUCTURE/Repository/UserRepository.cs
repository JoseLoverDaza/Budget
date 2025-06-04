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
    using System.Data;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    internal class UserRepository : BaseRepository<User>, IUserRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public UserRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public UserExtendDto? GetUserById(UserDto user)
        {
            return (
                       from u in _context.Users.AsNoTracking()
                       join r in _context.Roles.AsNoTracking()
                       on u.IdRole equals r.IdRole
                       join s in _context.Status.AsNoTracking()
                       on u.IdStatus equals s.IdStatus
                       where u.IdUser == user.IdUser
                       select new UserExtendDto
                       {
                           IdUser = u.IdUser,
                           Email = u.Email,
                           Phone = u.Phone,
                           Login = u.Login,
                           Password = u.Password,
                           IdRole = u.IdRole,
                           NameRole = r.Name,
                           DescriptionRole = r.Description,
                           IdStatus = u.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public UserExtendDto? GetUserByEmail(UserDto user)
        {
            return (
                      from u in _context.Users.AsNoTracking()
                      join r in _context.Roles.AsNoTracking()
                      on u.IdRole equals r.IdRole
                      join s in _context.Status.AsNoTracking()
                      on u.IdStatus equals s.IdStatus
                      where u.Email == user.Email
                      select new UserExtendDto
                      {
                          IdUser = u.IdUser,
                          Email = u.Email,
                          Phone = u.Phone,
                          Login = u.Login,
                          Password = u.Password,
                          IdRole = u.IdRole,
                          NameRole = r.Name,
                          DescriptionRole = r.Description,
                          IdStatus = u.IdStatus,
                          NameStatus = s.Name,
                          DescriptionStatus = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public UserExtendDto? GetUserByLogin(UserDto user)
        {
            return (
                      from u in _context.Users.AsNoTracking()
                      join r in _context.Roles.AsNoTracking()
                      on u.IdRole equals r.IdRole
                      join s in _context.Status.AsNoTracking()
                      on u.IdStatus equals s.IdStatus
                      where u.Login == user.Login
                      select new UserExtendDto
                      {
                          IdUser = u.IdUser,
                          Email = u.Email,
                          Phone = u.Phone,
                          Login = u.Login,
                          Password = u.Password,
                          IdRole = u.IdRole,
                          NameRole = r.Name,
                          DescriptionRole = r.Description,
                          IdStatus = u.IdStatus,
                          NameStatus = s.Name,
                          DescriptionStatus = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public List<UserExtendDto> GetUsersByRole(UserDto user)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdRole == user.IdRole
                     select new UserExtendDto
                     {
                         IdUser = u.IdUser,
                         Email = u.Email,
                         Phone = u.Phone,
                         Login = u.Login,
                         Password = u.Password,
                         IdRole = u.IdRole,
                         NameRole = r.Name,
                         DescriptionRole = r.Description,
                         IdStatus = u.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                  )
                 .ToList();
        }

        public List<UserExtendDto> GetUsersByStatus(UserDto user)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdStatus == user.IdStatus
                     select new UserExtendDto
                     {
                         IdUser = u.IdUser,
                         Email = u.Email,
                         Phone = u.Phone,
                         Login = u.Login,
                         Password = u.Password,
                         IdRole = u.IdRole,
                         NameRole = r.Name,
                         DescriptionRole = r.Description,
                         IdStatus = u.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                  )
                 .ToList();
        }

        public List<UserExtendDto> GetUsersByRoleStatus(UserDto user)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdRole == user.IdRole && r.IdStatus == user.IdStatus
                     select new UserExtendDto
                     {
                         IdUser = u.IdUser,
                         Email = u.Email,
                         Phone = u.Phone,
                         Login = u.Login,
                         Password = u.Password,
                         IdRole = u.IdRole,
                         NameRole = r.Name,
                         DescriptionRole = r.Description,
                         IdStatus = u.IdStatus,
                         NameStatus = s.Name,
                         DescriptionStatus = s.Description
                     }
                  )
                 .ToList();
        }

        #endregion

    }
}
