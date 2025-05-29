namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpense   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpense
    {

        #region Atributos y Propiedades

        public int IdTypeExpense { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int IdStatus { get; set; }
        
        #endregion

    }
}