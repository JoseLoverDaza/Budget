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
            _budgetDetailsService = new BudgetDetailsService(unitOfWork);
            _budgetDetailsController = new BudgetDetailsController(_budgetDetailsService);

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

            /// Role Id 1
            _context.Roles.Add(new Role()
            {
                IdRole = 1,
                Name = "Test",
                Description = "Test"
            });

            _context.SaveChanges();

            /// User Id 1
            _context.Users.Add(new User()
            {
                IdUser = 1,
                Email = "Test",
                Phone = "Test",
                Username = "Test",
                Password = "Test",
                IdRole = 1,
                IdStatus = 1
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
                IdStatus = 1
            });

            _context.SaveChanges();

            /// Billing Id 1
            _context.Budgets.Add(new Budget()
            {
                IdBudget = 1,
                Year = 2026,
                Month = 1,
                CreationDate = new DateTime(2026, 1, 1),
                Description = "Test",
                IdUser = 1,
                IdStatus = 1
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
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetBudgetDetailsByIdOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsById(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByIdFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudgetDetails = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsById(budgetDetails);

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
        public void GetBudgetDetailsByStatusOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByStatus(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByStatusFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByStatus(budgetDetails);

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
        public void GetBudgetDetailsByExpenseStatusOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {               
                IdExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByExpenseStatus(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByExpenseStatusFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdExpense = -1,
                IdStatus = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByExpenseStatus(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetExpenseStatusOK()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = 1,
                IdExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudgetExpenseStatus(budgetDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetDetailsByBudgetExpenseStatusFail()
        {
            ///Arrange   
            BudgetDetailsDto budgetDetails = new()
            {
                IdBudget = -1,
                IdExpense = -1,
                IdStatus = -1
            };

            ///Act
            var result = _budgetDetailsController!.GetBudgetDetailsByBudgetExpenseStatus(budgetDetails);

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
                IdStatus = 1
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
                IdStatus = -1
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
                IdStatus = -1
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
                IdStatus = 3
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
                IdStatus = -1
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