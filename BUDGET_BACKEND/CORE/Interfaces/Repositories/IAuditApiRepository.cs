namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAuditApiRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAuditApiRepository
    {

        #region Métodos y Funciones

        public AuditApiDto? GetAuditApiByIdAuditApi(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByCreationDate(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByMethodCreationDate(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi);

        public List<AuditApiDto> GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi);

        #endregion

    }
}