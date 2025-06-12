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
    /// Nombre: RoleBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleBudgetRepository : BaseRepository<RoleBudget>, IRoleBudgetRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public RoleBudgetRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public RoleBudgetExtendDto? GetRoleBudgetByIdRoleBudget(RoleBudgetDto roleBudget)
        {
            return (
                       from r in _context.RolesBudget.AsNoTracking()
                       join s in _context.StatusBudget.AsNoTracking()
                       on r.IdStatusBudget equals s.IdStatusBudget
                       where r.IdRoleBudget == roleBudget.IdRoleBudget
                       select new RoleBudgetExtendDto
                       {
                           IdRoleBudget = r.IdRoleBudget,
                           NameRole = r.NameRole,
                           IdStatusBudget = r.IdStatusBudget,
                           NameStatusBudget = s.NameStatus,
                           DescriptionStatusBudget = s.DescriptionStatus
                       }
                   )
                   .FirstOrDefault();
        }

        public RoleBudgetExtendDto? GetRoleBudgetByNameRole(RoleBudgetDto roleBudget)
        {
            return (
                      from r in _context.RolesBudget.AsNoTracking()
                      join s in _context.StatusBudget.AsNoTracking()
                      on r.IdStatusBudget equals s.IdStatusBudget
                      where r.NameRole == roleBudget.NameRole
                      select new RoleBudgetExtendDto
                      {
                          IdRoleBudget = r.IdRoleBudget,
                          NameRole = r.NameRole,
                          IdStatusBudget = r.IdStatusBudget,
                          NameStatusBudget = s.NameStatus,
                          DescriptionStatusBudget = s.DescriptionStatus
                      }
                  )
                  .FirstOrDefault();
        }

        public List<RoleBudgetExtendDto> GetRolesBudgetByStatusBudget(RoleBudgetDto roleBudget)
        {
            return (
                     from r in _context.RolesBudget.AsNoTracking()
                     join s in _context.StatusBudget.AsNoTracking()
                     on r.IdStatusBudget equals s.IdStatusBudget
                     where r.IdStatusBudget == roleBudget.IdStatusBudget
                     select new RoleBudgetExtendDto
                     {
                         IdRoleBudget = r.IdRoleBudget,
                         NameRole = r.NameRole,
                         IdStatusBudget = r.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus
                     }
                  )
                 .ToList();
        }

        #endregion 

    }
}