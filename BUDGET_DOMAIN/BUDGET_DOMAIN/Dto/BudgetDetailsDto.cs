namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetDetailsDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDetailsDto
    {

        #region Atributos y Propiedades

        public int IdBudgetDetails { get; set; }
        public int IdBudget { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Amount { get; set; }

        public int IdExpense { get; set; }

        public int IdStatus { get; set; }

        #endregion

    }
}