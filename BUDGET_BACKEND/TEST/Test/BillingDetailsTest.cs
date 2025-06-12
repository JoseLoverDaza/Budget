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
    /// Nombre: BillingDetailsTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class BillingDetailsTest
    {

        #region  Atributos y Propiedades

        private readonly IBillingDetailsService _billingDetailsService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly BillingDetailsController? _billingDetailsController;

        #endregion

        #region Constructor

        public BillingDetailsTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _billingDetailsService = new BillingDetailsService(unitOfWork, _logApiService);            
            _billingDetailsController = new BillingDetailsController(_billingDetailsService);

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
                Username = "Test",
                EncryptedPassword = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRoleBudget = 1,
                IdStatusBudget = 1
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

            /// Expense IdExpense 2
            _context.Expenses.Add(new Expense()
            {
                IdExpense = 2,
                NameExpense = "Test1",
                DescriptionExpense = "Test",
                IdTypeExpense = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Billing IdBilling 1
            _context.Billings.Add(new Billing()
            {
                IdBilling = 1,
                YearBilling = 2026,
                MonthBilling = 1,
                CreationDate = new DateTime(2026, 1, 1),
                DescriptionBilling = "Test",
                IdUserBudget = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// BillingDetails IdBillingDetails 1
            _context.BillingDetails.Add(new BillingDetails()
            {
                IdBillingDetails = 1,
                IdBilling = 1,
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
        public void GetBillingDetailsByIdBillingDetailsOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByIdBillingDetails(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByIdBillingDetailsFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByIdBillingDetails(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBilling(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBilling(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByExpenseOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdExpense = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByExpense(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByExpenseFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdExpense = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByExpense(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByStatusBudgetOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByStatusBudget(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByStatusBudgetFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByStatusBudget(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingExpenseOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = 1,
                IdExpense = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBillingExpense(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingExpenseFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = -1,
                IdExpense = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBillingExpense(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByExpenseStatusBudgetOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdExpense = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByExpenseStatusBudget(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByExpenseStatusBudgetFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByExpenseStatusBudget(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingExpenseStatusBudgetOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = 1,
                IdExpense = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBillingExpenseStatusBudget(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingExpenseStatusBudgetFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = -1,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBillingExpenseStatusBudget(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBillingDetailOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = 2,
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingDetailsController!.SaveBillingDetail(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBillingDetailFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingDetailsController!.SaveBillingDetail(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateBillingDetailFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = -1,
                IdBilling = -1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingDetailsController!.UpdateBillingDetail(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBillingDetailOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = 1,
                IdBilling = 1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _billingDetailsController!.DeleteBillingDetail(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBillingDetailFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = -1,
                IdBilling = -1,
                CreationDate = DateTime.Now,
                Amount = 1000,
                IdExpense = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingDetailsController!.DeleteBillingDetail(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}