namespace API.Controllers
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Services;   
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Dto.Common;   
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

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
        [Route("GetDepositById")]
        [SwaggerOperation(Summary = "Get Deposit By Id")]
        public ResponseDto GetDepositById(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositById(deposit);
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
        [Route("GetDepositsByYearUser")]
        [SwaggerOperation(Summary = "Get Deposits By Year User")]
        public ResponseDto GetDepositsByYearUser(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearUser(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByMonthUser")]
        [SwaggerOperation(Summary = "Get Deposits By Month User")]
        public ResponseDto GetDepositsByMonthUser(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByMonthUser(deposit);
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
        public ResponseDto GetDepositsByYearMonthUser(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthUser(deposit);
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
        [Route("GetDepositsByYearMonthStatus")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month Status")]
        public ResponseDto GetDepositsByYearMonthStatus(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthStatus(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByYearMonthUserAccount")]
        [SwaggerOperation(Summary = "GetDepositsByYearMonthUserAccount")]
        public ResponseDto GetDepositsByYearMonthUserAccount(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthUserAccount(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByUser")]
        [SwaggerOperation(Summary = "Get Deposits By User")]
        public ResponseDto GetDepositsByUser(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByUser(deposit);
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
        [Route("GetDepositsByStatus")]
        [SwaggerOperation(Summary = "Get Deposits By Status")]
        public ResponseDto GetDepositsByStatus(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByStatus(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByUserStatus")]
        [SwaggerOperation(Summary = "Get Deposits By User Status")]
        public ResponseDto GetDepositsByUserStatus(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByUserStatus(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetDepositsByAccountStatus")]
        [SwaggerOperation(Summary = "Get Deposits By Account Status")]
        public ResponseDto GetDepositsByAccountStatus(DepositDto deposit)
        {
            try
            {
                response.Data = _depositService.GetDepositsByAccountStatus(deposit);
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