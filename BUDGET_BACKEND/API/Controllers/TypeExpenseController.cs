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
    /// Nombre: TypeExpenseController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeExpenseController : BaseController
    {

        #region Atributos y Propiedades

        private readonly ITypeExpenseService _typeExpenseService;

        #endregion

        #region Constructor

        public TypeExpenseController(ITypeExpenseService typeExpenseService)
        {
            _typeExpenseService = typeExpenseService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetTypeExpenseByIdTypeExpense")]
        [SwaggerOperation(Summary = "Get TypeExpense By IdTypeExpense")]
        public ResponseDto GetTypeExpenseByIdTypeExpense(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpenseByIdTypeExpense(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTypeExpenseByNameTypeExpense")]
        [SwaggerOperation(Summary = "Get TypeExpense By NameTypeExpense")]
        public ResponseDto GetTypeExpenseByNameTypeExpense(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpenseByNameTypeExpense(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTypeExpensesByStatusBudget")]
        [SwaggerOperation(Summary = "Get TypeExpenses By StatusBudget")]
        public ResponseDto GetTypeExpensesByStatusBudget(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpensesByStatusBudget(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveTypeExpense")]
        [SwaggerOperation(Summary = "Save Type Expense")]
        public ResponseDto SaveTypeExpense(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.SaveTypeExpense(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateTypeExpense")]
        [SwaggerOperation(Summary = "Update Type Expense")]
        public ResponseDto UpdateTypeExpense(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.UpdateTypeExpense(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteTypeExpense")]
        [SwaggerOperation(Summary = "Delete Type Expense")]
        public ResponseDto DeleteTypeExpense(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.DeleteTypeExpense(typeExpense);
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
