namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

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

        public AuditDto? GetAuditById(AuditDto audit)
        {
            return (
                    from a in _context.Audits.AsNoTracking()
                    where a.IdAudit == audit.IdAudit
                    select new AuditDto
                    {
                        IdAudit = a.IdAudit,
                        Host = a.Host,
                        Endpoint = a.Endpoint,
                        Agent = a.Agent,
                        Method = a.Method,
                        CreationDate = a.CreationDate
                    }
                )
                .FirstOrDefault();
        }

        public List<AuditDto> GetAuditsByCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   where a.CreationDate == audit.CreationDate
                   select new AuditDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate
                   }
                  )
                 .ToList();
        }

        public List<AuditDto> GetAuditsByMethodCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   where a.Method == audit.Method && a.CreationDate == audit.CreationDate
                   select new AuditDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate
                   }
                  )
                 .ToList();
        }

        public List<AuditDto> GetAuditsByEndpointCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   where a.Endpoint == audit.Endpoint && a.CreationDate == audit.CreationDate
                   select new AuditDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate
                   }
                  )
                 .ToList();
        }

        public List<AuditDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit)
        {
            return (
                   from a in _context.Audits.AsNoTracking()
                   where a.Endpoint == audit.Endpoint && a.Method == audit.Method && a.CreationDate == audit.CreationDate
                   select new AuditDto
                   {
                       IdAudit = a.IdAudit,
                       Host = a.Host,
                       Endpoint = a.Endpoint,
                       Agent = a.Agent,
                       Method = a.Method,
                       CreationDate = a.CreationDate
                   }
                  )
                 .ToList();
        }

        #endregion

    }
}