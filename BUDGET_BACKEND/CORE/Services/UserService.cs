namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;    
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

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

        public UserExtendDto? GetUserById(int idUser)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            UserExtendDto? user = userRepository.GetUserById(idUser);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserExtendDto? GetUserByEmail(string email)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            UserExtendDto? user = userRepository.GetUserByEmail(email);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserExtendDto? GetUserByLogin(string login)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            UserExtendDto? user = userRepository.GetUserByLogin(login);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserExtendDto> GetUsersByRole(int idRole)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            List<UserExtendDto> users = userRepository.GetUsersByRole(idRole);

            if (users.Count != 0)
            {
                return users;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserExtendDto> GetUsersByStatus(int idStatus)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            List<UserExtendDto> users = userRepository.GetUsersByStatus(idStatus);

            if (users.Count != 0)
            {
                return users;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserExtendDto> GetUsersByRoleStatus(int idRole, int idStatus)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            List<UserExtendDto> users = userRepository.GetUsersByRoleStatus(idRole, idStatus);

            if (users.Count != 0)
            {
                return users;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserExtendDto SaveUser(UserExtendDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (user == null || string.IsNullOrWhiteSpace(user.Email.Trim()) || string.IsNullOrWhiteSpace(user.Phone.Trim()) || string.IsNullOrWhiteSpace(user.Login.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = userRepository.GetUserByLogin(user.Login.Trim());

            if (userSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleExtendDto? rolSearch = roleRepository.GetRoleById(user.IdRole) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(user.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            User saveUser = new()
            {                
                Email = user.Email.Trim(),
                Phone = user.Phone.Trim(),
                Login = user.Login.Trim(),
                Password = user.Password!.Trim(),
                IdRole = rolSearch.IdRole,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<User>().Add(saveUser);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return user;
        }

        public UserExtendDto UpdateUser(UserExtendDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
           
            if (user == null || user.IdUser <= 0 || string.IsNullOrWhiteSpace(user.Email.Trim()) || string.IsNullOrWhiteSpace(user.Phone.Trim()) || string.IsNullOrWhiteSpace(user.Login.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userDuplicado = userRepository.GetUserByLogin(user.Login);
            UserExtendDto? userSearch = userRepository.GetUserById(user.IdUser) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userDuplicado != null && userSearch != null && userDuplicado.IdUser != user.IdUser)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            User updateUser = new()
            {
                IdUser = userSearch!.IdUser,
                Email = user.Email.Trim(),
                Phone = user.Phone.Trim(),
                Login = user.Login.Trim(),
                Password = user.Password!.Trim(),
                IdRole = userSearch.IdRole,
                IdStatus = userSearch.IdStatus
            };

            UnitOfWork.BaseRepository<User>().Update(updateUser);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return user;
        }

        public UserExtendDto DeleteUser(UserExtendDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            UserExtendDto? userSearch = userRepository.GetUserById(user.IdUser) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(user.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == user.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            User deleteUser = new()
            {
                IdUser = userSearch!.IdUser,
                Email = userSearch.Email.Trim(),
                Phone = userSearch.Phone.Trim(),
                Login = userSearch.Login.Trim(),
                Password = userSearch.Password!.Trim(),
                IdRole = userSearch.IdRole,               
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<User>().Update(deleteUser);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return user;
        }

        #endregion

    }
}