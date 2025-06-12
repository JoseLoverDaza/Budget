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

            /// StatusBudget IdStatusBudget 1
            _context.StatusBudget.Add(new StatusBudget()
            {
                IdStatusBudget = 1,
                NameStatus = Constants.Status.INACTIVO,
                DescriptionStatus = Constants.Status.INACTIVO
            });

            _context.SaveChanges();

            /// StatusBudget IdStatusBudget 2
            _context.StatusBudget.Add(new StatusBudget()
            {
                IdStatusBudget = 2,
                NameStatus = Constants.Status.ACTIVO,
                DescriptionStatus = Constants.Status.ACTIVO
            });

            _context.SaveChanges();

            /// StatusBudget IdStatusBudget 3
            _context.StatusBudget.Add(new StatusBudget()
            {
                IdStatusBudget = 3,
                NameStatus = Constants.Status.CANCELADO,
                DescriptionStatus = Constants.Status.CANCELADO
            });

            _context.SaveChanges();

            /// RolesBudget IdRoleBudget 1
            _context.RolesBudget.Add(new RoleBudget()
            {
                IdRoleBudget = 1,
                NameRole = "Test",
                DescriptionRole = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// UsersBudget IdUserBudget 1
            _context.UsersBudget.Add(new UserBudget()
            {
                IdUserBudget = 1,
                Email = "Test",
                Phone = "1234567890",
                Username = Constants.UserBudget.USERNAME_ADMIN,
                EncryptedPassword = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRoleBudget = 1,
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            /// UsersBudget IdUserBudget 1
            _context.UsersBudget.Add(new UserBudget()
            {
                IdUserBudget = 2,
                Email = "Test",
                Phone = "1234567890",
                Username = "Test",
                EncryptedPassword = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRoleBudget = 1,
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            /// Token Id 1
            _context.TokenApis.Add(new TokenApi()
            {
                IdTokenApi = 1,
                Token = "Test",
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(1),
                IdUserBudget = 1,
                IdStatusBudget = 2
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
                EncryptedPassword = "Test"
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
                EncryptedPassword = "T"
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