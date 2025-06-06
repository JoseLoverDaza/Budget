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
    /// Nombre: LogApiTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class LogApiTest
    {

        #region  Atributos y Propiedades

        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly LogApiController? _logApiController;

        #endregion

        #region Constructor

        public LogApiTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _logApiController = new LogApiController(_logApiService);

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

            /// Log Id 1
            _context.LogApis.Add(new LogApi()
            {
                IdLogApi = 1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion Data
        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetLogApiByIdOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = 1
            };

            ///Act
            var result = _logApiController!.GetLogApiById(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApiByIdFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = -1
            };

            ///Act
            var result = _logApiController!.GetLogApiById(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByCreationDateOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _logApiController!.GetLogApisByCreationDate(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByCreationDateFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _logApiController!.GetLogApisByCreationDate(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByStatusOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _logApiController!.GetLogApisByStatus(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByStatusFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _logApiController!.GetLogApisByStatus(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByEntityCreationDateOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {                
                EntityAction = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _logApiController!.GetLogApisByEntityCreationDate(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByEntityCreationDateFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                EntityAction = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _logApiController!.GetLogApisByEntityCreationDate(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByCreationDateStatusOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {                
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _logApiController!.GetLogApisByCreationDateStatus(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByCreationDateStatusFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logApiController!.GetLogApisByCreationDateStatus(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByEntityCreationDateStatusOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                EntityAction = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _logApiController!.GetLogApisByEntityCreationDateStatus(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByEntityCreationDateStatusFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                EntityAction = "T",
                CreationDate = new DateTime(2025, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logApiController!.GetLogApisByEntityCreationDateStatus(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveLogApiOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {               
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _logApiController!.SaveLogApi(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveLogApiFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logApiController!.SaveLogApi(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateLogApiFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = -1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logApiController!.UpdateLogApi(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteLogApiOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = 1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 3
            };

            ///Act
            var result = _logApiController!.DeleteLogApi(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteLogApiFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = -1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logApiController!.DeleteLogApi(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}