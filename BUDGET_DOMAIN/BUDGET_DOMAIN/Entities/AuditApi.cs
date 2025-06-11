namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuditApi   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditApi
    {

        #region Atributos y Propiedades
               
        public int IdAuditApi { get; set; }               
        public string? Host { get; set; }               
        public string? EndpointUrl { get; set; }               
        public string? Agent { get; set; }               
        public string? Method { get; set; }               
        public DateTime CreationDate { get; set; }

        #endregion

    }
}