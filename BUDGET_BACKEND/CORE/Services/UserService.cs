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

        public UserExtendDto? GetUserById(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            UserExtendDto? userSearch = userRepository.GetUserById(user);

            if (userSearch != null)
            {
                return userSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserExtendDto? GetUserByEmail(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            UserExtendDto? userSearch = userRepository.GetUserByEmail(user);

            if (userSearch != null)
            {
                return userSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserExtendDto? GetUserByUsername(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            UserExtendDto? userSearch = userRepository.GetUserByUsername(user);

            if (userSearch != null)
            {
                return userSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserExtendDto> GetUsersByRole(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            List<UserExtendDto> usersSearch = userRepository.GetUsersByRole(user);

            if (usersSearch.Count != 0)
            {
                return usersSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserExtendDto> GetUsersByStatus(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            List<UserExtendDto> usersSearch = userRepository.GetUsersByStatus(user);

            if (usersSearch.Count != 0)
            {
                return usersSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserExtendDto> GetUsersByRoleStatus(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            List<UserExtendDto> usersSearch = userRepository.GetUsersByRoleStatus(user);

            if (usersSearch.Count != 0)
            {
                return usersSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserDto SaveUser(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();
            
            if (user == null || string.IsNullOrWhiteSpace(user.Email.Trim()) || string.IsNullOrWhiteSpace(user.Phone.Trim()) || string.IsNullOrWhiteSpace(user.Username.Trim()) || string.IsNullOrWhiteSpace(user.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userEmailSearch = userRepository.GetUserByEmail(user);
            UserExtendDto? userLoginSearch = userRepository.GetUserByUsername(user);

            if (userEmailSearch != null || userLoginSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleExtendDto? rolSearch = roleRepository.GetRoleById(new RoleDto { IdRole = user.IdRole }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = user.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            string sHashPassword = PasswordHash.HashPassword(user.Password);

            User saveUser = new()
            {                
                Email = user.Email.Trim(),
                Phone = user.Phone.Trim(),
                Username = user.Username.Trim(),
                Password = !string.IsNullOrWhiteSpace(sHashPassword.Trim()) ? sHashPassword.Trim() : user.Password,
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

        public UserDto UpdateUser(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
           
            if (user == null || user.IdUser <= 0 || string.IsNullOrWhiteSpace(user.Email.Trim()) || string.IsNullOrWhiteSpace(user.Phone.Trim()) || string.IsNullOrWhiteSpace(user.Username.Trim()) || string.IsNullOrWhiteSpace(user.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userEmailDuplicado = userRepository.GetUserByEmail(user);
            UserExtendDto? userLoginDuplicado = userRepository.GetUserByUsername(user);
            UserExtendDto? userSearch = userRepository.GetUserById(user) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userEmailDuplicado != null && userSearch != null && userEmailDuplicado.IdUser != user.IdUser)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (userLoginDuplicado != null && userSearch != null && userLoginDuplicado.IdUser != user.IdUser)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            string sHashPassword = PasswordHash.HashPassword(user.Password);

            User updateUser = new()
            {
                IdUser = userSearch!.IdUser,
                Email = user.Email.Trim(),
                Phone = user.Phone.Trim(),
                Username = user.Username.Trim(),
                Password = !string.IsNullOrWhiteSpace(sHashPassword.Trim()) ? sHashPassword.Trim() : user.Password,
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

        public UserDto DeleteUser(UserDto user)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            UserExtendDto? userSearch = userRepository.GetUserById(user) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = user.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userSearch.IdStatus == user.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            User deleteUser = new()
            {
                IdUser = userSearch!.IdUser,
                Email = userSearch.Email.Trim(),
                Phone = userSearch.Phone.Trim(),
                Username = userSearch.Username.Trim(),
                Password = userSearch.Password.Trim(),
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