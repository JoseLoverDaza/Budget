namespace CORE.Interfaces.Repositories
{

    #region Librerias

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

        public AuditDto? GetAuditById(AuditDto audit);
        
        public List<AuditDto> GetAuditsByCreationDate(AuditDto audit);

        public List<AuditDto> GetAuditsByMethodCreationDate(AuditDto audit);

        public List<AuditDto> GetAuditsByEndpointCreationDate(AuditDto audit);

        public List<AuditDto> GetAuditsByEndpointMethodCreationDate(AuditDto audit);

        #endregion

    }
}