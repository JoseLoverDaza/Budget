namespace CORE.Dto
{

    #region Librerias

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuthenticationDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuthenticationDto
    {

        #region Atributos y Propiedades

        public int IdUserBudget { get; set; }
        public string Username { get; set; } = null!;
        public string NameRoleBudget { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        public bool IsAuthenticated { get; set; }

        #endregion

    }
}