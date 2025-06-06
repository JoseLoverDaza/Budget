namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Interfaces.Services;
    using CORE.Services;
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
            _billingService = new BillingService(unitOfWork);
            _billingController = new BillingController(_billingService);

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
                Login = "Test",
                Password = "Test",
                IdRole = 1,
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

            #endregion

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetBillingByIdOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = 1
            };

            ///Act
            var result = _billingController!.GetBillingById(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingByIdFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdBilling = -1
            };

            ///Act
            var result = _billingController!.GetBillingById(billing);

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
                Year = 2026,
                Month = 1
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
                Year = 2025,
                Month = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonth(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearUserOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                Year = 2026,
                IdUser = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearUserFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                Year = 2025,
                IdUser = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByMonthUserOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                Month = 1,
                IdUser = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByMonthUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByMonthUserFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                Month = 1,
                IdUser = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByMonthUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearMonthUserOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                Year = 2026,
                Month = 1,
                IdUser = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonthUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByYearMonthUserFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                Year = 2025,
                Month = 1,
                IdUser = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByYearMonthUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {                
                IdUser = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {               
                IdUser = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByUser(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByStatusOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByStatus(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByStatusFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByStatus(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserStatusOK()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _billingController!.GetBillingsByUserStatus(billing);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBillingsByUserStatusFail()
        {
            ///Arrange   
            BillingDto billing = new()
            {
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _billingController!.GetBillingsByUserStatus(billing);

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
                Year = 2026,
                Month = 2,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 1
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
                Year = 2026,
                Month = 2,
                CreationDate = DateTime.Now,
                IdUser = -1,
                IdStatus = -1
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 1
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = -1,
                IdStatus = -1
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 3
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 3
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
