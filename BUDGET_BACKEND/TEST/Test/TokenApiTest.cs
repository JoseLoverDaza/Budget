namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
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
    /// Nombre: TokenApiTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class TokenApiTest
    {

        #region  Atributos y Propiedades

        private readonly ITokenApiService _tokenApiService;
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
            _tokenApiService = new TokenApiService(unitOfWork);
            _tokenApiController = new TokenApiController(_tokenApiService);

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
                Description = "Test",
                IdStatus = 1
            });

            _context.SaveChanges();

            /// User Id 1
            _context.Users.Add(new User()
            {
                IdUser = 1,
                Email = "Test",
                Phone = "1234567890",
                Username = "Test",
                Password = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRole = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            /// TokenApi Id 1
            _context.TokenApis.Add(new TokenApi()
            {
                IdTokenApi = 1,
                Token = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                ExpirationDate = new DateTime(2026, 1, 1),
                IdUser = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion Data
        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetTokenApiByIdOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApiById(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApiByIdFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdTokenApi = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApiById(tokenApi);

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
        public void GetTokenApisByUserOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUser = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUser(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUser = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUser(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByStatusOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByStatusFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateStatusOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateStatusFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateStatusOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateStatusFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2025, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserStatusOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUserStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByUserStatusFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByUserStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateUserStatusOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1),
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateUserStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByCreationDateUserStatusFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByCreationDateUserStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateUserStatusOK()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2026, 1, 1),
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateUserStatus(tokenApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTokenApisByExpirationDateUserStatusFail()
        {
            ///Arrange   
            TokenApiDto tokenApi = new()
            {
                ExpirationDate = new DateTime(2025, 1, 1),
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _tokenApiController!.GetTokenApisByExpirationDateUserStatus(tokenApi);

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
                IdUser = 1,
                IdStatus = 1
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
                IdUser = -1,
                IdStatus = -1
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
                IdUser = 1,
                IdStatus = 1
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
                IdUser = 1,
                IdStatus = 1
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
                IdUser = 1,
                IdStatus = 3
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
                IdUser = 1,
                IdStatus = 1
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