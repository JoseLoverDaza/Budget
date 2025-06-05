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
    /// Nombre: BudgetDetailsController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class BudgetDetailsController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IBudgetDetailsService _budgetDetailsService;

        #endregion

        #region Constructor

        public BudgetDetailsController(IBudgetDetailsService budgetDetailsService)
        {
            _budgetDetailsService = budgetDetailsService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetBudgetDetailsById")]
        [SwaggerOperation(Summary = "Get Budget Details By Id")]
        public ResponseDto GetBudgetDetailsById(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsById(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByBudget")]
        [SwaggerOperation(Summary = "Get Budget Details By Budget")]
        public ResponseDto GetBudgetDetailsByBudget(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByBudget(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByExpense")]
        [SwaggerOperation(Summary = "Get Budget Details By Expense")]
        public ResponseDto GetBudgetDetailsByExpense(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByExpense(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByStatus")]
        [SwaggerOperation(Summary = "Get Budget Details By Status")]
        public ResponseDto GetBudgetDetailsByStatus(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByStatus(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByBudgetExpense")]
        [SwaggerOperation(Summary = "Get Budget Details By Budget Expense")]
        public ResponseDto GetBudgetDetailsByBudgetExpense(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByBudgetExpense(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByExpenseStatus")]
        [SwaggerOperation(Summary = "Get Budget Details By Expense Status")]
        public ResponseDto GetBudgetDetailsByExpenseStatus(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByExpenseStatus(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByBudgetExpenseStatus")]
        [SwaggerOperation(Summary = "Get Budget Details By Budget Expense Status")]
        public ResponseDto GetBudgetDetailsByBudgetExpenseStatus(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByBudgetExpenseStatus(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveBudgetDetail")]
        [SwaggerOperation(Summary = "Save Budget Detail")]
        public ResponseDto SaveBudgetDetail(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.SaveBudgetDetail(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateBudgetDetail")]
        [SwaggerOperation(Summary = "Update Budget Detail")]
        public ResponseDto UpdateBudgetDetail(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.UpdateBudgetDetail(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteBudgetDetail")]
        [SwaggerOperation(Summary = "Delete Budget Detail")]
        public ResponseDto DeleteBudgetDetail(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.DeleteBudgetDetail(budgetDetails);
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
