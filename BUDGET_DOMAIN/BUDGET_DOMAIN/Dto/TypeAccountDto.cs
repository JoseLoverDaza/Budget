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
        public string NameTypeAccount { get; set; } = null!;
        public string? DescriptionTypeAccount { get; set; }

        public int IdStatusBudget { get; set; }       

        #endregion

    }
}