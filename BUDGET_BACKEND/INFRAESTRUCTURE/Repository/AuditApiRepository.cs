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
    /// Nombre: AuditApiRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditApiRepository : BaseRepository<AuditApi>, IAuditApiRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public AuditApiRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public AuditApiDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    where a.IdAuditApi == auditApi.IdAuditApi
                    select new AuditApiDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        CreationDate = a.CreationDate
                    }
                )
                .FirstOrDefault();
        }

        public List<AuditApiDto> GetAuditApisByCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    where a.CreationDate == auditApi.CreationDate
                    select new AuditApiDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        CreationDate = a.CreationDate
                    }
                  )
                 .ToList();
        }

        public List<AuditApiDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    where a.Method == auditApi.Method && a.CreationDate == auditApi.CreationDate
                    select new AuditApiDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        CreationDate = a.CreationDate
                    }
                  )
                 .ToList();
        }

        public List<AuditApiDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    where a.EndpointUrl == auditApi.EndpointUrl && a.CreationDate == auditApi.CreationDate
                    select new AuditApiDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        CreationDate = a.CreationDate
                    }
                  )
                 .ToList();
        }

        public List<AuditApiDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    where a.EndpointUrl == auditApi.EndpointUrl && a.Method == auditApi.Method && a.CreationDate == auditApi.CreationDate
                    select new AuditApiDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
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