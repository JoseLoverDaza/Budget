namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Expense   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class Expense
    {

        #region Atributos y Propiedades

        public int IdExpense { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int IdTypeExpense { get; set; }

        public int IdStatus { get; set; }

        #endregion


    }
}