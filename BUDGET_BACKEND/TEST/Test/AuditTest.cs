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
    /// Nombre: AuditTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class AuditTest
    {

        #region  Atributos y Propiedades

        private readonly IAuditService _auditService;
        private readonly EFContext? _context;
        private readonly AuditController? _auditController;

        #endregion

        #region Constructor

        public AuditTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _auditService = new AuditService(unitOfWork);
            _auditController = new AuditController(_auditService);

            #region Data

            /// Audit Id 1
            _context.Audits.Add(new Audit()
            {
                IdAudit = 1,
                Host = "Test",
                Endpoint = "Test",
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
        public void GetAuditByIdOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                IdAudit = 1
            };

            ///Act
            var result = _auditController!.GetAuditById(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditByIdFail()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                IdAudit = -1
            };

            ///Act
            var result = _auditController!.GetAuditById(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByCreationDateOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByCreationDateFail()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByMethodCreationDateOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Method = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByMethodCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByMethodCreationDateFail()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Method = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByMethodCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByEndpointCreationDateOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Endpoint = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByEndpointCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByEndpointCreationDateFail()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Endpoint = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByEndpointCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByEndpointMethodCreationDateOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Endpoint = "Test",
                Method = "Test",
                CreationDate = new DateTime(2026, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByEndpointMethodCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAuditsByEndpointMethodCreationDateFail()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Endpoint = "T",
                Method = "T",
                CreationDate = new DateTime(2025, 1, 1)
            };

            ///Act
            var result = _auditController!.GetAuditsByEndpointMethodCreationDate(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveAuditOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                Host = "Test",
                Endpoint = "Test",
                Agent = "Test", 
                Method = "Test",
                CreationDate= DateTime.Now                
            };

            ///Act
            var result = _auditController!.SaveAudit(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateAuditOK()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                IdAudit = 1,
                Host = "Test",
                Endpoint = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = DateTime.Now              
            };

            ///Act
            var result = _auditController!.UpdateAudit(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateAuditFail()
        {
            ///Arrange   
            AuditDto audit = new()
            {
                IdAudit = -1,
                Host = "Test",
                Endpoint = "Test",
                Agent = "Test",
                Method = "Test",
                CreationDate = DateTime.Now               
            };

            ///Act
            var result = _auditController!.UpdateAudit(audit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}