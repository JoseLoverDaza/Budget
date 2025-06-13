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
    /// Nombre: DepositController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IDepositService _depositService;

        #endregion

        #region Constructor

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetDepositByIdDeposit")]
        [SwaggerOperation(Summary = "Get Deposit By IdDeposit")]
        public ResponseDto GetDepositByIdDeposit(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositByIdDeposit(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearMonth")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month")]
        public ResponseDto GetDepositsByYearMonth(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonth(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearUserBudget")]
        [SwaggerOperation(Summary = "Get Deposits By Year UserBudget")]
        public ResponseDto GetDepositsByYearUserBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearUserBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByMonthUserBudget")]
        [SwaggerOperation(Summary = "Get Deposits By Month UserBudget")]
        public ResponseDto GetDepositsByMonthUserBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByMonthUserBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearMonthUser")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month User")]
        public ResponseDto GetDepositsByYearMonthUserBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthUserBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearMonthAccount")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month Account")]
        public ResponseDto GetDepositsByYearMonthAccount(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthAccount(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearMonthStatusBudget")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month StatusBudget")]
        public ResponseDto GetDepositsByYearMonthStatusBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthStatusBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearMonthUserBudgetAccount")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month UserBudget Account")]
        public ResponseDto GetDepositsByYearMonthUserBudgetAccount(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthUserBudgetAccount(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByUserBudget")]
        [SwaggerOperation(Summary = "Get Deposits By UserBudget")]
        public ResponseDto GetDepositsByUserBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByUserBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByAccount")]
        [SwaggerOperation(Summary = "Get Deposits By Account")]
        public ResponseDto GetDepositsByAccount(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByAccount(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByStatusBudget")]
        [SwaggerOperation(Summary = "Get Deposits By StatusBudget")]
        public ResponseDto GetDepositsByStatusBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByStatusBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get Deposits By UserBudget StatusBudget")]
        public ResponseDto GetDepositsByUserBudgetStatusBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByUserBudgetStatusBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByAccountStatusBudget")]
        [SwaggerOperation(Summary = "Get Deposits By Account StatusBudget")]
        public ResponseDto GetDepositsByAccountStatusBudget(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByAccountStatusBudget(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveDeposit")]
        [SwaggerOperation(Summary = "Save Deposit")]
        public ResponseDto SaveDeposit(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.SaveDeposit(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateDeposit")]
        [SwaggerOperation(Summary = "Update Deposit")]
        public ResponseDto UpdateDeposit(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.UpdateDeposit(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteDeposit")]
        [SwaggerOperation(Summary = "Delete Deposit")]
        public ResponseDto DeleteDeposit(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.DeleteDeposit(deposit);
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