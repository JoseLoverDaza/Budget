namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleDto
    {

        #region Atributos y Propiedades

        public int IdRole { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int IdStatus { get; set; }
        
        #endregion

    }
}