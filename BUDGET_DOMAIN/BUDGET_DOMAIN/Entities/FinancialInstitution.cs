namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitution   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitution
    {

        #region Atributos y Propiedades

        public int IdFinancialInstitution { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int IdStatus { get; set; }
        
        #endregion

    }
}