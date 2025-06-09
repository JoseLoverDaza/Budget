namespace CORE.Interfaces.Services
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAuditService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAuditService
    {

        #region Métodos y Funciones

        public AuditDto? GetAuditById(AuditDto audit);

        public List<AuditDto> GetAuditsByCreationDate(AuditDto audit);

        public List<AuditDto> GetAuditsByMethodCreationDate(AuditDto audit);

        public List<AuditDto> GetAuditsByEndpointCreationDate(AuditDto audit);

        public List<AuditDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit);

        public AuditDto SaveAudit(AuditDto audit);

        public AuditDto UpdateAudit(AuditDto audit);

        #endregion

    }
}