namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using Domain.Context;
    using Domain.Entities;
    using INFRAESTRUCTURE.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class FinancialInstitutionTest
    {

        #region Atributos y Propiedades

        private readonly IFinancialInstitutionService _financialInstitutionService;
        private readonly EFContext? _context;
        private readonly FinancialInstitutionController? _financialInstitutionController;

        #endregion

        #region Constructor

        public FinancialInstitutionTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _financialInstitutionService = new FinancialInstitutionService(unitOfWork);
            _financialInstitutionController = new FinancialInstitutionController(_financialInstitutionService);

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

            /// FinancialInstitution Id 1
            _context.FinancialInstitutions.Add(new FinancialInstitution()
            {
                IdFinancialInstitution = 1,
                Name = "Test",
                Description = "Test",
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetFinancialInstitutionByIdOK()
        {
            ///Arrange   
            int Id = 1;

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByIdFail()
        {
            ///Arrange   
            int Id = -1;

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByNameOK()
        {
            ///Arrange   
            string Name = "Test";

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByNameFail()
        {
            ///Arrange   
            string Name = "";

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionsByStatusOK()
        {
            ///Arrange   
            int IdStatus = 1;

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionsByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionsByStatusFail()
        {
            ///Arrange   
            int IdStatus = -1;

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionsByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveFinancialInstitutionOK()
        {
            ///Arrange   
            FinancialInstitutionExtendDto financialInstitution = new()
            {
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _financialInstitutionController!.SaveFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveFinancialInstitutionFail()
        {
            ///Arrange   
            FinancialInstitutionExtendDto financialInstitution = new()
            {
                Name = "Test",
                IdStatus = 1
            };

            ///Act
            var result = _financialInstitutionController!.SaveFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateFinancialInstitutionOK()
        {
            ///Arrange   
            FinancialInstitutionExtendDto financialInstitution = new()
            {
                IdFinancialInstitution = 1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _financialInstitutionController!.UpdateFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateFinancialInstitutionFail()
        {
            ///Arrange   
            FinancialInstitutionExtendDto financialInstitution = new()
            {
                IdFinancialInstitution = -1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _financialInstitutionController!.UpdateFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteFinancialInstitutionOK()
        {
            ///Arrange   
            FinancialInstitutionExtendDto financialInstitution = new()
            {
                IdFinancialInstitution = 1,
                Name = "Test1",
                IdStatus = 3
            };

            ///Act
            var result = _financialInstitutionController!.DeleteFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteFinancialInstitutionFail()
        {
            ///Arrange   
            FinancialInstitutionExtendDto financialInstitution = new()
            {
                IdFinancialInstitution = -1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _financialInstitutionController!.DeleteFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}