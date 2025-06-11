namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TokenApiDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TokenApiDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdTokenApi { get; set; }
        public string Token { get; set; } = null!;      
        public DateTime ExpirationDate { get; set; } = DateTime.Now;

        public int IdUserBudget { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}