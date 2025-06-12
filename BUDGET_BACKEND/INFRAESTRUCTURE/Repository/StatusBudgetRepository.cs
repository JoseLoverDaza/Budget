namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Interfaces.Repositories;
    using Domain.Context;
    using Domain.Dto;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusBudgetRepository : BaseRepository<StatusBudget>, IStatusBudgetRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public StatusBudgetRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region  Métodos y Funciones

        public StatusBudgetDto? GetStatusBudgetByIdStatusBudget(StatusBudgetDto statusBudget)
        {
            return (
                       from s in _context.StatusBudget.AsNoTracking()
                       where s.IdStatusBudget == statusBudget.IdStatusBudget
                       select new StatusBudgetDto
                       {
                           IdStatusBudget = s.IdStatusBudget,
                           NameStatus = s.NameStatus,
                           DescriptionStatus = s.DescriptionStatus
                       }
                   )
                   .FirstOrDefault();
        }

        public StatusBudgetDto? GetStatusBudgetByNameStatus(StatusBudgetDto statusBudget)
        {
            return (
                       from s in _context.StatusBudget.AsNoTracking()
                       where s.NameStatus == statusBudget.NameStatus
                       select new StatusBudgetDto
                       {
                           IdStatusBudget = s.IdStatusBudget,
                           NameStatus = s.NameStatus,
                           DescriptionStatus = s.DescriptionStatus
                       }
                   )
                   .FirstOrDefault();
        }

        public List<StatusBudgetDto> GetStatusBudget()
        {
            return (
                     from s in _context.StatusBudget.AsNoTracking()
                     select new StatusBudgetDto
                     {
                         IdStatusBudget = s.IdStatusBudget,
                         NameStatus = s.NameStatus,
                         DescriptionStatus = s.DescriptionStatus
                     }
                 )
                 .ToList();
        }

        #endregion

    }
}
