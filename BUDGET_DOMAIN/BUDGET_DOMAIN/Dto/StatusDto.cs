namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusDto
    {

        #region Atributos y Propiedades

        public int IdStatus { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        #endregion

    }
}