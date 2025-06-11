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

    internal class UserRepository : BaseRepository<User>, IUserBudgetRepository
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

        public UserBudgetExtendDto? GetUserById(UserDto user)
        {
            return (
                       from u in _context.Users.AsNoTracking()
                       join r in _context.Roles.AsNoTracking()
                       on u.IdRole equals r.IdRole
                       join s in _context.Status.AsNoTracking()
                       on u.IdStatus equals s.IdStatus
                       where u.IdUser == user.IdUser
                       select new UserBudgetExtendDto
                       {
                           IdUser = u.IdUser,
                           Email = u.Email,
                           Phone = u.Phone,
                           Username = u.Username,
                           Password = u.Password,
                           IdRole = u.IdRole,
                           NameRoleBudget = r.Name,
                           DescriptionRoleBudget = r.Description,
                           IdStatus = u.IdStatus,
                           NameStatusBudget = s.Name,
                           DescriptionStatusBudget = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public UserBudgetExtendDto? GetUserByEmail(UserDto user)
        {
            return (
                      from u in _context.Users.AsNoTracking()
                      join r in _context.Roles.AsNoTracking()
                      on u.IdRole equals r.IdRole
                      join s in _context.Status.AsNoTracking()
                      on u.IdStatus equals s.IdStatus
                      where u.Email == user.Email
                      select new UserBudgetExtendDto
                      {
                          IdUser = u.IdUser,
                          Email = u.Email,
                          Phone = u.Phone,
                          Username = u.Username,
                          Password = u.Password,
                          IdRole = u.IdRole,
                          NameRoleBudget = r.Name,
                          DescriptionRoleBudget = r.Description,
                          IdStatus = u.IdStatus,
                          NameStatusBudget = s.Name,
                          DescriptionStatusBudget = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public UserBudgetExtendDto? GetUserByUsername(UserDto user)
        {
            return (
                      from u in _context.Users.AsNoTracking()
                      join r in _context.Roles.AsNoTracking()
                      on u.IdRole equals r.IdRole
                      join s in _context.Status.AsNoTracking()
                      on u.IdStatus equals s.IdStatus
                      where u.Username == user.Username
                      select new UserBudgetExtendDto
                      {
                          IdUser = u.IdUser,
                          Email = u.Email,
                          Phone = u.Phone,
                          Username = u.Username,
                          Password = u.Password,
                          IdRole = u.IdRole,
                          NameRoleBudget = r.Name,
                          DescriptionRoleBudget = r.Description,
                          IdStatus = u.IdStatus,
                          NameStatusBudget = s.Name,
                          DescriptionStatusBudget = s.Description
                      }
                  )
                  .FirstOrDefault();
        }

        public List<UserBudgetExtendDto> GetUsersByRole(UserDto user)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdRole == user.IdRole
                     select new UserBudgetExtendDto
                     {
                         IdUser = u.IdUser,
                         Email = u.Email,
                         Phone = u.Phone,
                         Username = u.Username,
                         Password = u.Password,
                         IdRole = u.IdRole,
                         NameRoleBudget = r.Name,
                         DescriptionRoleBudget = r.Description,
                         IdStatus = u.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                  )
                 .ToList();
        }

        public List<UserBudgetExtendDto> GetUsersByStatus(UserDto user)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdStatus == user.IdStatus
                     select new UserBudgetExtendDto
                     {
                         IdUser = u.IdUser,
                         Email = u.Email,
                         Phone = u.Phone,
                         Username = u.Username,
                         Password = u.Password,
                         IdRole = u.IdRole,
                         NameRoleBudget = r.Name,
                         DescriptionRoleBudget = r.Description,
                         IdStatus = u.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                  )
                 .ToList();
        }

        public List<UserBudgetExtendDto> GetUsersByRoleStatus(UserDto user)
        {
            return (
                     from u in _context.Users.AsNoTracking()
                     join r in _context.Roles.AsNoTracking()
                     on u.IdRole equals r.IdRole
                     join s in _context.Status.AsNoTracking()
                     on u.IdStatus equals s.IdStatus
                     where r.IdRole == user.IdRole && r.IdStatus == user.IdStatus
                     select new UserBudgetExtendDto
                     {
                         IdUser = u.IdUser,
                         Email = u.Email,
                         Phone = u.Phone,
                         Username = u.Username,
                         Password = u.Password,
                         IdRole = u.IdRole,
                         NameRoleBudget = r.Name,
                         DescriptionRoleBudget = r.Description,
                         IdStatus = u.IdStatus,
                         NameStatusBudget = s.Name,
                         DescriptionStatusBudget = s.Description
                     }
                  )
                 .ToList();
        }

        #endregion

    }
}
