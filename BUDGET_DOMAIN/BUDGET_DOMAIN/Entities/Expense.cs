namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Expense   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class Expense : BaseEntity
    {

        #region Atributos y Propiedades

        public int IdExpense { get; set; }
        public string NameExpense { get; set; } = null!;
        public string? DescriptionExpense { get; set; }

        public int IdTypeExpense { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}