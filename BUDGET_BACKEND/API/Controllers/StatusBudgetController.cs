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
    /// Nombre: StatusBudgetController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class StatusBudgetController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IStatusBudgetService _statusBudgetService;

        #endregion

        #region Constructor

        public StatusBudgetController(IStatusBudgetService statusBudgetService)
        {
            _statusBudgetService = statusBudgetService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetStatusBudgetByIdStatusBudget")]
        [SwaggerOperation(Summary = "Get Status Budget By IdStatus Budget")]
        public ResponseDto GetStatusBudgetByIdStatusBudget(StatusBudgetDto statusBudget)
        {
            try
            {
                response.Data = _statusBudgetService.GetStatusBudgetByIdStatusBudget(statusBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetStatusBudgetByNameStatus")]
        [SwaggerOperation(Summary = "Get Status Budget By Name Status")]
        public ResponseDto GetStatusBudgetByNameStatus(StatusBudgetDto statusBudget)
        {
            try
            {
                response.Data = _statusBudgetService.GetStatusBudgetByNameStatus(statusBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetStatusBudget")]
        [SwaggerOperation(Summary = "Get StatusBudget")]
        public ResponseDto GetStatusBudget()
        {
            try
            {
                response.Data = _statusBudgetService.GetStatusBudget();
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveStatusBudget")]
        [SwaggerOperation(Summary = "Save Status Budget")]
        public ResponseDto SaveStatusBudget(StatusBudgetDto statusBudget)
        {
            try
            {
                response.Data = _statusBudgetService.SaveStatusBudget(statusBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateStatusBudget")]
        [SwaggerOperation(Summary = "Update StatusBudget")]
        public ResponseDto UpdateStatusBudget(StatusBudgetDto statusBudget)
        {
            try
            {
                response.Data = _statusBudgetService.UpdateStatusBudget(statusBudget);
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