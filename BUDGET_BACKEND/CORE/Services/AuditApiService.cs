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
    using System.Security.Principal;
    using System.Text.Json;
    using static CORE.Utils.Constants;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuditApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditApiService : BaseService, IAuditApiService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public AuditApiService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public AuditApiExtendDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            AuditApiExtendDto? auditApisSearch = auditApiRepository.GetAuditApiByIdAuditApi(auditApi);

            _logApiService.TraceLog(typeof(AuditApi).Name, EntityAction.CONSULT, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(auditApi), DateTime.Now, null);

            if (auditApisSearch != null)
            {
                return auditApisSearch;
            }
            else
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
        }

        public List<AuditApiExtendDto> GetAuditApisByCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiExtendDto> auditApisSearch = auditApiRepository.GetAuditApisByCreationDate(auditApi);

            _logApiService.TraceLog(typeof(AuditApi).Name, EntityAction.CONSULT, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(auditApi), DateTime.Now, null);

            if (auditApisSearch.Count != 0)
            {
                return auditApisSearch;
            }
            else
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
        }

        public List<AuditApiExtendDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiExtendDto> auditApisSearch = auditApiRepository.GetAuditApisByMethodCreationDate(auditApi);

            _logApiService.TraceLog(typeof(AuditApi).Name, EntityAction.CONSULT, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(auditApi), DateTime.Now, null);

            if (auditApisSearch.Count != 0)
            {
                return auditApisSearch;
            }
            else
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
        }

        public List<AuditApiExtendDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiExtendDto> auditApisSearch = auditApiRepository.GetAuditApisByEndpointUrlCreationDate(auditApi);

            _logApiService.TraceLog(typeof(AuditApi).Name, EntityAction.CONSULT, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(auditApi), DateTime.Now, null);

            if (auditApisSearch.Count != 0)
            {
                return auditApisSearch;
            }
            else
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
        }

        public List<AuditApiExtendDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiExtendDto> auditApisSearch = auditApiRepository.GetAuditApisByEndpointUrlMethodCreationDate(auditApi);

            _logApiService.TraceLog(typeof(AuditApi).Name, EntityAction.CONSULT, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(auditApi), DateTime.Now, null);

            if (auditApisSearch.Count != 0)
            {
                return auditApisSearch;
            }
            else
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
        }

        public AuditApiDto SaveAuditApi(AuditApiDto auditApi)
        {
            if (auditApi == null)
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(General.MESSAGE_GENERAL);

            AuditApi saveAuditApi = new()
            {
                Host = auditApi.Host?.Trim() ?? string.Empty,
                EndpointUrl = auditApi.EndpointUrl?.Trim() ?? string.Empty,
                Agent = auditApi.Agent?.Trim() ?? string.Empty,
                Method = auditApi.Method?.Trim() ?? string.Empty,
                IdStatusBudget = auditApi.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = auditApi.CreationDate,
                ModificationDate = auditApi.ModificationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget
            };

            UnitOfWork.BaseRepository<AuditApi>().Add(saveAuditApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            return auditApi;
        }

        public AuditApiDto UpdateAuditApi(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();

            if (auditApi == null || auditApi.IdAuditApi <= 0)
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            AuditApiDto? auditApiSearch = (auditApiRepository.GetAuditApiByIdAuditApi(auditApi) ?? throw new ExternalException(General.MESSAGE_GENERAL));

            AuditApi updateAudit = new()
            {
                IdAuditApi = auditApiSearch.IdAuditApi,
                Host = auditApi.Host?.Trim() ?? string.Empty,
                EndpointUrl = auditApi.EndpointUrl?.Trim() ?? string.Empty,
                Agent = auditApi.Agent?.Trim() ?? string.Empty,
                Method = auditApi.Method?.Trim() ?? string.Empty,
                CreationUser = auditApiSearch.CreationUser,
                CreationDate = auditApiSearch.CreationDate,
                ModificationUser = auditApiSearch.ModificationUser,
                ModificationDate = auditApi.ModificationDate                
            };

            UnitOfWork.BaseRepository<AuditApi>().Update(updateAudit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            return auditApi;
        }

        public AuditApiDto DeleteAuditApi(AuditApiDto auditApi) 
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            AuditApiExtendDto? auditApiSearch = auditApiRepository.GetAuditApiByIdAuditApi(auditApi) ?? throw new ExternalException(General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = auditApi.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (auditApiSearch.IdStatusBudget == statusBudgetSearch.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            AuditApi deleteAuditApi = new()
            {
                IdAuditApi = auditApiSearch.IdAuditApi,
                Host = auditApiSearch.Host,
                EndpointUrl = auditApiSearch.EndpointUrl,
                Agent = auditApiSearch.Agent,
                Method = auditApiSearch.Method,               
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = auditApiSearch.CreationUser,
                CreationDate = auditApiSearch.CreationDate,
                ModificationUser = auditApiSearch.ModificationUser,
                ModificationDate = auditApiSearch.ModificationDate
            };

            UnitOfWork.BaseRepository<AuditApi>().Update(deleteAuditApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return auditApi;
        }

        #endregion

    }
}