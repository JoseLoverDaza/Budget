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
    /// Nombre: BillingController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IBillingService _billingService;

        #endregion

        #region Constructor

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetBillingById")]
        [SwaggerOperation(Summary = "Get Billing By Id")]
        public ResponseDto GetBillingById(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingById(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByYearMonth")]
        [SwaggerOperation(Summary = "Get Billings By Year Month")]
        public ResponseDto GetBillingsByYearMonth(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByYearMonth(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByYearUser")]
        [SwaggerOperation(Summary = "Get Billings By Year User")]
        public ResponseDto GetBillingsByYearUser(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByYearUser(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByMonthUser")]
        [SwaggerOperation(Summary = "Get Billings By Month User")]
        public ResponseDto GetBillingsByMonthUser(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByMonthUser(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByYearMonthUser")]
        [SwaggerOperation(Summary = "Get Billings By Year Month User")]
        public ResponseDto GetBillingsByYearMonthUser(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByYearMonthUser(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByUser")]
        [SwaggerOperation(Summary = "Get Billings By User")]
        public ResponseDto GetBillingsByUser(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByUser(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByStatus")]
        [SwaggerOperation(Summary = "Get Billings By Status")]
        public ResponseDto GetBillingsByStatus(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByStatus(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByUserStatus")]
        [SwaggerOperation(Summary = "Get Billings By User Status")]
        public ResponseDto GetBillingsByUserStatus(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByUserStatus(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveBilling")]
        [SwaggerOperation(Summary = "Save Billing")]
        public ResponseDto SaSaveBillingveAccount(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.SaveBilling(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateBilling")]
        [SwaggerOperation(Summary = "Update Billing")]
        public ResponseDto UpdateBilling(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.UpdateBilling(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteBilling")]
        [SwaggerOperation(Summary = "Delete Billing")]
        public ResponseDto DeleteBilling(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.DeleteBilling(billing);
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