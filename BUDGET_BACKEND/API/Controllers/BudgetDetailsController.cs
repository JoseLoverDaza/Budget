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
    /// Nombre: BudgetDetailsController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
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
        [Route("GetBudgetDetailsByIdBudgetDetails")]
        [SwaggerOperation(Summary = "Get BudgetDetails By IdBudgetDetails")]
        public ResponseDto GetBudgetDetailsByIdBudgetDetails(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByIdBudgetDetails(budgetDetails);
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
        [Route("GetBudgetDetailsByStatusBudget")]
        [SwaggerOperation(Summary = "Get BudgetDetails By StatusBudget")]
        public ResponseDto GetBudgetDetailsByStatusBudget(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByStatusBudget(budgetDetails);
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
        [Route("GetBudgetDetailsByBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get Budget Details By Budget StatusBudget")]
        public ResponseDto GetBudgetDetailsByBudgetStatusBudget(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByBudgetStatusBudget(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByExpenseStatusBudget")]
        [SwaggerOperation(Summary = "Get BudgetDetails By Expense StatusBudget")]
        public ResponseDto GetBudgetDetailsByExpenseStatusBudget(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByExpenseStatusBudget(budgetDetails);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetDetailsByBudgetExpenseStatusBudget")]
        [SwaggerOperation(Summary = "Get BudgetDetails By Budget Expense StatusBudget")]
        public ResponseDto GetBudgetDetailsByBudgetExpenseStatusBudget(BudgetDetailsDto budgetDetails)
        {
            try
            {
                response.Data = _budgetDetailsService.GetBudgetDetailsByBudgetExpenseStatusBudget(budgetDetails);
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
