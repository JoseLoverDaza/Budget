namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserDto
    {

        #region Atributos y Propiedades

        public int IdUser { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int IdRole { get; set; }       

        public int IdStatus { get; set; }        

        #endregion

    }
}