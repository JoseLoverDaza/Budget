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
    /// Nombre: AuditService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditService : BaseService, IAuditService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public AuditService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public AuditExtendDto? GetAuditById(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            AuditExtendDto? auditSearch = auditRepository.GetAuditById(audit);

            if (auditSearch != null)
            {
                return auditSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditExtendDto> GetAuditsByCreationDate(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditExtendDto> auditsSearch = auditRepository.GetAuditsByCreationDate(audit);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditExtendDto> GetAuditsByStatus(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditExtendDto> auditsSearch = auditRepository.GetAuditsByStatus(audit);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditExtendDto> GetAuditsByMethodCreationDate(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditExtendDto> auditsSearch = auditRepository.GetAuditsByMethodCreationDate(audit);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditExtendDto> GetAuditsByEndpointCreationDate(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditExtendDto> auditsSearch = auditRepository.GetAuditsByEndpointCreationDate(audit);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditExtendDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditExtendDto> auditsSearch = auditRepository.GetAuditsByEndpointMethodCreationDate(audit);

            if (auditsSearch.Count != 0)
            {
                return auditsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<AuditExtendDto> GetAuditsByEndpointMethodCreationDateStatus(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditExtendDto> auditsSearch = auditRepository.GetAuditsByEndpointMethodCreationDateStatus(audit);

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
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (audit == null || DateTime.Now < audit.CreationDate)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = audit.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Audit saveAudit = new()
            {
                Host = audit.Host!.Trim() ?? string.Empty,
                Endpoint = audit.Endpoint!.Trim() ?? string.Empty,
                Agent = audit.Agent!.Trim() ?? string.Empty,
                Method = audit.Method!.Trim() ?? string.Empty,
                CreationDate = audit.CreationDate,               
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Audit>().Add(saveAudit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return audit;
        }

        public AuditDto UpdateAudit(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();

            if (audit == null || audit.IdAudit <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                      
            AuditExtendDto? auditSearch = auditRepository.GetAuditById(audit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (auditSearch == null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Audit updateAudit = new()
            {
                IdAudit = auditSearch.IdAudit,
                Host = audit.Host!.Trim() ?? string.Empty,
                Endpoint = audit.Endpoint!.Trim() ?? string.Empty,
                Agent = audit.Agent!.Trim() ?? string.Empty,
                Method = audit.Method!.Trim() ?? string.Empty,
                CreationDate = auditSearch.CreationDate,
                IdStatus = auditSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Audit>().Update(updateAudit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return audit;
        }

        public AuditDto DeleteAudit(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            AuditExtendDto? auditSearch = auditRepository.GetAuditById(audit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = audit.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (auditSearch.IdStatus == statusSearch.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Audit deleteAudit = new()
            {
                IdAudit = auditSearch.IdAudit,
                Host = auditSearch.Host!.Trim() ?? string.Empty,
                Endpoint = auditSearch.Endpoint!.Trim() ?? string.Empty,
                Agent = auditSearch.Agent!.Trim() ?? string.Empty,
                Method = auditSearch.Method!.Trim() ?? string.Empty,
                CreationDate = auditSearch.CreationDate,
                IdStatus = audit.IdStatus
            };

            UnitOfWork.BaseRepository<Audit>().Update(deleteAudit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return audit;
        }

        #endregion

    }
}