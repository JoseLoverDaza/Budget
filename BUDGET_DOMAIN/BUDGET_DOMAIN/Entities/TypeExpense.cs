namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpense   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpense : BaseEntity
    {

        #region Atributos y Propiedades

        public int IdTypeExpense { get; set; }
        public string NameTypeExpense { get; set; } = null!;
        public string? DescriptionTypeExpense { get; set; }

        public int IdStatusBudget { get; set; }
        
        #endregion

    }
}