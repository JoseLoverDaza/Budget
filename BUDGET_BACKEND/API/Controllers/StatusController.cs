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
    /// Nombre: StatusController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IStatusService _statusService;

        #endregion

        #region Constructor

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetStatusById")]
        [SwaggerOperation(Summary = "Get Status By Id")]
        public ResponseDto GetStatusById(StatusDto status)
        {
            try
            {                
                response.Data = _statusService.GetStatusById(status);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetStatusByName")]
        [SwaggerOperation(Summary = "Get Status By Name")]
        public ResponseDto GetStatusByName(StatusDto status)
        {
            try
            {
                response.Data = _statusService.GetStatusByName(status);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetStatus")]
        [SwaggerOperation(Summary = "Get Status")]
        public ResponseDto GetStatus()
        {
            try
            {
                response.Data = _statusService.GetStatus();
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveStatus")]
        [SwaggerOperation(Summary = "Save Status")]
        public ResponseDto SaveStatus(StatusDto status)
        {
            try
            {
                response.Data = _statusService.SaveStatus(status);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateStatus")]
        [SwaggerOperation(Summary = "Update Status")]
        public ResponseDto UpdateStatus(StatusDto status)
        {
            try
            {
                response.Data = _statusService.UpdateStatus(status);
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