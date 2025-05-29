namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDto
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