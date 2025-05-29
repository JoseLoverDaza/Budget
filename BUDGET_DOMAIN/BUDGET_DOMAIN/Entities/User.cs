namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: User   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class User
    {

        #region Atributos y Propiedades

        public int IdUser { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int IdRole { get; set; }
        
        public int IdStatus { get; set; }
        
        #endregion

    }
}