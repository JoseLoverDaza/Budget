namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserRepository
    {

        #region Métodos y Funciones

        public UserExtendDto? GetUserById(int id);

        public UserExtendDto? GetUserByEmail(string email);

        public UserExtendDto? GetUserByLogin(string login);

        public List<UserExtendDto> GetUsersByRole(int role);

        public List<UserExtendDto> GetUsersByStatus(int status);
              
        public List<UserExtendDto> GetUsersByStatusRole(int role, int status);

        #endregion Methods

    }
}