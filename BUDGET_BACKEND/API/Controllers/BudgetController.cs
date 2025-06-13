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
    /// Nombre: BudgetController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
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
        [Route("GetBudgetByIdBudget")]
        [SwaggerOperation(Summary = "Get Budget By IdBudget")]
        public ResponseDto GetBudgetByIdBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetByIdBudget(budget);
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
        [Route("GetBudgetsByYearUserBudget")]
        [SwaggerOperation(Summary = "Get Budgets By Year UserBudget")]
        public ResponseDto GetBudgetsByYearUserBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByYearUserBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByMonthUserBudget")]
        [SwaggerOperation(Summary = "Get Budgets By Month UserBudget")]
        public ResponseDto GetBudgetsByMonthUserBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByMonthUserBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByYearMonthUserBudget")]
        [SwaggerOperation(Summary = "Get Budgets By Year Month UserBudget")]
        public ResponseDto GetBudgetsByYearMonthUserBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByYearMonthUserBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByUserBudget")]
        [SwaggerOperation(Summary = "Get Budgets By UserBudget")]
        public ResponseDto GetBudgetsByUserBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByUserBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByStatusBudget")]
        [SwaggerOperation(Summary = "Get Budgets By StatusBudget")]
        public ResponseDto GetBudgetsByStatusBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByStatusBudget(budget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetBudgetsByUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get Budgets By User Budget StatusBudget")]
        public ResponseDto GetBudgetsByUserBudgetStatusBudget(BudgetDto budget)
        {
            try
            {
                response.Data = _budgetService.GetBudgetsByUserBudgetStatusBudget(budget);
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