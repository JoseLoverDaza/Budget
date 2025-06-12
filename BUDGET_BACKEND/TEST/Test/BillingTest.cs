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
    /// Nombre: BillingTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class BillingTest
    {

        #region  Atributos y Propiedades

        private readonly IBillingService _billingService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly BillingController? _billingController;

        #endregion

        #region Constructor

        public BillingTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _billingService = new BillingService(unitOfWork, _logApiService);            
            _billingController = new BillingController(_billingService);

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

            #endregion

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetBillingByIdBillingOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = 1
            };

            ///Act
            var result = _billingController!.GetBillingByIdBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingByIdBillingFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = -1
            };

            ///Act
            var result = _billingController!.GetBillingByIdBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearMonthOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2026,
                MonthBilling = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonth(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearMonthFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2025,
                MonthBilling = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonth(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearUserBudgetOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2026,
                IdUserBudget = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearUserBudgetFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2025,
                IdUserBudget = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByMonthUserBudgetOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                MonthBilling = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByMonthUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByMonthUserBudgetFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                MonthBilling = 1,
                IdUserBudget = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByMonthUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearMonthUserBudgetOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2026,
                MonthBilling = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonthUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearMonthUserBudgetFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2025,
                MonthBilling = 1,
                IdUserBudget = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonthUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserBudgetOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdUserBudget = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserBudgetFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdUserBudget = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByUserBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByStatusBudgetOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByStatusBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByStatusBudgetFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByStatusBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByUserBudgetStatusBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByUserBudgetStatusBudget(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBillingOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2026,
                MonthBilling = 2,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingController!.SaveBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBillingFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                YearBilling = 2026,
                MonthBilling = 2,
                CreationDate = DateTime.Now,
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingController!.SaveBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateBillingOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = 1,
                YearBilling = 2026,
                MonthBilling = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _billingController!.UpdateBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateBillingFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = -1,
                YearBilling = 2026,
                MonthBilling = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _billingController!.UpdateBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBillingOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = 1,
                YearBilling = 2026,
                MonthBilling = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _billingController!.DeleteBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBillingFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = -1,
                YearBilling = 2026,
                MonthBilling = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _billingController!.DeleteBilling(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}
