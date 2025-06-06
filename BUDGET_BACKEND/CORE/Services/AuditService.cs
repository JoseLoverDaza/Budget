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

        public AuditDto? GetAuditById(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            AuditDto? auditSearch = auditRepository.GetAuditById(audit);

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
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByCreationDate(audit);

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
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByMethodCreationDate(audit);

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
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByEndpointCreationDate(audit);

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
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();
            List<AuditDto> auditsSearch = auditRepository.GetAuditsByEndpointMethodCreationDate(audit);

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
            return audit;
        }

        public AuditDto UpdateAudit(AuditDto audit)
        {
            IAuditRepository auditRepository = UnitOfWork.AuditRepository();

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
            return audit;
        }

        #endregion

    }
}