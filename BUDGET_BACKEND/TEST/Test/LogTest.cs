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
    /// Nombre: LogTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class LogTest
    {

        #region  Atributos y Propiedades

        private readonly ILogService _logService;
        private readonly EFContext? _context;
        private readonly LogController? _logController;

        #endregion

        #region Constructor

        public LogTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logService = new LogService(unitOfWork);
            _logController = new LogController(_logService);

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
            _context.Logs.Add(new Log()
            {
                IdLog = 1,
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
        public void GetLogByIdOK()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdLog = 1
            };

            ///Act
            var result = _logController!.GetLogById(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogByIdFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdLog = -1
            };

            ///Act
            var result = _logController!.GetLogById(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByCreationDateOK()
        {
            ///Arrange   
            LogDto log = new()
            {
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _logController!.GetLogsByCreationDate(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByCreationDateFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _logController!.GetLogsByCreationDate(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByStatusOK()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _logController!.GetLogsByStatus(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByStatusFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _logController!.GetLogsByStatus(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByEntityCreationDateOK()
        {
            ///Arrange   
            LogDto log = new()
            {                
                EntityAction = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _logController!.GetLogsByEntityCreationDate(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByEntityCreationDateFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                EntityAction = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _logController!.GetLogsByEntityCreationDate(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByCreationDateStatusOK()
        {
            ///Arrange   
            LogDto log = new()
            {                
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _logController!.GetLogsByCreationDateStatus(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByCreationDateStatusFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                CreationDate = new DateTime(2025, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logController!.GetLogsByCreationDateStatus(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByEntityCreationDateStatusOK()
        {
            ///Arrange   
            LogDto log = new()
            {
                EntityAction = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _logController!.GetLogsByEntityCreationDateStatus(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetLogsByEntityCreationDateStatusFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                EntityAction = "T",
                CreationDate = new DateTime(2025, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logController!.GetLogsByEntityCreationDateStatus(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveLogOK()
        {
            ///Arrange   
            LogDto log = new()
            {               
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 1
            };

            ///Act
            var result = _logController!.SaveLog(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveLogFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logController!.SaveLog(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateLogFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdLog = -1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logController!.UpdateLog(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteLogOK()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdLog = 1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = 3
            };

            ///Act
            var result = _logController!.DeleteLog(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteLogFail()
        {
            ///Arrange   
            LogDto log = new()
            {
                IdLog = -1,
                Entity = "Test",
                EntityAction = "Test",
                PreviousValues = "Test",
                NewValues = "Test",
                CreationDate = new DateTime(2026, 1, 1),
                IdStatus = -1
            };

            ///Act
            var result = _logController!.DeleteLog(log);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}