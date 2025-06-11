namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserBudget   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserBudget
    {

        #region Atributos y Propiedades

        public int IdUserBudget { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;

        public int IdRoleBudget { get; set; }
        
        public int IdStatusBudget { get; set; }
        
        #endregion

    }
}