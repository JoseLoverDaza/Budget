namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
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
                Name = Constants.Status.INACTIVO,
                Description = Constants.Status.INACTIVO
            });

            _context.SaveChanges();

            /// Status Id 2
            _context.Status.Add(new Status()
            {
                IdStatus = 2,
                Name = Constants.Status.ACTIVO,
                Description = Constants.Status.ACTIVO
            });

            _context.SaveChanges();

            /// Status Id 3
            _context.Status.Add(new Status()
            {
                IdStatus = 3,
                Name = Constants.Status.CANCELADO,
                Description = Constants.Status.CANCELADO
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
            FinancialInstitutionDto financialInstitution = new()
            {
                IdFinancialInstitution = 1
            };
            
            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionById(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByIdFail()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdFinancialInstitution = -1
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionById(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByNameOK()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                Name = "Test"
            };
            
            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByName(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByNameFail()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                Name = "T"
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByName(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionsByStatusOK()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdStatus = 1
            };
            
            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionsByStatus(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionsByStatusFail()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionsByStatus(financialInstitution);

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