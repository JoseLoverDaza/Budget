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

            /// Log Id 1
            _context.LogApis.Add(new LogApi()
            {
                IdLogApi = 1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetLogApiByIdLogApiOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = 1
            };

            ///Act
            var result = _logApiController!.GetLogApiByIdLogApi(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApiByIdLogApiFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdLogApi = -1
            };

            ///Act
            var result = _logApiController!.GetLogApiByIdLogApi(logApi);

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
        public void GetLogApisByStatusBudgetOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _logApiController!.GetLogApisByStatusBudget(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByStatusBudgetFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _logApiController!.GetLogApisByStatusBudget(logApi);

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
        public void GetLogApisByCreationDateStatusBudgetOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                CreationDate = new DateTime(2026, 1, 1),
                IdStatusBudget = 1
            };

            ///Act
            var result = _logApiController!.GetLogApisByCreationDateStatusBudget(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByCreationDateStatusBudgetFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdStatusBudget = -1
            };

            ///Act
            var result = _logApiController!.GetLogApisByCreationDateStatusBudget(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByEntityCreationDateStatusBudgetOK()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                EntityAction = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatusBudget = 1
            };

            ///Act
            var result = _logApiController!.GetLogApisByEntityCreationDateStatusBudget(logApi);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogApisByEntityCreationDateStatusBudgetFail()
        {
            ///Arrange   
            LogApiDto logApi = new()
            {
                EntityAction = "T",
                CreationDate = new DateTime(2025, 1, 1),
                IdStatusBudget = -1
            };

            ///Act
            var result = _logApiController!.GetLogApisByEntityCreationDateStatusBudget(logApi);

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
                IdStatusBudget = 1
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
                IdStatusBudget = -1
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
                IdStatusBudget = -1
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
                IdStatusBudget = 3
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
                IdStatusBudget = -1
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