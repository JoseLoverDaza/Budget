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
        [Route("GetBillingDetailsByIdBillingDetails")]
        [SwaggerOperation(Summary = "Get BillingDetails By IdBillingDetails")]
        public ResponseDto GetBillingDetailsByIdBillingDetails(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByIdBillingDetails(billingDetails);
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
        [Route("GetBillingDetailsByStatusBudget")]
        [SwaggerOperation(Summary = "Get BillingDetails By StatusBudget")]
        public ResponseDto GetBillingDetailsByStatusBudget(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByStatusBudget(billingDetails);
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
        [Route("GetBillingDetailsByExpenseStatusBudget")]
        [SwaggerOperation(Summary = "Get BillingDetails By Expense StatusBudget")]
        public ResponseDto GetBillingDetailsByExpenseStatusBudget(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByExpenseStatusBudget(billingDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBillingDetailsByBillingExpenseStatusBudget")]
        [SwaggerOperation(Summary = "Get BillingDetails By Billing Expense StatusBudget")]
        public ResponseDto GetBillingDetailsByBillingExpenseStatusBudget(BillingDetailsDto billingDetails)
        {
            try
            {
                response.Data = _billingDetailsService.GetBillingDetailsByBillingExpenseStatusBudget(billingDetails);
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