namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
   
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserService
    {

        #region Métodos y Funciones

        public UserExtendDto? GetUserById(int idUser);

        public UserExtendDto? GetUserByEmail(string email);

        public UserExtendDto? GetUserByLogin(string login);

        public List<UserExtendDto> GetUsersByRole(int idRole);

        public List<UserExtendDto> GetUsersByStatus(int idStatus);

        public List<UserExtendDto> GetUsersByRoleStatus(int idRole, int idStatus);

        public UserExtendDto SaveUser(UserExtendDto user);

        public UserExtendDto UpdateUser(UserExtendDto user);

        public UserExtendDto DeleteUser(UserExtendDto user);

        #endregion

    }
}