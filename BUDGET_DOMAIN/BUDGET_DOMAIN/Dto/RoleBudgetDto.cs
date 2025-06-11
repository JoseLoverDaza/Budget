namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleBudgetDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleBudgetDto
    {

        #region Atributos y Propiedades

        public int IdRoleBudget { get; set; }
        public string NameRole { get; set; } = null!;
        public string? DescriptionRole { get; set; }

        public int IdStatusBudget { get; set; }
        
        #endregion

    }
}