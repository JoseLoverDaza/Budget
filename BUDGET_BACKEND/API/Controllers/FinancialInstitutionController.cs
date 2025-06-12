namespace API.Controllers
{

    #region Librerias

    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Dto.Common;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class FinancialInstitutionController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IFinancialInstitutionService _financialInstitutionService;

        #endregion

        #region Constructor

        public FinancialInstitutionController(IFinancialInstitutionService financialInstitutionService)
        {
            _financialInstitutionService = financialInstitutionService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetFinancialInstitutionByIdFinancialInstitution")]
        [SwaggerOperation(Summary = "Get FinancialInstitution By IdFinancialInstitution")]
        public ResponseDto GetFinancialInstitutionByIdFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            try
            {
                response.Data = _financialInstitutionService.GetFinancialInstitutionByIdFinancialInstitution(financialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetFinancialInstitutionByNameFinancialInstitution")]
        [SwaggerOperation(Summary = "Get FinancialInstitution By NameFinancialInstitution")]
        public ResponseDto GetFinancialInstitutionByNameFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            try
            {
                response.Data = _financialInstitutionService.GetFinancialInstitutionByNameFinancialInstitution(financialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetFinancialInstitutionsByStatusBudget")]
        [SwaggerOperation(Summary = "Get FinancialInstitutions By StatusBudget")]
        public ResponseDto GetFinancialInstitutionsByStatusBudget(FinancialInstitutionDto financialInstitution)
        {
            try
            {
                response.Data = _financialInstitutionService.GetFinancialInstitutionsByStatusBudget(financialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveFinancialInstitution")]
        [SwaggerOperation(Summary = "Save Financial Institution")]
        public ResponseDto SaveFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            try
            {
                response.Data = _financialInstitutionService.SaveFinancialInstitution(financialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateFinancialInstitution")]
        [SwaggerOperation(Summary = "Update Financial Institution")]
        public ResponseDto UpdateFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            try
            {
                response.Data = _financialInstitutionService.UpdateFinancialInstitution(financialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteFinancialInstitution")]
        [SwaggerOperation(Summary = "Delete Financial Institution")]
        public ResponseDto DeleteFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            try
            {
                response.Data = _financialInstitutionService.DeleteFinancialInstitution(financialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        #endregion

    }
}