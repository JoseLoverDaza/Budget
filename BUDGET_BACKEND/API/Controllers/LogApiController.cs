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
        [Route("GetLogApiByIdLogApi")]
        [SwaggerOperation(Summary = "Get LogApi By IdLogApi")]
        public ResponseDto GetLogApiByIdLogApi(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApiByIdLogApi(logApi);
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
        [Route("GetLogApisByStatusBudget")]
        [SwaggerOperation(Summary = "Get LogApis By StatusBudget")]
        public ResponseDto GetLogApisByStatusBudget(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByStatusBudget(logApi);
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
        [Route("GetLogApisByCreationDateStatusBudget")]
        [SwaggerOperation(Summary = "Get LogApis By CreationDate StatusBudget")]
        public ResponseDto GetLogApisByCreationDateStatusBudget(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByCreationDateStatusBudget(logApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogApisByEntityCreationDateStatusBudget")]
        [SwaggerOperation(Summary = "Get LogApis By Entity CreationDate StatusBudget")]
        public ResponseDto GetLogApisByEntityCreationDateStatusBudget(LogApiDto logApi)
        {
            try
            {
                response.Data = _logApiService.GetLogApisByEntityCreationDateStatusBudget(logApi);
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