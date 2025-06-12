namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
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
    /// Nombre: TokenApiTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class TokenApiTest
    {

        #region  Atributos y Propiedades

        private readonly ITokenApiService _tokenApiService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly TokenApiController? _tokenApiController;

        #endregion

        #region Constructor

        public TokenApiTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _tokenApiService = new TokenApiService(unitOfWork, _logApiService);            
            _tokenApiController = new TokenApiController(_tokenApiService);

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
                NameRole = Constants.UserBudget.USERNAME_ADMIN,
                DescriptionRole = Constants.UserBudget.USERNAME_ADMIN,
                IdStatusBudget = 2
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

            /// TokenApi IdTokenApi 1
            _context.TokenApis.Add(new TokenApi()
            {
                IdTokenApi = 1,
                Token = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                ExpirationDate = new DateTime(2026, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetTokenApiByIdTokenApiOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApiByIdTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApiByIdTokenApiFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApiByIdTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApiByTokenOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                Token = "Test"
            };

            ///Act
            var result = _tokenApiController!.GetTokenApiByToken(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApiByTokenFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                Token = "T"
            };

            ///Act
            var result = _tokenApiController!.GetTokenApiByToken(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDate(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDate(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUserBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUserBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUserBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUserBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByStatusBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByStatusBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateStatusBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1),
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateStatusBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateStatusBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2026, 1, 1),
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateStatusBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2025, 1, 1),
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUserBudgetStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUserBudgetStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateUserBudgetStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateUserBudgetStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2026, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateUserBudgetStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateUserBudgetStatusBudget(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTokenApiOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                Token = "Test1",
                CreationDate = new DateTime(2025, 1, 1),
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.SaveTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTokenApiFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                Token = "Test",
                CreationDate = new DateTime(2025, 1, 1),
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _tokenApiController!.SaveTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTokenApiOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = 1,
                Token = "Test",
                CreationDate = new DateTime(2025, 1, 1),
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.UpdateTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTokenApiFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = -1,
                Token = "Test",
                CreationDate = new DateTime(2025, 1, 1),
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.UpdateTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTokenApiOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = 1,
                Token = "Test",
                CreationDate = new DateTime(2025, 1, 1),
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _tokenApiController!.DeleteTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTokenApiFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = -1,
                Token = "Test",
                CreationDate = new DateTime(2025, 1, 1),
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _tokenApiController!.DeleteTokenApi(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}