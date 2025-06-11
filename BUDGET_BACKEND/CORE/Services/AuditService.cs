namespace CORE.Services
{

    #region Librerias

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
    /// Nombre: AuditService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditService : BaseService, IAuditApiService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public AuditService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public AuditDto? GetAuditById(AuditDto audit)
        {
            IAuditApiRepository auditRepository = UnitOfWork.AuditRepository();
            AuditDto? auditSearch = auditRepository.GetAuditById(audit);

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (auditSearch != null)
            {
                return auditSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditDto> GetAuditsByCreationDate(AuditDto audit)
        {
            IAuditApiRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByCreationDate(audit);

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditDto> GetAuditsByMethodCreationDate(AuditDto audit)
        {
            IAuditApiRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByMethodCreationDate(audit);

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditDto> GetAuditsByEndpointCreationDate(AuditDto audit)
        {
            IAuditApiRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByEndpointCreationDate(audit);

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit)
        {
            IAuditApiRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByEndpointMethodCreationDate(audit);

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public AuditDto SaveAudit(AuditDto audit)
        {
            if (audit == null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Audit saveAudit = new()
            {
                Host = audit.Host?.Trim() ?? string.Empty,
                Endpoint = audit.Endpoint?.Trim() ?? string.Empty,
                Agent = audit.Agent?.Trim() ?? string.Empty,
                Method = audit.Method?.Trim() ?? string.Empty,
                CreationDate = audit.CreationDate
            };

            UnitOfWork.BaseRepository<Audit>().Add(saveAudit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveAudit), DateTime.Now, null);

            return audit;
        }

        public AuditDto UpdateAudit(AuditDto audit)
        {
            IAuditApiRepository auditRepository = UnitOfWork.AuditRepository();

            if (audit == null || audit.IdAudit <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            AuditDto? auditSearch = (auditRepository.GetAuditById(audit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));

            Audit updateAudit = new()
            {
                IdAudit = auditSearch.IdAudit,
                Host = audit.Host?.Trim() ?? string.Empty,
                Endpoint = audit.Endpoint?.Trim() ?? string.Empty,
                Agent = audit.Agent?.Trim() ?? string.Empty,
                Method = audit.Method?.Trim() ?? string.Empty,
                CreationDate = auditSearch.CreationDate
            };

            UnitOfWork.BaseRepository<Audit>().Update(updateAudit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(auditSearch), JsonSerializer.Serialize(updateAudit), DateTime.Now, null);

            return audit;
        }

        #endregion

    }
}