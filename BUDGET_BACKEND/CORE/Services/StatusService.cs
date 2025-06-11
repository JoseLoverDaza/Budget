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
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusService : BaseService, IStatusBudgetService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public StatusService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public StatusDto? GetStatusById(StatusDto status)
        {
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();
            StatusDto? statusSearch = statusRepository.GetStatusById(status);

            _logApiService.TraceLog(typeof(Status).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (statusSearch != null)
            {
                return statusSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public StatusDto? GetStatusByName(StatusDto status)
        {
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();
            StatusDto? statusSearch = statusRepository.GetStatusByName(status);

            _logApiService.TraceLog(typeof(Status).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (statusSearch != null)
            {
                return statusSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<StatusDto> GetStatus()
        {
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();
            List<StatusDto> status = statusRepository.GetStatus();

            _logApiService.TraceLog(typeof(Status).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (status.Count != 0)
            {
                return status;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public StatusDto SaveStatus(StatusDto status)
        {
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            if (status == null || string.IsNullOrWhiteSpace(status.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusByName(status);

            if (statusSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Status saveStatus = new()
            {
                Name = status.Name.Trim(),
                Description = status.Description?.Trim() ?? string.Empty
            };

            UnitOfWork.BaseRepository<Status>().Add(saveStatus);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Status).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveStatus), DateTime.Now, null);

            return status;
        }

        public StatusDto UpdateStatus(StatusDto status)
        {
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            if (status == null || status.IdStatus <= 0 || string.IsNullOrWhiteSpace(status.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusDuplicado = statusRepository.GetStatusByName(status);
            StatusDto? statusSearch = statusRepository.GetStatusById(status) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusDuplicado != null && statusDuplicado.IdStatus != statusSearch.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Status updateStatus = new()
            {
                IdStatus = statusSearch.IdStatus,
                Name = status.Name.Trim(),
                Description = status.Description?.Trim() ?? string.Empty
            };

            UnitOfWork.BaseRepository<Status>().Update(updateStatus);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            _logApiService.TraceLog(typeof(Status).Name, Constants.Method.POST, JsonSerializer.Serialize(statusSearch), JsonSerializer.Serialize(updateStatus), DateTime.Now, null);

            return status;
        }

        #endregion

    }
}