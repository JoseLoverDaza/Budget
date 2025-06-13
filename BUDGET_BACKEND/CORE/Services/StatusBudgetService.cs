namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusBudgetService : BaseService, IStatusBudgetService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public StatusBudgetService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public StatusBudgetDto? GetStatusBudgetByIdStatusBudget(StatusBudgetDto statusBudget)
        {
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(statusBudget);

            _logApiService.TraceLog(typeof(StatusBudget).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(statusBudget), DateTime.Now, null);

            if (statusBudgetSearch != null)
            {
                return statusBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public StatusBudgetDto? GetStatusBudgetByNameStatus(StatusBudgetDto statusBudget)
        {
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByNameStatus(statusBudget);

            _logApiService.TraceLog(typeof(StatusBudget).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(statusBudget), DateTime.Now, null);

            if (statusBudgetSearch != null)
            {
                return statusBudgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<StatusBudgetDto> GetStatusBudget()
        {
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();
            List<StatusBudgetDto> statusBudget = statusBudgetRepository.GetStatusBudget();

            _logApiService.TraceLog(typeof(StatusBudget).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(statusBudget), DateTime.Now, null);

            if (statusBudget.Count != 0)
            {
                return statusBudget;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public StatusBudgetDto SaveStatusBudget(StatusBudgetDto statusBudget)
        {
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (statusBudget == null || string.IsNullOrWhiteSpace(statusBudget.NameStatus.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByNameStatus(statusBudget);

            if (statusBudgetSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusBudget saveStatusBudget = new()
            {
                NameStatus = statusBudget.NameStatus.Trim(),
                DescriptionStatus = statusBudget.DescriptionStatus?.Trim() ?? string.Empty
            };

            UnitOfWork.BaseRepository<StatusBudget>().Add(saveStatusBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(StatusBudget).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveStatusBudget), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return statusBudget;
        }

        public StatusBudgetDto UpdateStatusBudget(StatusBudgetDto statusBudget)
        {
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (statusBudget == null || statusBudget.IdStatusBudget <= 0 || string.IsNullOrWhiteSpace(statusBudget.NameStatus.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusBudgetDto? statusBudgetDuplicado = statusBudgetRepository.GetStatusBudgetByNameStatus(statusBudget);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(statusBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusBudgetDuplicado != null && statusBudgetDuplicado.IdStatusBudget != statusBudgetSearch.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusBudget updateStatusBudget = new()
            {
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                NameStatus = statusBudget.NameStatus.Trim(),
                DescriptionStatus = statusBudget.DescriptionStatus?.Trim() ?? string.Empty
            };

            UnitOfWork.BaseRepository<StatusBudget>().Update(updateStatusBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(StatusBudget).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(statusBudgetSearch), JsonSerializer.Serialize(updateStatusBudget), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return statusBudget;
        }

        #endregion

    }
}