namespace API.Controllers
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
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

        [HttpGet]
        [Route("GetFinancialInstitutionById")]
        [SwaggerOperation(Summary = "Get Financial Institution By Id")]
        public ResponseDto GetFinancialInstitutionById(int id)
        {
            try
            {
                response.Data = _financialInstitutionService.GetFinancialInstitutionById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetFinancialInstitutionByName")]
        [SwaggerOperation(Summary = "Get Financial Institution By Name")]
        public ResponseDto GetFinancialInstitutionByName(string name)
        {
            try
            {
                response.Data = _financialInstitutionService.GetFinancialInstitutionByName(name);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetFinancialInstitutionsByStatus")]
        [SwaggerOperation(Summary = "Get Financial Institutions By Status")]
        public ResponseDto GetFinancialInstitutionsByStatus(int idStatus)
        {
            try
            {
                response.Data = _financialInstitutionService.GetFinancialInstitutionsByStatus(idStatus);
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
        public ResponseDto SaveFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
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
        public ResponseDto UpdateFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
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
        public ResponseDto DeleteFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
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
