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
    /// Nombre: AuditApiTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class AuditApiTest
    {

        #region  Atributos y Propiedades

        private readonly IAuditApiService _auditApiService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly AuditApiController? _auditApiController;

        #endregion

        #region Constructor

        public AuditApiTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _auditApiService = new AuditService(unitOfWork, _logApiService);           
            _auditApiController = new AuditApiController(_auditApiService);

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

            /// AuditApis IdAuditApi 1
            _context.AuditApis.Add(new AuditApi()
            {
                IdAuditApi = 1,
                Host = "Test",
                EndpointUrl = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            });

            _context.SaveChanges();

            #endregion Data
        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetAuditApiByIdAuditApiOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                IdAuditApi = 1
            };

            ///Act
            var result = _auditApiController!.GetAuditApiByIdAuditApi(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApiByIdAuditApiFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                IdAuditApi = -1
            };

            ///Act
            var result = _auditApiController!.GetAuditApiByIdAuditApi(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByCreationDateOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByCreationDateFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByMethodCreationDateOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                Method = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByMethodCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByMethodCreationDateFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                Method = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByMethodCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByEndpointUrlCreationDateOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                EndpointUrl = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByEndpointUrlCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByEndpointUrlCreationDateFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                EndpointUrl = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByEndpointUrlCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByEndpointUrlMethodCreationDateOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                EndpointUrl = "Test",
                Method = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByEndpointUrlMethodCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditApisByEndpointUrlMethodCreationDateFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                EndpointUrl = "T",
                Method = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditApiController!.GetAuditApisByEndpointUrlMethodCreationDate(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveAuditApiOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                Host = "Test",
                EndpointUrl = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = DateTime.Now
            };

            ///Act
            var result = _auditApiController!.SaveAuditApi(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveAuditApiFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {                
                Host = "Test",
                EndpointUrl = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = DateTime.Now
            };

            ///Act
            var result = _auditApiController!.SaveAuditApi(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateAuditApiOK()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                IdAuditApi = 1,
                Host = "Test",
                EndpointUrl = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = DateTime.Now
            };

            ///Act
            var result = _auditApiController!.UpdateAuditApi(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateAuditApiFail()
        {
            ///Arrange   
            AuditApiDto auditApi = new()
            {
                IdAuditApi = -1,
                Host = "Test",
                EndpointUrl = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = DateTime.Now
            };

            ///Act
            var result = _auditApiController!.UpdateAuditApi(auditApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}