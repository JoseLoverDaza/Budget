
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using Domain.Context;
    using Domain.Entities;
    using INFRAESTRUCTURE.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class UserTest
    {

        #region  Atributos y Propiedades

        private readonly IUserService _userService;
        private readonly EFContext? _context;
        private readonly UserController? _userController;

        #endregion

        #region Constructor

        public UserTest()
        { 
        }

        #endregion

    }
}