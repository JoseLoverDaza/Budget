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
            _billingDetailsService = new BillingDetailsService(unitOfWork);
            _billingDetailsController = new BillingDetailsController(_billingDetailsService);

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
            _context.Billings.Add(new Billing()
            {
                IdBilling = 1,
                Year = 2026,
                Month = 1,
                CreationDate = new DateTime(2026, 1, 1),
                Description = "Test",
                IdUser = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            /// BillingDetails Id 1
            _context.BillingDetails.Add(new BillingDetails()
            {
                IdBillingDetails = 1,
                IdBilling = 1,
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
        public void GetBillingDetailsByIdOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsById(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByIdFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBillingDetails = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsById(billingDetails);

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
        public void GetBillingDetailsByStatusOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByStatus(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByStatusFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByStatus(billingDetails);

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
        public void GetBillingDetailsByExpenseStatusOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {               
                IdExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByExpenseStatus(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByExpenseStatusFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdExpense = -1,
                IdStatus = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByExpenseStatus(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingExpenseStatusOK()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = 1,
                IdExpense = 1,
                IdStatus = 1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBillingExpenseStatus(billingDetails);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingDetailsByBillingExpenseStatusFail()
        {
            ///Arrange   
            BillingDetailsDto billingDetails = new()
            {
                IdBilling = -1,
                IdExpense = -1,
                IdStatus = -1
            };

            ///Act
            var result = _billingDetailsController!.GetBillingDetailsByBillingExpenseStatus(billingDetails);

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
                IdStatus = 1
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
                IdStatus = -1
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
                IdStatus = -1
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
                IdStatus = 3
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
                IdStatus = -1
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