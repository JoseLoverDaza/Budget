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
    using System.Net;    

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class StatusTest
    {

        #region Atributos y Propiedades

        private readonly IStatusService _statusService;       
        private readonly EFContext? _context;
        private readonly StatusController? _statusController;

        #endregion 

        #region Constructor

        public StatusTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);            
            _statusService = new StatusService(unitOfWork);            
            _statusController = new StatusController(_statusService);

            #region Data

            /// Status Id 1
            _context.Status.Add(new Status()
            {
                IdStatus = 1,
                Name = "Test",
                Description = "Test"
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetStatusByIdOK()
        {
            ///Arrange   
            int Id = 1;

            ///Act
            var result = _statusController!.GetStatusById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusByIdFail()
        {
            ///Arrange   
            int Id = -1;

            ///Act
            var result = _statusController!.GetStatusById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusByNameOK()
        {
            ///Arrange   
            string Name = "Test";

            ///Act
            var result = _statusController!.GetStatusByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusByNameFail()
        {
            ///Arrange   
            string Name = "";

            ///Act
            var result = _statusController!.GetStatusByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusOK()
        {
            ///Arrange   

            ///Act
            var result = _statusController!.GetStatus();

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveStatusOK()
        {
            ///Arrange   
            StatusDto status = new()
            {
                Name = "Test1"               
            };

            ///Act
            var result = _statusController!.SaveStatus(status);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveStatusFail()
        {
            ///Arrange   
            StatusDto status = new()
            {
                Name = "Test",
                IdStatus = -1
            };

            ///Act
            var result = _statusController!.SaveStatus(status);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateStatus()
        {
            ///Arrange   
            StatusDto status = new()
            {
                IdStatus = 1,
                Name = "Test1"
            };

            ///Act
            var result = _statusController!.UpdateStatus(status);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateStatusFail()
        {
            ///Arrange   
            StatusDto status = new()
            {
                Name = "Test",
                IdStatus = -1
            };

            ///Act
            var result = _statusController!.UpdateStatus(status);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}