namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using Domain.Context;
    using Domain.Dto;
    using Domain.Entities;
    using INFRAESTRUCTURE.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuthenticationTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class AuthenticationTest
    {

        #region  Atributos y Propiedades

        private readonly IAuthenticationService _authenticationService;
        private readonly EFContext? _context;
        private readonly AuthenticationController? _authenticationController;

        #endregion

        #region Constructor

        public AuthenticationTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _authenticationService = new AuthenticationService(unitOfWork);
            _authenticationController = new AuthenticationController(_authenticationService);

            #region Data

            /// Status Id 1
            _context.Status.Add(new Status()
            {
                IdStatus = 1,
                Name = "Test",
                Description = "Test"
            });

            _context.SaveChanges();

            /// Status Id 2
            _context.Status.Add(new Status()
            {
                IdStatus = 2,
                Name = "Test1",
                Description = "Test1"
            });

            _context.SaveChanges();

            /// Status Id 3
            _context.Status.Add(new Status()
            {
                IdStatus = 3,
                Name = "Test2",
                Description = "Test2"
            });

            _context.SaveChanges();

            /// Role Id 1
            _context.Roles.Add(new Role()
            {
                IdRole = 1,
                Name = "Test",
                Description = "Test"
            });

            _context.SaveChanges();

            /// User Id 1
            _context.Users.Add(new User()
            {
                IdUser = 1,
                Email = "Test",
                Phone = "Test",
                Username = "Test",
                Password = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRole = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void AuthenticationOK()
        {
            ///Arrange   
            AuthenticationDto authentication = new()
            {
                Username = "T",
                Password = "T"
            };

            ///Act
            var result = _authenticationController!.Authentication(authentication);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void AuthenticationFail()
        {
            ///Arrange   
            AuthenticationDto authentication = new()
            {
                Username = "T",
                Password = "T"
            };

            ///Act
            var result = _authenticationController!.Authentication(authentication);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void ValidateAuthenticationOK()
        {
            ///Arrange   
            AuthenticationDto authentication = new()
            {
                Username = "T",
                Password = "T"
            };

            ///Act
            var result = _authenticationController!.ValidateAuthentication(authentication);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void ValidateAuthenticationFail()
        {
            ///Arrange   
            AuthenticationDto authentication = new()
            {
                Username = "Test",
                Password = "Test"
            };

            ///Act
            var result = _authenticationController!.ValidateAuthentication(authentication);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}