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

            /// RolesBudget IdRoleBudget 1
            _context.RolesBudget.Add(new RoleBudget()
            {
                IdRoleBudget = 1,
                NameRole = "Test",
                DescriptionRole = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// UsersBudget IdUserBudget 1
            _context.UsersBudget.Add(new UserBudget()
            {
                IdUserBudget = 1,
                Email = "Test",
                Phone = "1234567890",
                Username = Constants.UserBudget.USERNAME_ADMIN,
                EncryptedPassword = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRoleBudget = 1,
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            /// TypeExpense IdTypeExpense 1
            _context.TypeExpenses.Add(new TypeExpense()
            {
                IdTypeExpense = 1,
                NameTypeExpense = "Test",
                DescriptionTypeExpense = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Expense IdExpense 1
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 1,
                NameExpense = "Test",
                DescriptionExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Expense IdExpense 2
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 2,
                NameExpense = "Test1",
                DescriptionExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetExpenseByIdExpenseOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdExpense = 1
            };

            ///Act
            var result = _expenseController!.GetExpenseByIdExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpenseByIdExpenseFail()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdExpense = -1
            };

            ///Act
            var result = _expenseController!.GetExpenseByIdExpense(expense);

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
        public void GetExpensesByStatusBudgetOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _expenseController!.GetExpensesByStatusBudget(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByStatusBudgetFail()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByStatusBudget(expense);

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
                NameExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
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
                NameExpense = "T",
                IdTypeExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByNameTypeExpense(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseStatusBudgetOK()
        {
            ///Arrange   
            ExpenseDto expense = new()
            {
                IdTypeExpense = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpenseStatusBudget(expense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetExpensesByTypeExpenseStatusBudgetFail()
        {
            ///Arrange
            ExpenseDto expense = new()
            {
                IdTypeExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _expenseController!.GetExpensesByTypeExpenseStatusBudget(expense);

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
                NameExpense = "Test2",
                IdTypeExpense = 1,
                IdStatusBudget = 1
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
                NameExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
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
                NameExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
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
                NameExpense = "Test1",
                IdTypeExpense = 1,
                IdStatusBudget = 1
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
                NameExpense = "Test1",
                IdTypeExpense = 1,
                IdStatusBudget = 3
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
                NameExpense = "Test1",
                IdTypeExpense = 1,
                IdStatusBudget = 1
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