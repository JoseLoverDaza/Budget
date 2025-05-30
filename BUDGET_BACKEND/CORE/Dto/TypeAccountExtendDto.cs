namespace CORE.Dto
{

    #region Using

    using Domain.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeAccountExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccountExtendDto : TypeAccountDto
    {

        #region Atributos y Propiedades

        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}