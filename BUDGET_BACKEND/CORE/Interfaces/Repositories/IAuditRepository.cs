namespace CORE.Interfaces.Repositories
{


    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAuditRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAuditRepository
    {

        #region Métodos y Funciones

        public AuditExtendDto? GetAuditById(AuditDto audit);
        
        public List<AuditExtendDto> GetAuditsByCreationDate(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByStatus(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByMethodCreationDate(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByEndpointCreationDate(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit);

        public List<AuditExtendDto> GetAuditsByEndpointMethodCreationDateStatus(AuditDto audit);

        #endregion

    }
}