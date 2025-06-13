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

        public AuditApiDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            AuditApiDto? auditApisSearch = auditApiRepository.GetAuditApiByIdAuditApi(auditApi);

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

        public List<AuditApiDto> GetAuditApisByCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiDto> auditApisSearch = auditApiRepository.GetAuditApisByCreationDate(auditApi);

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

        public List<AuditApiDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiDto> auditApisSearch = auditApiRepository.GetAuditApisByMethodCreationDate(auditApi);

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

        public List<AuditApiDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiDto> auditApisSearch = auditApiRepository.GetAuditApisByEndpointUrlCreationDate(auditApi);

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

        public List<AuditApiDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi)
        {
            IAuditApiRepository auditApiRepository = UnitOfWork.AuditApiRepository();
            List<AuditApiDto> auditApisSearch = auditApiRepository.GetAuditApisByEndpointUrlMethodCreationDate(auditApi);

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

        #endregion

    }
}