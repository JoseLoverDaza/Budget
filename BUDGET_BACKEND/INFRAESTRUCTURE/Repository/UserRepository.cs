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

    public class UserBudgetRepository : BaseRepository<UserBudget>, IUserBudgetRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public UserBudgetRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public UserBudgetExtendDto? GetUserBudgetByIdUserBudget(UserBudgetDto userBudget)
        {
            return (
                       from u in _context.UsersBudget.AsNoTracking()
                       join r in _context.RolesBudget.AsNoTracking()
                       on u.IdRoleBudget equals r.IdRoleBudget
                       join s in _context.StatusBudget.AsNoTracking()
                       on u.IdStatusBudget equals s.IdStatusBudget
                       where u.IdUserBudget == userBudget.IdUserBudget
                       select new UserBudgetExtendDto
                       {
                           IdUserBudget = u.IdUserBudget,
                           Email = u.Email,
                           Phone = u.Phone,
                           Username = u.Username,
                           EncryptedPassword = u.EncryptedPassword,
                           IdRoleBudget = u.IdRoleBudget,
                           NameRoleBudget = r.NameRole,
                           DescriptionRoleBudget = r.DescriptionRole,
                           IdStatusBudget = u.IdStatusBudget,
                           NameStatusBudget = s.NameStatus,
                           DescriptionStatusBudget = s.DescriptionStatus
                       }
                   )
                   .FirstOrDefault();
        }

        public UserBudgetExtendDto? GetUserBudgetByEmail(UserBudgetDto userBudget)
        {
            return (
                      from u in _context.UsersBudget.AsNoTracking()
                      join r in _context.RolesBudget.AsNoTracking()
                      on u.IdRoleBudget equals r.IdRoleBudget
                      join s in _context.StatusBudget.AsNoTracking()
                      on u.IdStatusBudget equals s.IdStatusBudget
                      where u.Email == userBudget.Email
                      select new UserBudgetExtendDto
                      {
                          IdUserBudget = u.IdUserBudget,
                          Email = u.Email,
                          Phone = u.Phone,
                          Username = u.Username,
                          EncryptedPassword = u.EncryptedPassword,
                          IdRoleBudget = u.IdRoleBudget,
                          NameRoleBudget = r.NameRole,
                          DescriptionRoleBudget = r.DescriptionRole,
                          IdStatusBudget = u.IdStatusBudget,
                          NameStatusBudget = s.NameStatus,
                          DescriptionStatusBudget = s.DescriptionStatus
                      }
                  )
                  .FirstOrDefault();
        }

        public UserBudgetExtendDto? GetUserBudgetByUsername(UserBudgetDto userBudget)
        {
            return (
                      from u in _context.UsersBudget.AsNoTracking()
                      join r in _context.RolesBudget.AsNoTracking()
                      on u.IdRoleBudget equals r.IdRoleBudget
                      join s in _context.StatusBudget.AsNoTracking()
                      on u.IdStatusBudget equals s.IdStatusBudget
                      where u.Username == userBudget.Username
                      select new UserBudgetExtendDto
                      {
                          IdUserBudget = u.IdUserBudget,
                          Email = u.Email,
                          Phone = u.Phone,
                          Username = u.Username,
                          EncryptedPassword = u.EncryptedPassword,
                          IdRoleBudget = u.IdRoleBudget,
                          NameRoleBudget = r.NameRole,
                          DescriptionRoleBudget = r.DescriptionRole,
                          IdStatusBudget = u.IdStatusBudget,
                          NameStatusBudget = s.NameStatus,
                          DescriptionStatusBudget = s.DescriptionStatus
                      }
                  )
                  .FirstOrDefault();
        }

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudget(UserBudgetDto userBudget)
        {
            return (
                     from u in _context.UsersBudget.AsNoTracking()
                     join r in _context.RolesBudget.AsNoTracking()
                     on u.IdRoleBudget equals r.IdRoleBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on u.IdStatusBudget equals s.IdStatusBudget
                     where r.IdRoleBudget == userBudget.IdRoleBudget
                     select new UserBudgetExtendDto
                     {
                         IdUserBudget = u.IdUserBudget,
                         Email = u.Email,
                         Phone = u.Phone,
                         Username = u.Username,
                         EncryptedPassword = u.EncryptedPassword,
                         IdRoleBudget = u.IdRoleBudget,
                         NameRoleBudget = r.NameRole,
                         DescriptionRoleBudget = r.DescriptionRole,
                         IdStatusBudget = u.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus
                     }
                  )
                 .ToList();
        }

        public List<UserBudgetExtendDto> GetUsersBudgetByStatusBudget(UserBudgetDto userBudget)
        {
            return (
                     from u in _context.UsersBudget.AsNoTracking()
                     join r in _context.RolesBudget.AsNoTracking()
                     on u.IdRoleBudget equals r.IdRoleBudget
                     join s in _context.StatusBudget.AsNoTracking()
                     on u.IdStatusBudget equals s.IdStatusBudget
                     where r.IdStatusBudget == userBudget.IdStatusBudget
                     select new UserBudgetExtendDto
                     {
                         IdUserBudget = u.IdUserBudget,
                         Email = u.Email,
                         Phone = u.Phone,
                         Username = u.Username,
                         EncryptedPassword = u.EncryptedPassword,
                         IdRoleBudget = u.IdRoleBudget,
                         NameRoleBudget = r.NameRole,
                         DescriptionRoleBudget = r.DescriptionRole,
                         IdStatusBudget = u.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus
                     }
                  )
                 .ToList();
        }

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudgetStatusBudget(UserBudgetDto userBudget)
        {
            return (
                      from u in _context.UsersBudget.AsNoTracking()
                      join r in _context.RolesBudget.AsNoTracking()
                      on u.IdRoleBudget equals r.IdRoleBudget
                      join s in _context.StatusBudget.AsNoTracking()
                      on u.IdStatusBudget equals s.IdStatusBudget
                      where r.IdRoleBudget == userBudget.IdRoleBudget && r.IdStatusBudget == userBudget.IdStatusBudget
                      select new UserBudgetExtendDto
                      {
                         IdUserBudget = u.IdUserBudget,
                         Email = u.Email,
                         Phone = u.Phone,
                         Username = u.Username,
                         EncryptedPassword = u.EncryptedPassword,
                         IdRoleBudget = u.IdRoleBudget,
                         NameRoleBudget = r.NameRole,
                         DescriptionRoleBudget = r.DescriptionRole,
                         IdStatusBudget = u.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus
                      }
                  )
                 .ToList();
        }

        #endregion

    }
}