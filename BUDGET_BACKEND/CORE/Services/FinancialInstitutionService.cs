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
    using System.Security.Principal;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitutionService : BaseService, IFinancialInstitutionService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public FinancialInstitutionService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByIdFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByIdFinancialInstitution(financialInstitution);

            _logApiService.TraceLog(typeof(FinancialInstitution).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(financialInstitution), DateTime.Now, null);

            if (financialInstitutionSearch != null)
            {
                return financialInstitutionSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByNameFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByNameFinancialInstitution(financialInstitution);

            _logApiService.TraceLog(typeof(FinancialInstitution).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(financialInstitution), DateTime.Now, null);

            if (financialInstitutionSearch != null)
            {
                return financialInstitutionSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatusBudget(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            List<FinancialInstitutionExtendDto> financialInstitutionsSearch = financialInstitutionRepository.GetFinancialInstitutionsByStatusBudget(financialInstitution);

            _logApiService.TraceLog(typeof(FinancialInstitution).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(financialInstitution), DateTime.Now, null);

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
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (financialInstitution == null || string.IsNullOrWhiteSpace(financialInstitution.NameFinancialInstitution.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByNameFinancialInstitution(financialInstitution);

            if (financialInstitutionSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = financialInstitution.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            FinancialInstitution saveFinancialInstitution = new()
            {
                NameFinancialInstitution = financialInstitution.NameFinancialInstitution.Trim(),
                DescriptionFinancialInstitution = financialInstitution.DescriptionFinancialInstitution?.Trim() ?? string.Empty,
                IdStatusBudget = statusSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = financialInstitution.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = financialInstitution.ModificationDate
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Add(saveFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(FinancialInstitution).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(financialInstitutionSearch), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return financialInstitution;
        }

        public FinancialInstitutionDto UpdateFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();

            if (financialInstitution == null || financialInstitution.IdFinancialInstitution <= 0 || string.IsNullOrWhiteSpace(financialInstitution.NameFinancialInstitution.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitutionExtendDto? financialInstitutionDuplicado = financialInstitutionRepository.GetFinancialInstitutionByNameFinancialInstitution(financialInstitution);
            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByIdFinancialInstitution(financialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (financialInstitutionDuplicado != null && financialInstitutionDuplicado.IdFinancialInstitution != financialInstitution.IdFinancialInstitution)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitution updateFinancialInstitution = new()
            {
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                NameFinancialInstitution = financialInstitution.NameFinancialInstitution.Trim(),
                DescriptionFinancialInstitution = financialInstitution.DescriptionFinancialInstitution?.Trim() ?? string.Empty,
                IdStatusBudget = financialInstitutionSearch.IdStatusBudget,
                CreationUser = financialInstitutionSearch.CreationUser,
                CreationDate = financialInstitutionSearch.CreationDate,
                ModificationUser = financialInstitutionSearch.ModificationUser,
                ModificationDate = financialInstitution.ModificationDate
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Update(updateFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(FinancialInstitution).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(financialInstitutionSearch), JsonSerializer.Serialize(updateFinancialInstitution), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return financialInstitution;
        }

        public FinancialInstitutionDto DeleteFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            IFinancialInstitutionRepository financialInstitutionRepository = UnitOfWork.FinancialInstitutionRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            FinancialInstitutionExtendDto? financialInstitutionSearch = financialInstitutionRepository.GetFinancialInstitutionByIdFinancialInstitution(financialInstitution) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = financialInstitution.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (financialInstitutionSearch.IdStatusBudget == statusBudgetSearch.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            FinancialInstitution deleteFinancialInstitution = new()
            {
                IdFinancialInstitution = financialInstitutionSearch.IdFinancialInstitution,
                NameFinancialInstitution = financialInstitutionSearch.NameFinancialInstitution.Trim(),
                DescriptionFinancialInstitution = financialInstitutionSearch.DescriptionFinancialInstitution?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = financialInstitutionSearch.CreationUser,
                CreationDate = financialInstitutionSearch.CreationDate,
                ModificationUser = financialInstitutionSearch.ModificationUser,
                ModificationDate = financialInstitution.ModificationDate
            };

            UnitOfWork.BaseRepository<FinancialInstitution>().Update(deleteFinancialInstitution);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(FinancialInstitution).Name, Constants.EntityAction.DELETE, JsonSerializer.Serialize(financialInstitutionSearch), JsonSerializer.Serialize(deleteFinancialInstitution), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return financialInstitution;
        }

        #endregion

    }
}