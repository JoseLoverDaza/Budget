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

        public AuditApiExtendDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.IdAuditApi == auditApi.IdAuditApi
                    select new AuditApiExtendDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                )
                .FirstOrDefault();
        }

        public List<AuditApiExtendDto> GetAuditApisByCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.CreationDate.Date == auditApi.CreationDate.Date
                    select new AuditApiExtendDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<AuditApiExtendDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.Method == auditApi.Method && a.CreationDate.Date == auditApi.CreationDate.Date
                    select new AuditApiExtendDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<AuditApiExtendDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.EndpointUrl == auditApi.EndpointUrl && a.CreationDate.Date == auditApi.CreationDate.Date
                    select new AuditApiExtendDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                 .ToList();
        }

        public List<AuditApiExtendDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi)
        {
            return (
                    from a in _context.AuditApis.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on a.IdStatusBudget equals s.IdStatusBudget
                    where a.EndpointUrl == auditApi.EndpointUrl && a.Method == auditApi.Method && a.CreationDate.Date == auditApi.CreationDate.Date
                    select new AuditApiExtendDto
                    {
                        IdAuditApi = a.IdAuditApi,
                        Host = a.Host,
                        EndpointUrl = a.EndpointUrl,
                        Agent = a.Agent,
                        Method = a.Method,
                        IdStatusBudget = a.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = a.CreationUser,
                        CreationDate = a.CreationDate,
                        ModificationUser = a.ModificationUser,
                        ModificationDate = a.ModificationDate
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}