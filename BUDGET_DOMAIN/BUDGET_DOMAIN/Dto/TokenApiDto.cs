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

        public long IdToken { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;

        public int IdUser { get; set; }

        public int IdStatus { get; set; }

        #endregion

    }
}