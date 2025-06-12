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
    /// Nombre: UserBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserBudgetService : BaseService, IUserBudgetService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public UserBudgetService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public UserBudgetExtendDto? GetUserBudgetByIdUserBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(userBudget);

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userBudgetSearch != null)
            {
                return userBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserBudgetExtendDto? GetUserBudgetByEmail(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByEmail(userBudget);

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userBudgetSearch != null)
            {
                return userBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserBudgetExtendDto? GetUserBudgetByUsername(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByUsername(userBudget);

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userBudgetSearch != null)
            {
                return userBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            List<UserBudgetExtendDto> userBudgetSearch = userBudgetRepository.GetUsersBudgetByRoleBudget(userBudget);

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userBudgetSearch.Count != 0)
            {
                return userBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserBudgetExtendDto> GetUsersBudgetByStatusBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            List<UserBudgetExtendDto> userBudgetSearch = userBudgetRepository.GetUsersBudgetByStatusBudget(userBudget);

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userBudgetSearch.Count != 0)
            {
                return userBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudgetStatusBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            List<UserBudgetExtendDto> userBudgetSearch = userBudgetRepository.GetUsersBudgetByRoleBudgetStatusBudget(userBudget);

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (userBudgetSearch.Count != 0)
            {
                return userBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public UserBudgetDto SaveUserBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (userBudget == null || string.IsNullOrWhiteSpace(userBudget.Email.Trim()) || string.IsNullOrWhiteSpace(userBudget.Phone.Trim()) || string.IsNullOrWhiteSpace(userBudget.Username.Trim()) || string.IsNullOrWhiteSpace(userBudget.EncryptedPassword.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetEmailSearch = userBudgetRepository.GetUserBudgetByEmail(userBudget);
            UserBudgetExtendDto? userBudgetLoginSearch = userBudgetRepository.GetUserBudgetByUsername(userBudget);

            if (userBudgetEmailSearch != null || userBudgetLoginSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleBudgetExtendDto? roleBudgetSearch = roleBudgetRepository.GetRoleBudgetByIdRoleBudget(new RoleBudgetDto { IdRoleBudget = userBudget.IdRoleBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = userBudget.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            string sHashPassword = PasswordHash.HashPassword(userBudget.EncryptedPassword);

            UserBudget saveUserBudget = new()
            {
                Email = userBudget.Email.Trim(),
                Phone = userBudget.Phone.Trim(),
                Username = userBudget.Username.Trim(),
                EncryptedPassword = !string.IsNullOrWhiteSpace(sHashPassword.Trim()) ? sHashPassword.Trim() : userBudget.EncryptedPassword,
                IdRoleBudget = roleBudgetSearch.IdRoleBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<UserBudget>().Add(saveUserBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveUserBudget), DateTime.Now, null);

            return userBudget;
        }

        public UserBudgetDto UpdateUserBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();

            if (userBudget == null || userBudget.IdUserBudget <= 0 || string.IsNullOrWhiteSpace(userBudget.Email.Trim()) || string.IsNullOrWhiteSpace(userBudget.Phone.Trim()) || string.IsNullOrWhiteSpace(userBudget.Username.Trim()) || string.IsNullOrWhiteSpace(userBudget.EncryptedPassword.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetEmailDuplicado = userBudgetRepository.GetUserBudgetByEmail(userBudget);
            UserBudgetExtendDto? userBudgetLoginDuplicado = userBudgetRepository.GetUserBudgetByUsername(userBudget);
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(userBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userBudgetEmailDuplicado != null && userBudgetSearch != null && userBudgetEmailDuplicado.IdUserBudget != userBudget.IdUserBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (userBudgetLoginDuplicado != null && userBudgetSearch != null && userBudgetLoginDuplicado.IdUserBudget != userBudget.IdUserBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            string sHashPassword = PasswordHash.HashPassword(userBudget.EncryptedPassword);

            UserBudget updateUserBudget = new()
            {
                IdUserBudget = userBudgetSearch!.IdUserBudget,
                Email = userBudget.Email.Trim(),
                Phone = userBudget.Phone.Trim(),
                Username = userBudget.Username.Trim(),
                EncryptedPassword = !string.IsNullOrWhiteSpace(sHashPassword.Trim()) ? sHashPassword.Trim() : userBudget.EncryptedPassword,
                IdRoleBudget = userBudgetSearch.IdRoleBudget,
                IdStatusBudget = userBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<UserBudget>().Update(updateUserBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(userBudgetSearch), JsonSerializer.Serialize(updateUserBudget), DateTime.Now, null);

            return userBudget;
        }

        public UserBudgetDto DeleteUserBudget(UserBudgetDto userBudget)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(userBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = userBudget.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userBudgetSearch.IdStatusBudget == userBudget.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudget deleteUserBudget = new()
            {
                IdUserBudget = userBudgetSearch!.IdUserBudget,
                Email = userBudgetSearch.Email.Trim(),
                Phone = userBudgetSearch.Phone.Trim(),
                Username = userBudgetSearch.Username.Trim(),
                EncryptedPassword = userBudgetSearch.EncryptedPassword.Trim(),
                IdRoleBudget = userBudgetSearch.IdRoleBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<UserBudget>().Update(deleteUserBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(UserBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(userBudgetSearch), JsonSerializer.Serialize(deleteUserBudget), DateTime.Now, null);

            return userBudget;
        }

        #endregion

    }
}