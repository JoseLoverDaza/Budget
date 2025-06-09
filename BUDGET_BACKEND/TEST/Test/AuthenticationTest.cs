namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
    using Domain.Context;
    using Domain.Entities;
    using INFRAESTRUCTURE.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
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
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly AuthenticationController? _authenticationController;

        #endregion

        #region Constructor

        public AuthenticationTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            var inMemorySettings = new Dictionary<string, string>
            {               
                {"Encryption:SecretKey", "1c6225ec7092ad2f4a4acd79f8fc6854aa10653763fb053a6cf2bb2d2a4148ab"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _authenticationService = new AuthenticationService(unitOfWork, configuration, _logApiService);
            
            _authenticationController = new AuthenticationController(_authenticationService);

            #region Data

            /// Status Id 1
            _context.Status.Add(new Status()
            {
                IdStatus = 1,
                Name = Constants.Status.INACTIVO,
                Description = Constants.Status.INACTIVO
            });

            _context.SaveChanges();

            /// Status Id 2
            _context.Status.Add(new Status()
            {
                IdStatus = 2,
                Name = Constants.Status.ACTIVO,
                Description = Constants.Status.ACTIVO
            });

            _context.SaveChanges();

            /// Status Id 3
            _context.Status.Add(new Status()
            {
                IdStatus = 3,
                Name = Constants.Status.CANCELADO,
                Description = Constants.Status.CANCELADO
            });

            _context.SaveChanges();

            /// Role Id 1
            _context.Roles.Add(new Role()
            {
                IdRole = 1,
                Name = "Test",
                Description = "Test",
                IdStatus = 2
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
                IdStatus = 2
            });

            _context.SaveChanges();

            /// Token Id 1
            _context.TokenApis.Add(new TokenApi()
            {
                IdTokenApi = 1,
                Token = "Test",
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(1),
                IdUser = 1,
                IdStatus = 2
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
                Username = "Test",
                Password = "Test"
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
                Token = "Test"
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
                Token = "T"
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