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
    /// Nombre: RoleBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class RoleBudgetService : BaseService, IRoleBudgetService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public RoleBudgetService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public RoleBudgetExtendDto? GetRoleBudgetByIdRoleBudget(RoleBudgetDto roleBudget)
        {
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();
            RoleBudgetExtendDto? roleBudgetSearch = roleBudgetRepository.GetRoleBudgetByIdRoleBudget(roleBudget);

            _logApiService.TraceLog(typeof(RoleBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (roleBudgetSearch != null)
            {
                return roleBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public RoleBudgetExtendDto? GetRoleBudgetByNameRole(RoleBudgetDto roleBudget)
        {
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();
            RoleBudgetExtendDto? roleBudgetSearch = roleBudgetRepository.GetRoleBudgetByNameRole(roleBudget);

            _logApiService.TraceLog(typeof(RoleBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (roleBudgetSearch != null)
            {
                return roleBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<RoleBudgetExtendDto> GetRolesBudgetByStatusBudget(RoleBudgetDto roleBudget)
        {
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();
            List<RoleBudgetExtendDto> roleBudgetSearch = roleBudgetRepository.GetRolesBudgetByStatusBudget(roleBudget);

            _logApiService.TraceLog(typeof(RoleBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (roleBudgetSearch.Count != 0)
            {
                return roleBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public RoleBudgetDto SaveRoleBudget(RoleBudgetDto roleBudget)
        {
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (roleBudget == null || string.IsNullOrWhiteSpace(roleBudget.NameRole.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleBudgetExtendDto? roleBudgetSearch = roleBudgetRepository.GetRoleBudgetByNameRole(roleBudget);

            if (roleBudgetSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = roleBudget.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            RoleBudget saveRoleBudget = new()
            {
                NameRole = roleBudget.NameRole.Trim(),
                DescriptionRole = roleBudget.DescriptionRole?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget                
            };

            UnitOfWork.BaseRepository<RoleBudget>().Add(saveRoleBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(RoleBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveRoleBudget), DateTime.Now, null);

            return roleBudget;
        }

        public RoleBudgetDto UpdateRoleBudget(RoleBudgetDto roleBudget)
        {
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();

            if (roleBudget == null || roleBudget.IdRoleBudget <= 0 || string.IsNullOrWhiteSpace(roleBudget.NameRole.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleBudgetExtendDto? roleBudgetDuplicado = roleBudgetRepository.GetRoleBudgetByNameRole(roleBudget);
            RoleBudgetExtendDto? roleBudgetSearch = roleBudgetRepository.GetRoleBudgetByIdRoleBudget(roleBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (roleBudgetDuplicado != null && roleBudgetDuplicado.IdRoleBudget != roleBudgetSearch.IdRoleBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleBudget updateRoleBudget = new()
            {
                IdRoleBudget = roleBudgetSearch.IdRoleBudget,
                NameRole = roleBudget.NameRole.Trim(),
                DescriptionRole = roleBudget.DescriptionRole?.Trim() ?? string.Empty,
                IdStatusBudget = roleBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<RoleBudget>().Update(updateRoleBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(RoleBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(roleBudgetSearch), JsonSerializer.Serialize(updateRoleBudget), DateTime.Now, null);

            return roleBudget;
        }

        public RoleBudgetDto DeleteRoleBudget(RoleBudgetDto roleBudget)
        {
            IRoleBudgetRepository roleBudgetRepository = UnitOfWork.RoleBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            RoleBudgetExtendDto? roleBudgetSearch = roleBudgetRepository.GetRoleBudgetByIdRoleBudget(roleBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = roleBudget.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (roleBudgetSearch.IdStatusBudget == roleBudget.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleBudget deleteRoleBudget = new()
            {
                IdRoleBudget = roleBudgetSearch.IdRoleBudget,
                NameRole = roleBudgetSearch.NameRole.Trim(),
                DescriptionRole = roleBudgetSearch.DescriptionRole?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<RoleBudget>().Update(deleteRoleBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            _logApiService.TraceLog(typeof(RoleBudget).Name, Constants.Method.POST, JsonSerializer.Serialize(roleBudgetSearch), JsonSerializer.Serialize(deleteRoleBudget), DateTime.Now, null);

            return roleBudget;
        }

        #endregion

    }
}