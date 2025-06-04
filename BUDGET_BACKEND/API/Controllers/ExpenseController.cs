namespace API.Controllers
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
    using Domain.Dto.Common;
    using Domain.Entities;
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

        [HttpGet]
        [Route("GetExpenseById")]
        [SwaggerOperation(Summary = "Get Expense By Id")]
        public ResponseDto GetExpenseById(int id)
        {
            try
            {
                response.Data = _expenseService.GetExpenseById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetExpenseByName")]
        [SwaggerOperation(Summary = "Get Expense By Name")]
        public ResponseDto GetExpenseByName(string name)
        {
            try
            {
                response.Data = _expenseService.GetExpenseByName(name);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetExpensesByTypeExpense")]
        [SwaggerOperation(Summary = "Get Expenses By Type Expense")]
        public ResponseDto GetExpensesByTypeExpense(int idTypeExpense)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByTypeExpense(idTypeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetExpensesByStatus")]
        [SwaggerOperation(Summary = "Get Expenses By Status")]
        public ResponseDto GetExpensesByStatus(int idStatus)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByStatus(idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetExpensesByTypeExpenseStatus")]
        [SwaggerOperation(Summary = "Get Expenses By Type Expense Status")]
        public ResponseDto GetExpensesByTypeExpenseStatus(int idTypeExpense, int idStatus)
        {
            try
            {
                response.Data = _expenseService.GetExpensesByTypeExpenseStatus(idTypeExpense, idStatus);
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
        public ResponseDto SaveExpense(ExpenseExtendDto expense)
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
        public ResponseDto UpdateExpense(ExpenseExtendDto expense)
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
        public ResponseDto DeleteExpense(ExpenseExtendDto expense)
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