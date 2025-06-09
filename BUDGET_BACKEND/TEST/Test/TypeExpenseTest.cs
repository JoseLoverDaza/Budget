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
    /// Nombre: TypeExpenseTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class TypeExpenseTest
    {

        #region Atributos y Propiedades

        private readonly ITypeExpenseService _typeExpenseService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly TypeExpenseController? _typeExpenseController;

        #endregion

        #region Constructor

        public TypeExpenseTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _typeExpenseService = new TypeExpenseService(unitOfWork, _logApiService);           
            _typeExpenseController = new TypeExpenseController(_typeExpenseService);

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

            /// TypeExpense Id 1
            _context.TypeExpenses.Add(new TypeExpense()
            {
                IdTypeExpense = 1,
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
        public void GetTypeExpenseByIdOK()
        {
            ///Arrange  
            TypeExpenseDto typeExpense = new()
            {
                IdTypeExpense = 1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseById(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpenseByIdFail()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                IdTypeExpense = -1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseById(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpenseByNameOK()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                Name = "Test"
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseByName(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpenseByNameFail()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                Name = "T"
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseByName(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpensesByStatusOK()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpensesByStatus(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpensesByStatusFail()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpensesByStatus(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeExpenseController!.SaveTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                Name = "Test",
                IdStatus = 1
            };

            ///Act
            var result = _typeExpenseController!.SaveTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = 1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeExpenseController!.UpdateTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = -1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeExpenseController!.UpdateTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = 1,
                Name = "Test1",
                IdStatus = 3
            };

            ///Act
            var result = _typeExpenseController!.DeleteTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = -1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeExpenseController!.DeleteTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}