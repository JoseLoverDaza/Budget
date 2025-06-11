namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeAccount   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccount: BaseEntity
    {

        #region Atributos y Propiedades

        public int IdTypeAccount { get; set; }
        public string NameTypeAccount { get; set; } = null!;
        public string? DescriptionTypeAccount { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}