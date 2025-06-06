namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Audit   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class Audit
    {

        #region Atributos y Propiedades
               
        public long IdAudit { get; set; }               
        public string? Host { get; set; }               
        public string? Endpoint { get; set; }               
        public string? Agent { get; set; }               
        public string? Method { get; set; }               
        public DateTime CreationDate { get; set; }

        #endregion

    }
}