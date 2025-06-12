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
    /// Nombre: DepositTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class DepositTest
    {

        #region  Atributos y Propiedades

        private readonly IDepositService _depositService;
        private readonly ILogApiService _logApiService;
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
            _logApiService = new LogApiService(unitOfWork);
            _depositService = new DepositService(unitOfWork, _logApiService);            
            _depositController = new DepositController(_depositService);

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

            /// FinancialInstitution IdFinancialInstitution 1
            _context.FinancialInstitutions.Add(new FinancialInstitution()
            {
                IdFinancialInstitution = 1,
                NameFinancialInstitution = "Test",
                DescriptionFinancialInstitution = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// TypeAccount IdTypeAccount 1
            _context.TypeAccounts.Add(new TypeAccount()
            {
                IdTypeAccount = 1,
                NameTypeAccount = "Test",
                DescriptionTypeAccount = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Account IdAccount 1
            _context.Accounts.Add(new Account()
            {
                IdAccount = 1,
                NameAccount = "Test",
                DescriptionAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            /// Deposit IdDeposit 1
            _context.Deposits.Add(new Deposit()
            {
                IdDeposit = 1,
                YearDeposit = 2026,
                MonthDeposit = 1,
                Amount = 1000,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetDepositByIdDepositOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = 1
            };

            ///Act
            var result = _depositController!.GetDepositByIdDeposit(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositByIdDepositFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdDeposit = -1
            };

            ///Act
            var result = _depositController!.GetDepositByIdDeposit(deposit);

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
                YearDeposit = 2026,
                MonthDeposit = 1
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
                YearDeposit = 2025,
                MonthDeposit = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonth(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearUserBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                IdUserBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearUserBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearUserBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2025,
                IdUserBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearUserBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByMonthUserBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                MonthDeposit = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByMonthUserBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByMonthUserBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                MonthDeposit = 2,
                IdUserBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByMonthUserBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                MonthDeposit = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUserBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                MonthDeposit = 1,
                IdUserBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUserBudget(deposit);

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
                YearDeposit = 2026,
                MonthDeposit = 1,
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
                YearDeposit = 2026,
                MonthDeposit = 1,
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
        public void GetDepositsByYearMonthStatusBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                MonthDeposit = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthStatusBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                MonthDeposit = 1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserBudgetAccountOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                MonthDeposit = 1,
                IdUserBudget = 1,
                IdAccount = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUserBudgetAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByYearMonthUserBudgetAccountFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                YearDeposit = 2026,
                MonthDeposit = 1,
                IdUserBudget = -1,
                IdAccount = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByYearMonthUserBudgetAccount(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUserBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByUserBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUserBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByUserBudget(deposit);

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
        public void GetDepositsByStatusBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByStatusBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByUserBudgetStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByUserBudgetStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByAccountStatusBudgetOK()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdAccount = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _depositController!.GetDepositsByAccountStatusBudget(deposit);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetDepositsByAccountStatusBudgetFail()
        {
            ///Arrange   
            DepositDto deposit = new()
            {
                IdAccount = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _depositController!.GetDepositsByAccountStatusBudget(deposit);

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
                YearDeposit = 1,
                MonthDeposit = 1,
                Amount = 1,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 1
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
                YearDeposit = 2026,
                MonthDeposit = 1,
                Amount = 1000,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 1
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
                YearDeposit = 1,
                MonthDeposit = 1,
                Amount = 1,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 1
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
                YearDeposit = 1,
                MonthDeposit = 1,
                Amount = 1,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 1
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
                YearDeposit = 1,
                MonthDeposit = 1,
                Amount = 1,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 3
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
                YearDeposit = 1,
                MonthDeposit = 1,
                Amount = 1,
                IdUserBudget = 1,
                IdAccount = 1,
                IdStatusBudget = 1
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