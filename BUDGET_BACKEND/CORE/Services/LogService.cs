namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: LogService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class LogService : BaseService, ILogService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public LogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public LogApiExtendDto? GetLogById(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            LogApiExtendDto? logSearch = logRepository.GetLogById(log);

            if (logSearch != null)
            {
                return logSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogsByCreationDate(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            List<LogApiExtendDto> logsSearch = logRepository.GetLogsByCreationDate(log);

            if (logsSearch.Count != 0)
            {
                return logsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogsByStatus(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            List<LogApiExtendDto> logsSearch = logRepository.GetLogsByStatus(log);

            if (logsSearch.Count != 0)
            {
                return logsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogsByEntityCreationDate(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            List<LogApiExtendDto> logsSearch = logRepository.GetLogsByEntityCreationDate(log);

            if (logsSearch.Count != 0)
            {
                return logsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogsByCreationDateStatus(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            List<LogApiExtendDto> logsSearch = logRepository.GetLogsByCreationDateStatus(log);

            if (logsSearch.Count != 0)
            {
                return logsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogsByEntityCreationDateStatus(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            List<LogApiExtendDto> logsSearch = logRepository.GetLogsByEntityCreationDateStatus(log);

            if (logsSearch.Count != 0)
            {
                return logsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public LogDto SaveLog(LogDto log)
        {            
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = log.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Log saveLog = new()
            {
                Entity = log.Entity?.Trim() ?? string.Empty,               
                PreviousValues = log.PreviousValues?.Trim() ?? string.Empty,
                NewValues = log.NewValues?.Trim() ?? string.Empty,
                EntityAction = log.EntityAction?.Trim() ?? string.Empty,
                CreationDate = log.CreationDate,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Log>().Add(saveLog);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return log;
        }

        public LogDto UpdateLog(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();

            if (log == null || log.IdLog <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                        
            LogApiExtendDto? logSearch = logRepository.GetLogById(log) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
                       
            Log updateLog = new()
            {
                IdLog = logSearch.IdLog,
                Entity = log.Entity?.Trim() ?? string.Empty,
                PreviousValues = log.PreviousValues?.Trim() ?? string.Empty,
                NewValues = log.NewValues?.Trim() ?? string.Empty,
                EntityAction = log.EntityAction?.Trim() ?? string.Empty,
                CreationDate = logSearch.CreationDate,
                IdStatus = logSearch.IdStatus                
            };

            UnitOfWork.BaseRepository<Log>().Update(updateLog);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return log;
        }

        public LogDto DeleteLog(LogDto log)
        {
            ILogApiRepository logRepository = UnitOfWork.LogRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            LogApiExtendDto? logSearch = logRepository.GetLogById(log) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = log.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (logSearch.IdStatus == statusSearch.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Log deleteLog = new()
            {
                IdLog = logSearch.IdLog,
                Entity = logSearch.Entity,
                PreviousValues = logSearch.PreviousValues,
                NewValues = logSearch.NewValues,
                EntityAction = logSearch.EntityAction,
                CreationDate = logSearch.CreationDate,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Log>().Update(deleteLog);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return log;
        }

        #endregion

    }
}