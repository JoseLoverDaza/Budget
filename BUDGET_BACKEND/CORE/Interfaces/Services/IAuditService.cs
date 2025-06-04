namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
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

        public AuditExtendDto? GetAuditById(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByCreationDate(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByStatus(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByMethodCreationDate(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByEndpointCreationDate(AuditDto audit);

        public AuditExtendDto SaveAudit(AuditDto audit);

        public AuditExtendDto UpdateAudit(AuditDto audit);

        public AuditExtendDto DeleteAudit(AuditDto audit);

        #endregion

    }
}