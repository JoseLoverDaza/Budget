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
    using System.Text.Json;

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

        public LogApiExtendDto? GetLogApiByIdLogApi(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            LogApiExtendDto? logApiSearch = logApiRepository.GetLogApiByIdLogApi(logApi);

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

        public List<LogApiExtendDto> GetLogApisByStatusBudget(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByStatusBudget(logApi);

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

        public List<LogApiExtendDto> GetLogApisByCreationDateStatusBudget(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByCreationDateStatusBudget(logApi);

            if (logApisSearch.Count != 0)
            {
                return logApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<LogApiExtendDto> GetLogApisByEntityCreationDateStatusBudget(LogApiDto logApi)
        {
            ILogApiRepository logApiRepository = UnitOfWork.LogApiRepository();
            List<LogApiExtendDto> logApisSearch = logApiRepository.GetLogApisByEntityCreationDateStatusBudget(logApi);

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
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = logApi.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            LogApi saveApiLog = new()
            {
                Entity = logApi.Entity?.Trim() ?? string.Empty,
                EntityAction = logApi.EntityAction?.Trim() ?? string.Empty,
                PreviousValues = logApi.PreviousValues?.Trim() ?? string.Empty,
                NewValues = logApi.NewValues?.Trim() ?? string.Empty,
                FilterValues = logApi.FilterValues?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = logApi.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget, 
                ModificationDate = logApi.ModificationDate                
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

            LogApiExtendDto? logApiSearch = logApiRepository.GetLogApiByIdLogApi(logApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            LogApi updateLogApi = new()
            {
                IdLogApi = logApiSearch.IdLogApi,
                Entity = logApi.Entity?.Trim() ?? string.Empty,
                EntityAction = logApi.EntityAction?.Trim() ?? string.Empty,
                PreviousValues = logApi.PreviousValues?.Trim() ?? string.Empty,
                NewValues = logApi.NewValues?.Trim() ?? string.Empty,
                FilterValues = logApi.FilterValues?.Trim() ?? string.Empty,                         
                IdStatusBudget = logApiSearch.IdStatusBudget,
                CreationUser = logApiSearch.CreationUser,
                CreationDate = logApiSearch.CreationDate,
                ModificationUser = logApiSearch.ModificationUser,
                ModificationDate = logApi.ModificationDate
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
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            LogApiExtendDto? logApiSearch = logApiRepository.GetLogApiByIdLogApi(logApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = logApi.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (logApiSearch.IdStatusBudget == statusBudgetSearch.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            LogApi deleteLogApi = new()
            {
                IdLogApi = logApiSearch.IdLogApi,
                Entity = logApiSearch.Entity,
                EntityAction = logApiSearch.EntityAction,
                PreviousValues = logApiSearch.PreviousValues,
                NewValues = logApiSearch.NewValues,
                FilterValues = logApiSearch.FilterValues,                             
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = logApiSearch.CreationUser,
                CreationDate = logApiSearch.CreationDate,
                ModificationUser = logApiSearch.ModificationUser,
                ModificationDate = logApiSearch.ModificationDate
            };

            UnitOfWork.BaseRepository<LogApi>().Update(deleteLogApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return logApi;
        }

        public void TraceLog(string entity, string entityAction, string previousValues, string newValues, string filterValues, DateTime creationDate, int? idStatus)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            StatusBudgetDto? statusSearch = idStatus != null ? new StatusBudgetDto { IdStatusBudget = (int)idStatus }  : statusRepository.GetStatusBudgetByNameStatus(new StatusBudgetDto { NameStatus = Constants.Status.ACTIVO }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            LogApi saveLogApi = new()
            {
                Entity = entity?.Trim() ?? string.Empty,
                EntityAction = entityAction?.Trim() ?? string.Empty,
                PreviousValues = previousValues?.Trim() ?? string.Empty,
                NewValues = newValues?.Trim() ?? string.Empty,
                FilterValues = filterValues?.Trim() ?? string.Empty,
                CreationDate = creationDate,
                IdStatusBudget = statusSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = creationDate                
            };

            UnitOfWork.BaseRepository<LogApi>().Add(saveLogApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        #endregion

    }
}