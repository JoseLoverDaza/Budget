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
    /// Nombre: DepositTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class DepositTest
    {

        #region  Atributos y Propiedades

        private readonly IDepositService _depositService;
        private readonly EFContext? _context;
        private readonly DepositController? _depositController;

        #endregion

        #region Constructor

        public DepositTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _depositService = new DepositService(unitOfWork);
            _depositController = new DepositController(_depositService);

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
                Description = "Test",
                IdStatus = 1
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

            /// FinancialInstitution Id 1
            _context.FinancialInstitutions.Add(new FinancialInstitution()
            {
                IdFinancialInstitution = 1,
                Name = "Test",
                Description = "Test",
                IdStatus = 1
            });

            _context.SaveChanges();

            /// TypeAccount Id 1
            _context.TypeAccounts.Add(new TypeAccount()
            {
                IdTypeAccount = 1,
                Name = "Test",
                Description = "Test",
                IdStatus = 1
            });

            _context.SaveChanges();

            /// Account Id 1
            _context.Accounts.Add(new Account()
            {
                IdAccount = 1,
                Name = "Test",
                Description = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            /// Deposit Id 1
            _context.Deposits.Add(new Deposit()
            {
                IdDeposit = 1,
                Year = 2026,
                Month = 1,
                Amount = 1000,
                IdUser = 1,
                IdAccount = 1,               
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion Data
        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetDepositByIdOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = 1
            };

            ///Act
            var result = _depositController!.GetDepositById(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositByIdFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = -1
            };

            ///Act
            var result = _depositController!.GetDepositById(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonth(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2025,
                Month = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonth(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearUserOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                IdUser = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearUserFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2025,
                IdUser = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByMonthUserOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Month = 1,
                IdUser = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByMonthUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByMonthUserFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Month = 2,
                IdUser = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByMonthUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdUser = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdUser = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthAccountOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdAccount = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthAccountFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdAccount = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthStatusOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthStatusFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdStatus = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserAccountOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdUser = 1,
                IdAccount = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUserAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserAccountFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 2026,
                Month = 1,
                IdUser = -1,
                IdAccount = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUserAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {                
                IdUser = 1                
            };

            ///Act
            var result = _depositController!.GetDepositsByUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUser = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByUser(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByAccountOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdAccount = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByAccountFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdAccount = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByStatusOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByStatusFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserStatusOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByUserStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserStatusFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByUserStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByAccountStatusOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdAccount = 1,                
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByAccountStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByAccountStatusFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdAccount = -1,
                IdStatus = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByAccountStatus(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveDepositOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                Year = 1,
                Month = 1,
                Amount =1,
                IdUser = 1,
                IdAccount = 1,      
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.SaveDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveDepositFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = 1,
                Year = 2026,
                Month = 1,
                Amount = 1000,
                IdUser = 1,
                IdAccount = 1,
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.SaveDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateDepositOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = 1,
                Year = 1,
                Month = 1,
                Amount = 1,
                IdUser = 1,
                IdAccount = 1,
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.UpdateDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateDepositFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = -1,
                Year = 1,
                Month = 1,
                Amount = 1,
                IdUser = 1,
                IdAccount = 1,
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.UpdateDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteDepositOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = 1,
                Year = 1,
                Month = 1,
                Amount = 1,
                IdUser = 1,
                IdAccount = 1,
                IdStatus = 3
            };

            ///Act
            var result = _depositController!.DeleteDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteDepositFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = -1,
                Year = 1,
                Month = 1,
                Amount = 1,
                IdUser = 1,
                IdAccount = 1,
                IdStatus = 1
            };

            ///Act
            var result = _depositController!.DeleteDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}