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
    /// Nombre: ExpenseController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

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
        [Route("GetExpenseById")]
        [SwaggerOperation(Summary = "Get Expense By Id")]
        public ResponseDto GetExpenseById(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpenseById(expense);
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
        [Route("GetExpensesByStatus")]
        [SwaggerOperation(Summary = "Get Expenses By Status")]
        public ResponseDto GetExpensesByStatus(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByStatus(expense);
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
        [Route("GetExpensesByTypeExpenseStatus")]
        [SwaggerOperation(Summary = "Get Expenses By Type Expense Status")]
        public ResponseDto GetExpensesByTypeExpenseStatus(ExpenseDto expense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByTypeExpenseStatus(expense);
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