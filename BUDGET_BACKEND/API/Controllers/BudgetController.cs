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
    /// Nombre: BudgetController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IBudgetService _budgetService;

        #endregion

        #region Constructor

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetBudgetById")]
        [SwaggerOperation(Summary = "Get Budget By Id")]
        public ResponseDto GetBudgetById(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetById(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByYearMonth")]
        [SwaggerOperation(Summary = "Get Budgets By Year Month")]
        public ResponseDto GetBudgetsByYearMonth(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByYearMonth(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByYearUser")]
        [SwaggerOperation(Summary = "GetBudgetsByYearUser")]
        public ResponseDto GetBudgetsByYearUser(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByYearUser(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByMonthUser")]
        [SwaggerOperation(Summary = "Get Budgets By Month User")]
        public ResponseDto GetBudgetsByMonthUser(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByMonthUser(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByYearMonthUser")]
        [SwaggerOperation(Summary = "Get Budgets By Year Month User")]
        public ResponseDto GetBudgetsByYearMonthUser(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByYearMonthUser(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByUser")]
        [SwaggerOperation(Summary = "Get Budgets By User")]
        public ResponseDto GetBudgetsByUser(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByUser(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByStatus")]
        [SwaggerOperation(Summary = "Get Budgets By Status")]
        public ResponseDto GetBudgetsByStatus(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByStatus(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByUserStatus")]
        [SwaggerOperation(Summary = "Get Budgets By User Status")]
        public ResponseDto GetBudgetsByUserStatus(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByUserStatus(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveBudget")]
        [SwaggerOperation(Summary = "Save Budget")]
        public ResponseDto SaveBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.SaveBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateBudget")]
        [SwaggerOperation(Summary = "Update Budget")]
        public ResponseDto UpdateBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.UpdateBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteBudget")]
        [SwaggerOperation(Summary = "Delete Budget")]
        public ResponseDto DeleteBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.DeleteBudget(budget);
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