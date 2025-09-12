namespace CORE.Interfaces.Services
{
    using CORE.Dto;

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

        public AuditApiExtendDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi);

        public List<AuditApiExtendDto> GetAuditApisByCreationDate(AuditApiDto auditApi);

        public List<AuditApiExtendDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi);

        public List<AuditApiExtendDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi);

        public List<AuditApiExtendDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi);

        public AuditApiDto SaveAuditApi(AuditApiDto auditApi);

        public AuditApiDto UpdateAuditApi(AuditApiDto auditApi);

        public AuditApiDto DeleteAuditApi(AuditApiDto auditApi);

        #endregion

    }
}