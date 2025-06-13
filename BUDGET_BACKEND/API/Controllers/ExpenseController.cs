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
    /// Nombre: ExpenseController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IExpenseService _expenseService;

        #endregion

        #region Constructor

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetExpenseByIdExpense")]
        [SwaggerOperation(Summary = "Get Expense By IdExpense")]
        public ResponseDto GetExpenseByIdExpense(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpenseByIdExpense(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetExpensesByTypeExpense")]
        [SwaggerOperation(Summary = "Get Expenses By Type Expense")]
        public ResponseDto GetExpensesByTypeExpense(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByTypeExpense(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetExpensesByStatusBudget")]
        [SwaggerOperation(Summary = "Get Expenses By StatusBudget")]
        public ResponseDto GetExpensesByStatusBudget(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByStatusBudget(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetExpensesByNameTypeExpense")]
        [SwaggerOperation(Summary = "Get Expenses By Name Type Expense")]
        public ResponseDto GetExpensesByNameTypeExpense(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByNameTypeExpense(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetExpensesByTypeExpenseStatusBudget")]
        [SwaggerOperation(Summary = "Get Expenses By TypeExpense StatusBudget")]
        public ResponseDto GetExpensesByTypeExpenseStatusBudget(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByTypeExpenseStatusBudget(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveExpense")]
        [SwaggerOperation(Summary = "Save Expense")]
        public ResponseDto SaveExpense(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.SaveExpense(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateExpense")]
        [SwaggerOperation(Summary = "Update Expense")]
        public ResponseDto UpdateExpense(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.UpdateExpense(expense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteExpense")]
        [SwaggerOperation(Summary = "Delete Expense")]
        public ResponseDto DeleteExpense(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.DeleteExpense(expense);
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