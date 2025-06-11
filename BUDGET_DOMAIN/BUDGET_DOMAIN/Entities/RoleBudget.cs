namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleBudget   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleBudget : BaseEntity
    {

        #region Atributos y Propiedades

        public int IdRoleBudget { get; set; }
        public string NameRole { get; set; } = null!;
        public string? DescriptionRole { get; set; }

        public int IdStatusBudget { get; set; }
        
        #endregion

    }
}