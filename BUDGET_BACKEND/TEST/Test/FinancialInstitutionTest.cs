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
        private readonly ILogApiService _logApiService;
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
            _logApiService = new LogApiService(unitOfWork);
            _financialInstitutionService = new FinancialInstitutionService(unitOfWork, _logApiService);           
            _financialInstitutionController = new FinancialInstitutionController(_financialInstitutionService);

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

            /// FinancialInstitution IdFinancialInstitution 1
            _context.FinancialInstitutions.Add(new FinancialInstitution()
            {
                IdFinancialInstitution = 1,
                NameFinancialInstitution = "Test",
                DescriptionFinancialInstitution = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetFinancialInstitutionByIdFinancialInstitutionOK()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdFinancialInstitution = 1
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByIdFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByIdFinancialInstitutionFail()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdFinancialInstitution = -1
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByIdFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByNameFinancialInstitutionOK()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                NameFinancialInstitution = "Test"
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByNameFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionByNameFinancialInstitutionFail()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                NameFinancialInstitution = "T"
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionByNameFinancialInstitution(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionsByStatusBudgetOK()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionsByStatusBudget(financialInstitution);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetFinancialInstitutionsByStatusBudgetFail()
        {
            ///Arrange   
            FinancialInstitutionDto financialInstitution = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _financialInstitutionController!.GetFinancialInstitutionsByStatusBudget(financialInstitution);

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
                NameFinancialInstitution = "Test1",
                IdStatusBudget = 1
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
                NameFinancialInstitution = "Test",
                IdStatusBudget = 1
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
                NameFinancialInstitution = "Test1",
                IdStatusBudget = 1
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
                NameFinancialInstitution = "Test1",
                IdStatusBudget = 1
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
                NameFinancialInstitution = "Test1",
                IdStatusBudget = 3
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
                NameFinancialInstitution = "Test1",
                IdStatusBudget = 1
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