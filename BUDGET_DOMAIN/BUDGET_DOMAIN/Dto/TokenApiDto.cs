namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TokenApiDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TokenApiDto
    {

        #region Atributos y Propiedades

        public int IdTokenApi { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;

        public int IdUserBudget { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}