namespace CORE.Dto
{

    #region Using

    using Domain.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserExtendDto
    {

        #region Atributos y Propiedades

        public string NameRole { get; set; } = null!;
        public string? DescriptionRole { get; set; }
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}