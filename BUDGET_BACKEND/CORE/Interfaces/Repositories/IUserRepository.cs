namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserRepository
    {

        #region Métodos y Funciones

        public UserExtendDto? GetUserById(int idUser);

        public UserExtendDto? GetUserByEmail(string email);

        public UserExtendDto? GetUserByLogin(string login);

        public List<UserExtendDto> GetUsersByRole(int idRole);

        public List<UserExtendDto> GetUsersByStatus(int idStatus);
              
        public List<UserExtendDto> GetUsersByStatusRole(int idRole, int idStatus);

        #endregion

    }
}