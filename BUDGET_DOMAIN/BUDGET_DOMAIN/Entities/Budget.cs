namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Budget   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class Budget : BaseEntity
    {

        #region Atributos y Propiedades

        public int IdBudget { get; set; }
        public short YearBudget { get; set; }
        public byte MonthBudget { get; set; }       
        public string? DescriptionBudget { get; set; }
        public string? ObservationBudget { get; set; }

        public int IdUserBudget { get; set; }
      
        public int IdStatusBudget { get; set; }
       
        #endregion

    }
}