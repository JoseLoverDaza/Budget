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
    /// Nombre: LogRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class LogRepository : BaseRepository<Log>, ILogRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public LogRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public LogExtendDto? GetLogById(LogDto log)
        {
            return (
                    from l in _context.Logs.AsNoTracking()                   
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.IdLog == log.IdLog
                    select new LogExtendDto
                    {
                        IdLog = l.IdLog,     
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,
                        CreationDate = l.CreationDate,                         
                        IdStatus = l.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                )
                .FirstOrDefault();
        }

        public List<LogExtendDto> GetLogsByCreationDate(LogDto log)
        {
            return (
                   from l in _context.Logs.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on l.IdStatus equals s.IdStatus
                   where l.CreationDate == log.CreationDate
                   select new LogExtendDto
                   {
                       IdLog = l.IdLog,
                       Entity = l.Entity,
                       PreviousValues = l.PreviousValues,
                       NewValues = l.NewValues,
                       EntityAction = l.EntityAction,
                       CreationDate = l.CreationDate,
                       IdStatus = l.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<LogExtendDto> GetLogsByStatus(LogDto log)
        {
            return (
                   from l in _context.Logs.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on l.IdStatus equals s.IdStatus
                   where l.IdStatus == log.IdStatus
                   select new LogExtendDto
                   {
                       IdLog = l.IdLog,
                       Entity = l.Entity,
                       PreviousValues = l.PreviousValues,
                       NewValues = l.NewValues,
                       EntityAction = l.EntityAction,
                       CreationDate = l.CreationDate,
                       IdStatus = l.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<LogExtendDto> GetLogsByEntityCreationDate(LogDto log)
        {
            return (
                   from l in _context.Logs.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on l.IdStatus equals s.IdStatus
                   where l.EntityAction == log.EntityAction && l.CreationDate == log.CreationDate
                   select new LogExtendDto
                   {
                       IdLog = l.IdLog,
                       Entity = l.Entity,
                       PreviousValues = l.PreviousValues,
                       NewValues = l.NewValues,
                       EntityAction = l.EntityAction,
                       CreationDate = l.CreationDate,
                       IdStatus = l.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<LogExtendDto> GetLogsByCreationDateStatus(LogDto log)
        {
            return (
                   from l in _context.Logs.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on l.IdStatus equals s.IdStatus
                   where l.CreationDate == log.CreationDate && l.IdStatus == log.IdStatus
                   select new LogExtendDto
                   {
                       IdLog = l.IdLog,
                       Entity = l.Entity,
                       PreviousValues = l.PreviousValues,
                       NewValues = l.NewValues,
                       EntityAction = l.EntityAction,
                       CreationDate = l.CreationDate,
                       IdStatus = l.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<LogExtendDto> GetLogsByEntityCreationDateStatus(LogDto log)
        {
            return (
                  from l in _context.Logs.AsNoTracking()
                  join s in _context.Status.AsNoTracking()
                  on l.IdStatus equals s.IdStatus
                  where l.EntityAction == log.EntityAction && l.CreationDate == log.CreationDate && l.IdStatus == log.IdStatus
                  select new LogExtendDto
                  {
                      IdLog = l.IdLog,
                      Entity = l.Entity,
                      PreviousValues = l.PreviousValues,
                      NewValues = l.NewValues,
                      EntityAction = l.EntityAction,
                      CreationDate = l.CreationDate,
                      IdStatus = l.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
              )
              .ToList();
        }

        #endregion

    }
}