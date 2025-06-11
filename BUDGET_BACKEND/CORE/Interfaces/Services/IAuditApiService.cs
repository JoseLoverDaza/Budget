namespace CORE.Interfaces.Services
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAuditApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAuditApiService
    {

        #region Métodos y Funciones

        public AuditApiDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByCreationDate(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi);

        public AuditApiDto SaveAuditApi(AuditApiDto auditApi);

        public AuditApiDto UpdateAuditApi(AuditApiDto auditApi);

        #endregion

    }
}