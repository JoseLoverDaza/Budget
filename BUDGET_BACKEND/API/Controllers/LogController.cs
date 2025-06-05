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
    /// Nombre: LogController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class LogController : BaseController
    {

        #region Atributos y Propiedades

        private readonly ILogService _logService;

        #endregion

        #region Constructor

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetLogById")]
        [SwaggerOperation(Summary = "Get Log By Id")]
        public ResponseDto GetLogById(LogDto log)
        {
            try
            {
                response.Data = _logService.GetLogById(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogsByCreationDate")]
        [SwaggerOperation(Summary = "Get Logs By Creation Date")]
        public ResponseDto GetLogsByCreationDate(LogDto log)
        {
            try
            {
                response.Data = _logService.GetLogsByCreationDate(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogsByStatus")]
        [SwaggerOperation(Summary = "Get Logs By Status")]
        public ResponseDto GetLogsByStatus(LogDto log)
        {
            try
            {
                response.Data = _logService.GetLogsByStatus(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogsByEntityCreationDate")]
        [SwaggerOperation(Summary = "Get Logs By Entity Creation Date")]
        public ResponseDto GetLogsByEntityCreationDate(LogDto log)
        {
            try
            {
                response.Data = _logService.GetLogsByEntityCreationDate(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogsByCreationDateStatus")]
        [SwaggerOperation(Summary = "Get Logs By Creation Date Status")]
        public ResponseDto GetLogsByCreationDateStatus(LogDto log)
        {
            try
            {
                response.Data = _logService.GetLogsByCreationDateStatus(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetLogsByEntityCreationDateStatus")]
        [SwaggerOperation(Summary = "Get Logs By Entity Creation Date Status")]
        public ResponseDto GetLogsByEntityCreationDateStatus(LogDto log)
        {
            try
            {
                response.Data = _logService.GetLogsByEntityCreationDateStatus(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveLog")]
        [SwaggerOperation(Summary = "Save Log")]
        public ResponseDto SaveLog(LogDto log)
        {
            try
            {
                response.Data = _logService.SaveLog(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateLog")]
        [SwaggerOperation(Summary = "Update Log")]
        public ResponseDto UpdateLog(LogDto log)
        {
            try
            {
                response.Data = _logService.UpdateLog(log);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteLog")]
        [SwaggerOperation(Summary = "Delete Log")]
        public ResponseDto DeleteLog(LogDto log)
        {
            try
            {
                response.Data = _logService.DeleteLog(log);
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