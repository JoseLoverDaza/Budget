namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
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
    /// Nombre: BudgetDetailsTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class BudgetDetailsTest
    {

        #region  Atributos y Propiedades

        private readonly IBudgetDetailsService _budgetDetailsService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly BudgetDetailsController? _budgetDetailsController;

        #endregion

        #region Constructor

        public BudgetDetailsTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _budgetDetailsService = new BudgetDetailsService(unitOfWork, _logApiService);            
            _budgetDetailsController = new BudgetDetailsController(_budgetDetailsService);

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

            /// TypeExpense Id 1
            _context.TypeExpenses.Add(new TypeExpense()
            {
                IdTypeExpense = 1,
                NameTypeExpense = "Test",
                DescriptionTypeExpense = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Expense Id 1
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 1,
                NameExpense = "Test",
                DescriptionExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Expense Id 2
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 2,
                NameExpense = "Test1",
                DescriptionExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Billing Id 1
            _context.Budgets.Add(new Budget()
            {
                IdBudget = 1,
                YearBudget = 2026,
                MonthBudget = 1,
                CreationDate = new DateTime(2026, 1, 1),
                DescriptionBudget = "Test",
                IdUserBudget = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// BudgetDetails Id 1
            _context.BudgetDetails.Add(new BudgetDetails()
            {
                IdBudgetDetails = 1,
                IdBudget = 1,
                CreationDate = new DateTime(2026, 1, 1),
                Amount = 1000,
                IdExpense = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetBudgetDetailsByIdBudgetDetailsOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByIdBudgetDetails(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByIdBudgetDetailsFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByIdBudgetDetails(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByExpenseOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdExpense = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByExpense(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByExpenseFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdExpense = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByExpense(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByStatusBudgetOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByStatusBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByStatusBudgetFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByStatusBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetExpenseOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = 1,
                IdExpense = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudgetExpense(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetExpenseFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = -1,
                IdExpense = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudgetExpense(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByExpenseStatusBudgetOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdExpense = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByExpenseStatusBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByExpenseStatusBudgetFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByExpenseStatusBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetExpenseStatusBudgetOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = 1,
                IdExpense = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudgetExpenseStatusBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetExpenseStatusBudgetFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = -1,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudgetExpenseStatusBudget(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBudgetDetailOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = 2,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetDetailsController!.SaveBudgetDetail(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBudgetDetailFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.SaveBudgetDetail(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateBudgetDetailFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = -1,
                IdBudget = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.UpdateBudgetDetail(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBudgetDetailOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = 1,
                IdBudget = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _budgetDetailsController!.DeleteBudgetDetail(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBudgetDetailFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = -1,
                IdBudget = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetDetailsController!.DeleteBudgetDetail(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}