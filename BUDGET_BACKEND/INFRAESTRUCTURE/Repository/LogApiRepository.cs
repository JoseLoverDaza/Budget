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

        public LogApiExtendDto? GetLogApiByIdLogApi(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on l.IdStatusBudget equals s.IdStatusBudget
                    where l.IdLogApi == logApi.IdLogApi
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,                        
                        IdStatusBudget = l.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = l.CreationUser,
                        CreationDate = l.CreationDate,
                        ModificationUser = l.ModificationUser,
                        ModificationDate = l.ModificationDate
                    }
                  )
                  .FirstOrDefault();
        }

        public List<LogApiExtendDto> GetLogApisByCreationDate(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on l.IdStatusBudget equals s.IdStatusBudget
                    where l.CreationDate == logApi.CreationDate
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,
                        IdStatusBudget = l.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = l.CreationUser,
                        CreationDate = l.CreationDate,
                        ModificationUser = l.ModificationUser,
                        ModificationDate = l.ModificationDate
                    }
                  )
                  .ToList();
        }

        public List<LogApiExtendDto> GetLogApisByStatusBudget(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on l.IdStatusBudget equals s.IdStatusBudget
                    where l.IdStatusBudget == logApi.IdStatusBudget
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,
                        IdStatusBudget = l.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = l.CreationUser,
                        CreationDate = l.CreationDate,
                        ModificationUser = l.ModificationUser,
                        ModificationDate = l.ModificationDate
                    }
                   )
                   .ToList();
        }

        public List<LogApiExtendDto> GetLogApisByEntityCreationDate(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on l.IdStatusBudget equals s.IdStatusBudget
                    where l.EntityAction == logApi.EntityAction && l.CreationDate == logApi.CreationDate
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,
                        IdStatusBudget = l.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = l.CreationUser,
                        CreationDate = l.CreationDate,
                        ModificationUser = l.ModificationUser,
                        ModificationDate = l.ModificationDate
                    }
                   )
                   .ToList();
        }

        public List<LogApiExtendDto> GetLogApisByCreationDateStatusBudget(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on l.IdStatusBudget equals s.IdStatusBudget
                    where l.CreationDate == logApi.CreationDate && l.IdStatusBudget == logApi.IdStatusBudget
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,
                        IdStatusBudget = l.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = l.CreationUser,
                        CreationDate = l.CreationDate,
                        ModificationUser = l.ModificationUser,
                        ModificationDate = l.ModificationDate
                    }
                   )
                   .ToList();
        }

        public List<LogApiExtendDto> GetLogApisByEntityCreationDateStatusBudget(LogApiDto logApi)
        {
            return (
                    from l in _context.LogApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on l.IdStatusBudget equals s.IdStatusBudget
                    where l.EntityAction == logApi.EntityAction && l.CreationDate == logApi.CreationDate && l.IdStatusBudget == logApi.IdStatusBudget
                    select new LogApiExtendDto
                    {
                        IdLogApi = l.IdLogApi,
                        Entity = l.Entity,
                        PreviousValues = l.PreviousValues,
                        NewValues = l.NewValues,
                        EntityAction = l.EntityAction,
                        IdStatusBudget = l.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = l.CreationUser,
                        CreationDate = l.CreationDate,
                        ModificationUser = l.ModificationUser,
                        ModificationDate = l.ModificationDate
                    }
                  )
                  .ToList();
        }

        #endregion

    }
}