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

    }
}
