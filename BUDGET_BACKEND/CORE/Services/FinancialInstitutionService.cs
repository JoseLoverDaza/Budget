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
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

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

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(int idFinancialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitution = financialInstitutionRepository.GetFinancialInstitutionById(idFinancialInstitution);

            if (financialInstitution != null)
            {
                return financialInstitution;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(string name)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitution = financialInstitutionRepository.GetFinancialInstitutionByName(name);

            if (financialInstitution != null)
            {
                return financialInstitution;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(int idStatus)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            List<FinancialInstitutionExtendDto> financialInstitutions = financialInstitutionRepository.GetFinancialInstitutionsByStatus(idStatus);

            if (financialInstitutions.Count != 0)
            {
                return financialInstitutions;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public FinancialInstitutionExtendDto SaveFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (financialInstitution == null || string.IsNullOrWhiteSpace(financialInstitution.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(financialInstitution.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByName(financialInstitution.Name.Trim());

            if (financialInstitutionSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(financialInstitution.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            FinancialInstitution saveFinancialInstitution = new()
            {
                Name = financialInstitution.Name.Trim(),
                Description = financialInstitution.Description!.Trim(),
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Add(saveFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return financialInstitution;
        }

        public FinancialInstitutionExtendDto UpdateFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();

            if (financialInstitution == null || financialInstitution.IdFinancialInstitution <= 0 || string.IsNullOrWhiteSpace(financialInstitution.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(financialInstitution.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionDuplicado = financialInstitutionRepository.GetFinancialInstitutionByName(financialInstitution.Name);
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(financialInstitution.IdFinancialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (financialInstitutionDuplicado != null && financialInstitutionDuplicado.IdFinancialInstitution != financialInstitution.IdFinancialInstitution)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitution updateFinancialInstitution = new()
            {
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                Name = financialInstitution.Name.Trim(),
                Description = financialInstitution.Description!.Trim(),
                IdStatus = financialInstitutionSearch.IdStatus
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Update(updateFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return financialInstitution;
        }

        public FinancialInstitutionExtendDto DeleteFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionById(financialInstitution.IdFinancialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            FinancialInstitution deleteFinancialInstitution = new()
            {
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                Name = financialInstitutionSearch.Name.Trim(),
                Description = financialInstitutionSearch.Description!.Trim(),
                IdStatus = Constants.Status.INACTIVO
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