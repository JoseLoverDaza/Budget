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
    using System;
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class ExpenseTest
    {

        #region  Atributos y Propiedades

        private readonly IExpenseService _expenseService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly ExpenseController? _expenseController;

        #endregion

        #region Constructor

        public ExpenseTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _expenseService = new ExpenseService(unitOfWork, _logApiService);           
            _expenseController = new ExpenseController(_expenseService);

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

            /// Expense Id 1
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 1,
                Name = "Test",
                Description = "Test",
                IdTypeExpense = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            /// Expense Id 2
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 2,
                Name = "Test1",
                Description = "Test",
                IdTypeExpense = 1,
                IdStatus = 2
            });

            _context.SaveChanges();

            #endregion Data
        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetExpenseByIdOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdExpense = 1
            };

            ///Act
            var result = _expenseController!.GetExpenseById(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpenseByIdFail()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdExpense = -1
            };

            ///Act
            var result = _expenseController!.GetExpenseById(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdTypeExpense = 1
            };


            ///Act
            var result = _expenseController!.GetExpensesByTypeExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseFail()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdTypeExpense = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByStatusOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.GetExpensesByStatus(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByStatusFail()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByStatus(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByNameTypeExpenseOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                Name = "Test",
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.GetExpensesByNameTypeExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByNameTypeExpenseFail()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                Name = "T",
                IdTypeExpense = -1,
                IdStatus = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByNameTypeExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseStatusOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpenseStatus(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseStatusFail()
        {
            ///Arrange
            ExpenseDto expense = new()
            {
                IdTypeExpense = -1,
                IdStatus = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpenseStatus(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveExpenseOK()
        {
            ///Arrange   
            ExpenseExtendDto expense = new()
            {
                Name = "Test2",
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.SaveExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveExpenseFail()
        {
            ///Arrange   
            ExpenseExtendDto expense = new()
            {
                Name = "Test",
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.SaveExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateExpenseOK()
        {
            ///Arrange   
            ExpenseExtendDto expense = new()
            {
                IdExpense = 1,
                Name = "Test",
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.UpdateExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateExpenseFail()
        {
            ///Arrange   
            ExpenseExtendDto expense = new()
            {
                IdExpense = -1,
                Name = "Test1",
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.UpdateExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteExpenseOK()
        {
            ///Arrange   
            ExpenseExtendDto expense = new()
            {
                IdExpense = 1,
                Name = "Test1",
                IdTypeExpense = 1,
                IdStatus = 3
            };

            ///Act
            var result = _expenseController!.DeleteExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteExpenseFail()
        {
            ///Arrange   
            ExpenseExtendDto expense = new()
            {
                IdExpense = -1,
                Name = "Test1",
                IdTypeExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _expenseController!.DeleteExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}