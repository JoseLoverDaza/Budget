namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserService : BaseService, IUserService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public UserExtendDto? GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserExtendDto? GetUserById(int idUser)
        {
            throw new NotImplementedException();
        }

        public UserExtendDto? GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public List<UserExtendDto> GetUsersByRole(int idRole)
        {
            throw new NotImplementedException();
        }

        public List<UserExtendDto> GetUsersByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<UserExtendDto> GetUsersByStatusRole(int idRole, int idStatus)
        {
            throw new NotImplementedException();
        }

        public UserExtendDto SaveUser(UserExtendDto user)
        {
            throw new NotImplementedException();
        }

        public UserExtendDto UpdateUser(UserExtendDto user)
        {
            throw new NotImplementedException();
        }

        public UserExtendDto DeleteUser(UserExtendDto user)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}