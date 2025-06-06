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
    /// Nombre: FinancialInstitutionService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitutionService : BaseService, IFinancialInstitutionService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public FinancialInstitutionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {           
        }

        #endregion

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(financialInstitution);

            if (financialInstitutionSearch != null)
            {
                return financialInstitutionSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByName(financialInstitution);

            if (financialInstitutionSearch != null)
            {
                return financialInstitutionSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            List<FinancialInstitutionExtendDto> financialInstitutionsSearch = financialInstitutionRepository.GetFinancialInstitutionsByStatus(financialInstitution);

            if (financialInstitutionsSearch.Count != 0)
            {
                return financialInstitutionsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public FinancialInstitutionDto SaveFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (financialInstitution == null || string.IsNullOrWhiteSpace(financialInstitution.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByName(financialInstitution);

            if (financialInstitutionSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = financialInstitution.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            FinancialInstitution saveFinancialInstitution = new()
            {
                Name = financialInstitution.Name.Trim(),
                Description = financialInstitution.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Add(saveFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return financialInstitution;
        }

        public FinancialInstitutionDto UpdateFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();

            if (financialInstitution == null || financialInstitution.IdFinancialInstitution <= 0 || string.IsNullOrWhiteSpace(financialInstitution.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionDuplicado = financialInstitutionRepository.GetFinancialInstitutionByName(financialInstitution);
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(financialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (financialInstitutionDuplicado != null && financialInstitutionDuplicado.IdFinancialInstitution != financialInstitution.IdFinancialInstitution)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitution updateFinancialInstitution = new()
            {
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                Name = financialInstitution.Name.Trim(),
                Description = financialInstitution.Description?.Trim() ?? string.Empty,
                IdStatus = financialInstitutionSearch.IdStatus
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Update(updateFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return financialInstitution;
        }

        public FinancialInstitutionDto DeleteFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(financialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = financialInstitution.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (financialInstitutionSearch.IdStatus == statusSearch.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitution deleteFinancialInstitution = new()
            {
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                Name = financialInstitutionSearch.Name.Trim(),
                Description = financialInstitutionSearch.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Update(deleteFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return financialInstitution;
        }

        #endregion

    }
}