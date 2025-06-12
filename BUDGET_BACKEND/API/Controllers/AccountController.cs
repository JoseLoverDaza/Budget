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
    /// Nombre: AccountController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IAccountService _accountService;

        #endregion

        #region Constructor

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetAccountByIdAccount")]
        [SwaggerOperation(Summary = "Get Account By IdAccount")]
        public ResponseDto GetAccountByIdAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountByIdAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByFinancialInstitution")]
        [SwaggerOperation(Summary = "Get Accounts By Financial Institution")]
        public ResponseDto GetAccountsByFinancialInstitution(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitution(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByTypeAccount")]
        [SwaggerOperation(Summary = "Get Accounts By Type Account")]
        public ResponseDto GetAccountsByTypeAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByTypeAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByUserBudget")]
        [SwaggerOperation(Summary = "Get Accounts By UserBudget")]
        public ResponseDto GetAccountsByUserBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByUserBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByStatusBudget")]
        [SwaggerOperation(Summary = "Get Accounts By StatusBudget")]
        public ResponseDto GetAccountsByStatusBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByStatusBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByFinancialInstitutionStatusBudget")]
        [SwaggerOperation(Summary = "Get Accounts By FinancialInstitution StatusBudget")]
        public ResponseDto GetAccountsByFinancialInstitutionStatusBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitutionStatusBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByTypeAccountStatusBudget")]
        [SwaggerOperation(Summary = "Get Accounts By TypeAccount StatusBudget")]
        public ResponseDto GetAccountsByTypeAccountStatusBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByTypeAccountStatusBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get Accounts By UserBudget StatusBudget")]
        public ResponseDto GetAccountsByUserBudgetStatusBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByUserBudgetStatusBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByNameFinancialInstitutionTypeAccountUserBudget")]
        [SwaggerOperation(Summary = "Get Accounts By NameFinancialInstitution TypeAccount UserBudget")]
        public ResponseDto GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByFinancialInstitutionTypeAccountUserBudget")]
        [SwaggerOperation(Summary = "Get Accounts By FinancialInstitution TypeAccount UserBudget")]
        public ResponseDto GetAccountsByFinancialInstitutionTypeAccountUserBudget(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitutionTypeAccountUserBudget(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveAccount")]
        [SwaggerOperation(Summary = "Save Account")]
        public ResponseDto SaveAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.SaveAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateAccount")]
        [SwaggerOperation(Summary = "Update Account")]
        public ResponseDto UpdateAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.UpdateAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteAccount")]
        [SwaggerOperation(Summary = "Delete Account")]
        public ResponseDto DeleteAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.DeleteAccount(account);
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