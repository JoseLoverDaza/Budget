namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuditApiExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuditApiExtendDto : AuditApiDto
    {

        #region Atributos y Propiedades

        public string NameStatusBudget { get; set; } = null!;
        public string? DescriptionStatusBudget { get; set; }

        #endregion

    }
}