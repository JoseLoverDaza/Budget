namespace CORE.Dto
{

    #region Using

    using Domain.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositExtendDto : DepositDto
    {

        #region Atributos y Propiedades
               
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}