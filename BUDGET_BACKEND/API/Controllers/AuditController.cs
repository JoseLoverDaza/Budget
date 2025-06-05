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
    /// Nombre: AuditController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IAuditService _auditService;

        #endregion

        #region Constructor

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetAuditById")]
        [SwaggerOperation(Summary = "Get Audit By Id")]
        public ResponseDto GetAuditById(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditById(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditsByCreationDate")]
        [SwaggerOperation(Summary = "Get Audits By Creation Date")]
        public ResponseDto GetAuditsByCreationDate(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditsByCreationDate(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditsByStatus")]
        [SwaggerOperation(Summary = "Get Audits By Status")]
        public ResponseDto GetAuditsByStatus(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditsByStatus(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditsByMethodCreationDate")]
        [SwaggerOperation(Summary = "Get Audits By Method Creation Date")]
        public ResponseDto GetAuditsByMethodCreationDate(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditsByMethodCreationDate(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditsByEndpointCreationDate")]
        [SwaggerOperation(Summary = "Get Audits By Endpoint Creation Date")]
        public ResponseDto GetAuditsByEndpointCreationDate(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditsByEndpointCreationDate(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditsByEndpointMethodCreationDate")]
        [SwaggerOperation(Summary = "Get Audits By Endpoint Method Creation Date")]
        public ResponseDto GetAuditsByEndpointMethodCreationDate(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditsByEndpointMethodCreationDate(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAuditsByEndpointMethodCreationDateStatus")]
        [SwaggerOperation(Summary = "Get Audits By Endpoint Method Creation Date Status")]
        public ResponseDto GetAuditsByEndpointMethodCreationDateStatus(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.GetAuditsByEndpointMethodCreationDateStatus(audit);
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