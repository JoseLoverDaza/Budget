namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusBudget   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusBudget
    {

        #region Atributos y Propiedades

        public int IdStatusBudget { get; set; }
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}