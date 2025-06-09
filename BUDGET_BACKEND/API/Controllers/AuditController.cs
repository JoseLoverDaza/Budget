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
        [Route("SaveAudit")]
        [SwaggerOperation(Summary = "Save Audit")]
        public ResponseDto SaveAudit(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.SaveAudit(audit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateAudit")]
        [SwaggerOperation(Summary = "Update Audit")]
        public ResponseDto UpdateAudit(AuditDto audit)
        {
            try
            {
                response.Data = _auditService.UpdateAudit(audit);
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