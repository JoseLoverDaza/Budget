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
    /// Nombre: BillingDetailsController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class BillingDetailsController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IBillingDetailsService _billingDetailsService;

        #endregion

        #region Constructor

        public BillingDetailsController(IBillingDetailsService billingDetailsService)
        {
            _billingDetailsService = billingDetailsService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetBillingDetailsById")]
        [SwaggerOperation(Summary = "Get Billing Details By Id")]
        public ResponseDto GetBillingDetailsById(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsById(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByBilling")]
        [SwaggerOperation(Summary = "Get Billing Details By Billing")]
        public ResponseDto GetBillingDetailsByBilling(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByBilling(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByExpense")]
        [SwaggerOperation(Summary = "Get Billing Details By Expense")]
        public ResponseDto GetBillingDetailsByExpense(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByExpense(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByStatus")]
        [SwaggerOperation(Summary = "Get Billing Details By Status")]
        public ResponseDto GetBillingDetailsByStatus(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByStatus(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByBillingExpense")]
        [SwaggerOperation(Summary = "Get Billing Details By Billing Expense")]
        public ResponseDto GetBillingDetailsByBillingExpense(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByBillingExpense(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByExpenseStatus")]
        [SwaggerOperation(Summary = "Get Billing Details By Expense Status")]
        public ResponseDto GetBillingDetailsByExpenseStatus(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByExpenseStatus(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByBillingExpenseStatus")]
        [SwaggerOperation(Summary = "Get Billing Details By Billing Expense Status")]
        public ResponseDto GetBillingDetailsByBillingExpenseStatus(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByBillingExpenseStatus(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveBillingDetail")]
        [SwaggerOperation(Summary = "Save Billing Detail")]
        public ResponseDto SaveBillingDetail(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.SaveBillingDetail(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateBillingDetail")]
        [SwaggerOperation(Summary = "Update Billing Detail")]
        public ResponseDto UpdateBillingDetail(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.UpdateBillingDetail(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteBillingDetail")]
        [SwaggerOperation(Summary = "Delete Billing Detail")]
        public ResponseDto DeleteBillingDetail(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.DeleteBillingDetail(billingDetails);
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