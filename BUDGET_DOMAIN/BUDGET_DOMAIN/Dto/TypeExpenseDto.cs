namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpenseDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpenseDto
    {

        #region Atributos y Propiedades

        public int IdTypeExpense { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int IdStatus { get; set; }

        #endregion

    }
}