namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeAccountDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccountDto
    {

        #region Atributos y Propiedades

        public int IdTypeAccount { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int IdStatus { get; set; }       

        #endregion

    }
}