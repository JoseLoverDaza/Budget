namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuditApiDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditApiDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdAuditApi { get; set; }
        public string? Host { get; set; }
        public string? EndpointUrl { get; set; }
        public string? Agent { get; set; }
        public string? Method { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}