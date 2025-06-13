namespace API.Controllers
{

    #region Librerias

    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Dto.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
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
        [Route("GetBillingByIdBilling")]
        [SwaggerOperation(Summary = "Get Billing By IdBilling")]
        public ResponseDto GetBillingByIdBilling(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingByIdBilling(billing);
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
        [Route("GetBillingsByYearUserBudget")]
        [SwaggerOperation(Summary = "Get Billings By Year UserBudget")]
        public ResponseDto GetBillingsByYearUserBudget(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByYearUserBudget(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByMonthUserBudget")]
        [SwaggerOperation(Summary = "Get Billings By Month UserBudget")]
        public ResponseDto GetBillingsByMonthUserBudget(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByMonthUserBudget(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByYearMonthUserBudget")]
        [SwaggerOperation(Summary = "Get Billings By Year Month UserBudget")]
        public ResponseDto GetBillingsByYearMonthUserBudget(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByYearMonthUserBudget(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByUserBudget")]
        [SwaggerOperation(Summary = "Get Billings By UserBudget")]
        public ResponseDto GetBillingsByUserBudget(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByUserBudget(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByStatusBudget")]
        [SwaggerOperation(Summary = "Get Billings By StatusBudget")]
        public ResponseDto GetBillingsByStatusBudget(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByStatusBudget(billing);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingsByUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get Billings By UserBudget StatusBudget")]
        public ResponseDto GetBillingsByUserBudgetStatusBudget(BillingDto billing)
        {
            try
            {
                response.Data = _billingService.GetBillingsByUserBudgetStatusBudget(billing);
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
        public ResponseDto SaveBilling(BillingDto billing)
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