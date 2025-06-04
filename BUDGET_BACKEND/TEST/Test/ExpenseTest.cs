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
            _expenseService = new ExpenseService(unitOfWork);
            _expenseController = new ExpenseController(_expenseService);

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
            int Id = 1;

            ///Act
            var result = _expenseController!.GetExpenseById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpenseByIdFail()
        {
            ///Arrange   
            int Id = -1;

            ///Act
            var result = _expenseController!.GetExpenseById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpenseByNameOK()
        {
            ///Arrange   
            string Name = "Test";

            ///Act
            var result = _expenseController!.GetExpenseByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpenseByNameFail()
        {
            ///Arrange   
            string Name = "";

            ///Act
            var result = _expenseController!.GetExpenseByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseOK()
        {
            ///Arrange   
            int IdTypeExpense = 1;

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpense(IdTypeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseFail()
        {
            ///Arrange   
            int IdTypeExpense = -1;

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpense(IdTypeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByStatusOK()
        {
            ///Arrange   
            int IdStatus = 1;

            ///Act
            var result = _expenseController!.GetExpensesByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByStatusFail()
        {
            ///Arrange   
            int IdStatus = -1;

            ///Act
            var result = _expenseController!.GetExpensesByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseStatusOK()
        {
            ///Arrange   
            int IdTypeExpense = 1;
            int IdStatus = 1;

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpenseStatus(IdTypeExpense, IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseStatusFail()
        {
            ///Arrange
            int IdTypeExpense = -1;
            int IdStatus = -1;

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpenseStatus(IdTypeExpense, IdStatus);

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