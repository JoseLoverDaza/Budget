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
    /// Nombre: LogApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class LogApiService : BaseService, ILogApiService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public LogApiService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public LogApiExtendDto? GetLogApiById(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            LogApiExtendDto? logApiSearch = logApiRepository.GetLogApiById(logApi);

            if (logApiSearch != null)
            {
                return logApiSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogApisByCreationDate(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByCreationDate(logApi);

            if (logApisSearch.Count != 0)
            {
                return logApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogApisByStatus(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByStatus(logApi);

            if (logApisSearch.Count != 0)
            {
                return logApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogApisByEntityCreationDate(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByEntityCreationDate(logApi);

            if (logApisSearch.Count != 0)
            {
                return logApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogApisByCreationDateStatus(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByCreationDateStatus(logApi);

            if (logApisSearch.Count != 0)
            {
                return logApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogApisByEntityCreationDateStatus(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByEntityCreationDateStatus(logApi);

            if (logApisSearch.Count != 0)
            {
                return logApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public LogApiDto SaveLogApi(LogApiDto logApi)
        {            
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = logApi.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            LogApi saveApiLog = new()
            {
                Entity = logApi.Entity?.Trim() ?? string.Empty,               
                PreviousValues = logApi.PreviousValues?.Trim() ?? string.Empty,
                NewValues = logApi.NewValues?.Trim() ?? string.Empty,
                EntityAction = logApi.EntityAction?.Trim() ?? string.Empty,
                CreationDate = logApi.CreationDate,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<LogApi>().Add(saveApiLog);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return logApi;
        }

        public LogApiDto UpdateLogApi(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();

            if (logApi == null || logApi.IdLogApi <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                        
            LogApiExtendDto? logApiSearch = logApiRepository.GetLogApiById(logApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
                       
            LogApi updateLogApi = new()
            {
                IdLogApi = logApiSearch.IdLogApi,
                Entity = logApi.Entity?.Trim() ?? string.Empty,
                PreviousValues = logApi.PreviousValues?.Trim() ?? string.Empty,
                NewValues = logApi.NewValues?.Trim() ?? string.Empty,
                EntityAction = logApi.EntityAction?.Trim() ?? string.Empty,
                CreationDate = logApiSearch.CreationDate,
                IdStatus = logApiSearch.IdStatus                
            };

            UnitOfWork.BaseRepository<LogApi>().Update(updateLogApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return logApi;
        }

        public LogApiDto DeleteLogApi(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            LogApiExtendDto? logSearch = logApiRepository.GetLogApiById(logApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = logApi.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (logSearch.IdStatus == statusSearch.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            LogApi deleteLogApi = new()
            {
                IdLogApi = logSearch.IdLogApi,
                Entity = logSearch.Entity,
                PreviousValues = logSearch.PreviousValues,
                NewValues = logSearch.NewValues,
                EntityAction = logSearch.EntityAction,
                CreationDate = logSearch.CreationDate,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<LogApi>().Update(deleteLogApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return logApi;
        }

        #endregion

    }
}