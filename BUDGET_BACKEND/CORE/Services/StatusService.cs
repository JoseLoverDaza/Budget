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
    using System.Text.RegularExpressions;
   
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusService : BaseService, IStatusService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public StatusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public StatusDto? GetStatusById(int idStatus)
        {
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            StatusDto? status = statusRepository.GetStatusById(idStatus);

            if (status != null)
            {
                return status;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public StatusDto? GetStatusByName(string name)
        {
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            StatusDto? status = statusRepository.GetStatusByName(name);

            if (status != null)
            {
                return status;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<StatusDto> GetStatus()
        {
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            List<StatusDto> status = statusRepository.GetStatus();

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
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (status == null || string.IsNullOrWhiteSpace(status.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(status.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusByName(status.Name.Trim());

            if (statusSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Status saveStatus = new()
            {
                Name = status.Name.Trim(),
                Description = status.Description!.Trim()
            };

            UnitOfWork.BaseRepository<Status>().Add(saveStatus);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }             
            return status;
        }

        public StatusDto UpdateStatus(StatusDto status)
        {
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (status == null || status.IdStatus <= 0 || string.IsNullOrWhiteSpace(status.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(status.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusDuplicado = statusRepository.GetStatusByName(status.Name);
            StatusDto? statusSearch = statusRepository.GetStatusById(status.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusDuplicado != null && statusDuplicado.IdStatus != status.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Status updateStatus = new()
            {
                IdStatus = statusSearch.IdStatus,
                Name = status.Name.Trim(),
                Description = status.Description!.Trim()
            };

            UnitOfWork.BaseRepository<Status>().Update(updateStatus);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return status;
        }

        #endregion

    }
}