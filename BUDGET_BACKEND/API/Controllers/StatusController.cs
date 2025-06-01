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

        [HttpGet]
        [Route("GetStatusById")]
        [SwaggerOperation(Summary = "Get Status By Id")]
        public ResponseDto GetStatusById(int id)
        {
            try
            {
                response.Data = _statusService.GetStatusById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetStatusByName")]
        [SwaggerOperation(Summary = "Get Status By Name")]
        public ResponseDto GetStatusByName(string name)
        {
            try
            {
                response.Data = _statusService.GetStatusByName(name);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
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