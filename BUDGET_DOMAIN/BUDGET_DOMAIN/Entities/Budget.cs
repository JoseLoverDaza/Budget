namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Budget   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class Budget
    {

        #region Atributos y Propiedades

        public int IdBudget { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }

        public int IdUser { get; set; }
      
        public int IdStatus { get; set; }
       
        #endregion

    }
}