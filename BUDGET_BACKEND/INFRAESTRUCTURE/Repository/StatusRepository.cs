namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Interfaces.Repositories;
    using Domain.Context;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusRepository : BaseRepository<Status>, IStatusRepository 
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public StatusRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region  Métodos y Funciones

        public StatusDto? GetStatusById(int idStatus)
        {
            return (
                       from s in _context.Status.AsNoTracking()
                       where s.IdStatus == idStatus
                       select new StatusDto
                       {
                           IdStatus = s.IdStatus,
                           Name = s.Name,
                           Description = s.Description
                       }
                   )                  
                   .FirstOrDefault();
        }

        public StatusDto? GetStatusByName(string name)
        {
            return (
                       from s in _context.Status.AsNoTracking()
                       where s.Name == name
                       select new StatusDto
                       {
                           IdStatus = s.IdStatus,
                           Name = s.Name,
                           Description = s.Description
                       }
                   )                   
                   .FirstOrDefault();
        }

        public List<StatusDto> GetStatus()
        {
            return (
                     from s in _context.Status.AsNoTracking()
                     select new StatusDto
                     {
                         IdStatus = s.IdStatus,
                         Name = s.Name,
                         Description = s.Description
                     }
                 )                               
                 .ToList();
        }

        #endregion

    }
}
