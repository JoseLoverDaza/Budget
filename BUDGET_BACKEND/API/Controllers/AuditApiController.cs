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
    /// Nombre: AuditApiController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AuditApiController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IAuditApiService _auditApiService;

        #endregion

        #region Constructor

        public AuditApiController(IAuditApiService auditApiService)
        {
            _auditApiService = auditApiService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetAuditApiByIdAuditApi")]
        [SwaggerOperation(Summary = "Get AuditApi By IdAuditApi")]
        public ResponseDto GetAuditApiByIdAuditApi(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.GetAuditApiByIdAuditApi(auditApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditApisByCreationDate")]
        [SwaggerOperation(Summary = "Get AuditApis By CreationDate")]
        public ResponseDto GetAuditApisByCreationDate(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.GetAuditApisByCreationDate(auditApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditApisByMethodCreationDate")]
        [SwaggerOperation(Summary = "Get AuditApis By Method CreationDate")]
        public ResponseDto GetAuditApisByMethodCreationDate(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.GetAuditApisByMethodCreationDate(auditApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditApisByEndpointUrlCreationDate")]
        [SwaggerOperation(Summary = "Get AuditApis By EndpointUrl CreationDate")]
        public ResponseDto GetAuditApisByEndpointUrlCreationDate(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.GetAuditApisByEndpointUrlCreationDate(auditApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditApisByEndpointUrlMethodCreationDate")]
        [SwaggerOperation(Summary = "Get AuditApis By EndpointUrl Method CreationDate")]
        public ResponseDto GetAuditApisByEndpointUrlMethodCreationDate(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.GetAuditApisByEndpointUrlMethodCreationDate(auditApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveAuditApi")]
        [SwaggerOperation(Summary = "Save AuditApi")]
        public ResponseDto SaveAuditApi(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.SaveAuditApi(auditApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateAuditApi")]
        [SwaggerOperation(Summary = "Update AuditApi")]
        public ResponseDto UpdateAuditApi(AuditApiDto auditApi)
        {
            try
            {
                response.Data = _auditApiService.UpdateAuditApi(auditApi);
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