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
    /// Nombre: LogApiController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class LogApiController : BaseController
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public LogApiController(ILogApiService logApiService)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetLogApiById")]
        [SwaggerOperation(Summary = "Get Log Api By Id")]
        public ResponseDto GetLogApiById(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApiById(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogApisByCreationDate")]
        [SwaggerOperation(Summary = "Get Log Apis By Creation Date")]
        public ResponseDto GetLogApisByCreationDate(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByCreationDate(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogApisByStatus")]
        [SwaggerOperation(Summary = "Get Log Apis By Status")]
        public ResponseDto GetLogApisByStatus(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByStatus(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogApisByEntityCreationDate")]
        [SwaggerOperation(Summary = "Get Log Apis By Entity Creation Date")]
        public ResponseDto GetLogApisByEntityCreationDate(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByEntityCreationDate(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogApisByCreationDateStatus")]
        [SwaggerOperation(Summary = "Get Log Apis By Creation Date Status")]
        public ResponseDto GetLogApisByCreationDateStatus(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByCreationDateStatus(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogApisByEntityCreationDateStatus")]
        [SwaggerOperation(Summary = "Get Log Apis By Entity Creation Date Status")]
        public ResponseDto GetLogApisByEntityCreationDateStatus(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByEntityCreationDateStatus(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveLogApi")]
        [SwaggerOperation(Summary = "Save Log Api")]
        public ResponseDto SaveLogApi(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.SaveLogApi(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateLogApi")]
        [SwaggerOperation(Summary = "Update Log Api")]
        public ResponseDto UpdateLogApi(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.UpdateLogApi(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteLogApi")]
        [SwaggerOperation(Summary = "Delete Log Api")]
        public ResponseDto DeleteLogApi(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.DeleteLogApi(logApi);
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