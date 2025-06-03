namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using Domain.Context;
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

        public UserExtendDto? GetUserById(int idUser)
        {
            return (
                       from u in _context.Users.AsNoTracking()
                       join r in _context.Roles.AsNoTracking()
                       on u.IdRole equals r.IdRole
                       join s in _context.Status.AsNoTracking()
                       on u.IdStatus equals s.IdStatus
                       where u.IdUser == idUser
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

        public UserExtendDto? GetUserByEmail(string email)
        {
            return (
                      from u in _context.Users.AsNoTracking()
                      join r in _context.Roles.AsNoTracking()
                      on u.IdRole equals r.IdRole
                      join s in _context.Status.AsNoTracking()
                      on u.IdStatus equals s.IdStatus
                      where u.Email == email
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

        public UserExtendDto? GetUserByLogin(string login)
        {
            return (
                      from u in _context.Users.AsNoTracking()
                      join r in _context.Roles.AsNoTracking()
                      on u.IdRole equals r.IdRole
                      join s in _context.Status.AsNoTracking()
                      on u.IdStatus equals s.IdStatus
                      where u.Login == login
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

        public List<UserExtendDto> GetUsersByRole(int idRole)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdRole == idRole
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

        public List<UserExtendDto> GetUsersByStatus(int idStatus)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdStatus == idStatus
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

        public List<UserExtendDto> GetUsersByRoleStatus(int idRole, int idStatus)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdRole == idRole && r.IdStatus == idStatus
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
