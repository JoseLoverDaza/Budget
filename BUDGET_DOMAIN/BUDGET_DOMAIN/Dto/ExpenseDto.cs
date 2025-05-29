namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseDto
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