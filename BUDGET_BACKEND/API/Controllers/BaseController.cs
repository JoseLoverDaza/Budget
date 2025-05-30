namespace API.Controllers
{

    #region Librerias

    using Domain.Dto.Common;    
    using Microsoft.AspNetCore.Mvc;  
    using System.Net;
    using System.Runtime.InteropServices;
    
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BaseController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BaseController : ControllerBase
    {

        #region Atributos y Propiedades

        protected ResponseDto response;
        protected readonly ResponseDto responseError;

        #endregion

        #region Constructor

        public BaseController()
        {
            response = new ResponseDto
            {
                Status = true,
                Code = HttpStatusCode.OK.GetHashCode()
            };
            responseError = new ResponseDto
            {
                Status = false,
                Code = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }

        #endregion Constructor

        #region Métodos y Funciones

        protected void ResponseError(Exception ex, bool includeInnerException = false)
        {
            Serilog.Log.Error(ex, string.Format("Demo - {0}", ex.Message));
            responseError.Message = typeof(ExternalException) != ex.GetType() ? CORE.Utils.Constants.General.MESSAGE_GENERAL : ex.Message;
            if (includeInnerException && ex.InnerException != null)
                responseError.Data = ex.InnerException.Message;
            response = responseError;
        }

        #endregion

    }
}