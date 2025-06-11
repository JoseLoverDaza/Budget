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
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserService : BaseService, IUserBudgetService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public UserService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public UserBudgetExtendDto? GetUserById(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            UserBudgetExtendDto? userSearch = userRepository.GetUserById(user);

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userSearch != null)
            {
                return userSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserBudgetExtendDto? GetUserByEmail(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            UserBudgetExtendDto? userSearch = userRepository.GetUserByEmail(user);

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userSearch != null)
            {
                return userSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserBudgetExtendDto? GetUserByUsername(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            UserBudgetExtendDto? userSearch = userRepository.GetUserByUsername(user);

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userSearch != null)
            {
                return userSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserBudgetExtendDto> GetUsersByRole(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            List<UserBudgetExtendDto> usersSearch = userRepository.GetUsersByRole(user);

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (usersSearch.Count != 0)
            {
                return usersSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserBudgetExtendDto> GetUsersByStatus(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            List<UserBudgetExtendDto> usersSearch = userRepository.GetUsersByStatus(user);

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (usersSearch.Count != 0)
            {
                return usersSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserBudgetExtendDto> GetUsersByRoleStatus(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            List<UserBudgetExtendDto> usersSearch = userRepository.GetUsersByRoleStatus(user);

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            IRoleBudgetRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            if (user == null || string.IsNullOrWhiteSpace(user.Email.Trim()) || string.IsNullOrWhiteSpace(user.Phone.Trim()) || string.IsNullOrWhiteSpace(user.Username.Trim()) || string.IsNullOrWhiteSpace(user.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userEmailSearch = userRepository.GetUserByEmail(user);
            UserBudgetExtendDto? userLoginSearch = userRepository.GetUserByUsername(user);

            if (userEmailSearch != null || userLoginSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleBudgetExtendDto? rolSearch = roleRepository.GetRoleById(new RoleDto { IdRole = user.IdRole }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
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

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveUser), DateTime.Now, null);

            return user;
        }

        public UserDto UpdateUser(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();

            if (user == null || user.IdUser <= 0 || string.IsNullOrWhiteSpace(user.Email.Trim()) || string.IsNullOrWhiteSpace(user.Phone.Trim()) || string.IsNullOrWhiteSpace(user.Username.Trim()) || string.IsNullOrWhiteSpace(user.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userEmailDuplicado = userRepository.GetUserByEmail(user);
            UserBudgetExtendDto? userLoginDuplicado = userRepository.GetUserByUsername(user);
            UserBudgetExtendDto? userSearch = userRepository.GetUserById(user) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(userSearch), JsonSerializer.Serialize(updateUser), DateTime.Now, null);

            return user;
        }

        public UserDto DeleteUser(UserDto user)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            UserBudgetExtendDto? userSearch = userRepository.GetUserById(user) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
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

            _logApiService.TraceLog(typeof(User).Name, Constants.Method.POST, JsonSerializer.Serialize(userSearch), JsonSerializer.Serialize(deleteUser), DateTime.Now, null);

            return user;
        }

        #endregion

    }
}