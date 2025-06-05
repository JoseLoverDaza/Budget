namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserService
    {

        #region Métodos y Funciones

        public UserExtendDto? GetUserById(UserDto user);

        public UserExtendDto? GetUserByEmail(UserDto user);

        public UserExtendDto? GetUserByLogin(UserDto user);

        public List<UserExtendDto> GetUsersByRole(UserDto user);

        public List<UserExtendDto> GetUsersByStatus(UserDto user);

        public List<UserExtendDto> GetUsersByRoleStatus(UserDto user);

        public UserDto SaveUser(UserDto user);

        public UserDto UpdateUser(UserDto user);

        public UserDto DeleteUser(UserDto user);

        #endregion

    }
}