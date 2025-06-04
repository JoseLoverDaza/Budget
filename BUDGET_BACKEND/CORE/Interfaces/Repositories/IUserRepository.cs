namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserRepository
    {

        #region Métodos y Funciones

        public UserExtendDto? GetUserById(UserDto user);

        public UserExtendDto? GetUserByEmail(UserDto user);

        public UserExtendDto? GetUserByLogin(UserDto user);

        public List<UserExtendDto> GetUsersByRole(UserDto user);

        public List<UserExtendDto> GetUsersByStatus(UserDto user);
              
        public List<UserExtendDto> GetUsersByRoleStatus(UserDto user);

        #endregion

    }
}