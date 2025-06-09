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
    /// Nombre: LogApiRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class LogApiApiRepository : BaseRepository<LogApi>, ILogApiRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public LogApiApiRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public LogApiExtendDto? GetLogApiById(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.IdLogApi == logApi.IdLogApi
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
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

        public List<LogApiExtendDto> GetLogApisByCreationDate(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.CreationDate == logApi.CreationDate
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
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

        public List<LogApiExtendDto> GetLogApisByStatus(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.IdStatus == logApi.IdStatus
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
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

        public List<LogApiExtendDto> GetLogApisByEntityCreationDate(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.EntityAction == logApi.EntityAction && l.CreationDate == logApi.CreationDate
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
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

        public List<LogApiExtendDto> GetLogApisByCreationDateStatus(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.CreationDate == logApi.CreationDate && l.IdStatus == logApi.IdStatus
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
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

        public List<LogApiExtendDto> GetLogApisByEntityCreationDateStatus(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on l.IdStatus equals s.IdStatus
                    where l.EntityAction == logApi.EntityAction && l.CreationDate == logApi.CreationDate && l.IdStatus == logApi.IdStatus
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
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