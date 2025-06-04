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
    /// Nombre: AuditRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditRepository : BaseRepository<Audit>, IAuditRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public AuditRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion


        #region Métodos y Funciones

        public AuditExtendDto? GetAuditById(AuditDto audit)
        {
            return (
                    from a in _context.Audits.AsNoTracking()                    
                    join s in _context.Status.AsNoTracking()
                    on a.IdStatus equals s.IdStatus
                    where a.IdAudit == audit.IdAudit
                    select new AuditExtendDto
                    {
                        IdAudit = a.IdAudit,
                        Host = a.Host,
                        Endpoint = a.Endpoint,
                        Agent = a.Agent,
                        Method = a.Method,
                        CreationDate = a.CreationDate,                         
                        IdStatus = a.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                )
                .FirstOrDefault();
        }

        public List<AuditExtendDto> GetAuditsByCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on a.IdStatus equals s.IdStatus
                   where a.CreationDate == audit.CreationDate
                   select new AuditExtendDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate,
                       IdStatus = a.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                  )
                 .ToList();
        }

        public List<AuditExtendDto> GetAuditsByStatus(AuditDto audit)
        {
            return (
                  from a in _context.Audits.AsNoTracking()
                  join s in _context.Status.AsNoTracking()
                  on a.IdStatus equals s.IdStatus
                  where a.IdStatus == audit.IdStatus
                  select new AuditExtendDto
                  {
                      IdAudit = a.IdAudit,
                      Host = a.Host,
                      Endpoint = a.Endpoint,
                      Agent = a.Agent,
                      Method = a.Method,
                      CreationDate = a.CreationDate,
                      IdStatus = a.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
                 )
                .ToList();
        }

        public List<AuditExtendDto> GetAuditsByMethodCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on a.IdStatus equals s.IdStatus
                   where a.Method == audit.Method && a.CreationDate == audit.CreationDate
                   select new AuditExtendDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate,
                       IdStatus = a.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                  )
                 .ToList();
        }

        public List<AuditExtendDto> GetAuditsByEndpointCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on a.IdStatus equals s.IdStatus
                   where a.Endpoint == audit.Endpoint && a.CreationDate == audit.CreationDate
                   select new AuditExtendDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate,
                       IdStatus = a.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                  )
                 .ToList();
        }

        public List<AuditExtendDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   join s in _context.Status.AsNoTracking()
                   on a.IdStatus equals s.IdStatus
                   where a.Endpoint == audit.Endpoint && a.Method == audit.Method && a.CreationDate == audit.CreationDate
                   select new AuditExtendDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate,
                       IdStatus = a.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
                  )
                 .ToList();
        }

        public List<AuditExtendDto> GetAuditsByEndpointMethodCreationDateStatus(AuditDto audit)
        {
            return (
                  from a in _context.Audits.AsNoTracking()
                  join s in _context.Status.AsNoTracking()
                  on a.IdStatus equals s.IdStatus
                  where a.Endpoint == audit.Endpoint && a.Method == audit.Method && a.CreationDate == audit.CreationDate && a.IdStatus == audit.IdStatus
                  select new AuditExtendDto
                  {
                      IdAudit = a.IdAudit,
                      Host = a.Host,
                      Endpoint = a.Endpoint,
                      Agent = a.Agent,
                      Method = a.Method,
                      CreationDate = a.CreationDate,
                      IdStatus = a.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
                 )
                .ToList();
        }

        #endregion

    }
}