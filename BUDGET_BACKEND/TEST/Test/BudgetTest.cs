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
    /// Nombre: BudgetTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class BudgetTest
    {

        #region  Atributos y Propiedades

        private readonly IBudgetService _budgetService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly BudgetController? _budgetController;

        #endregion

        #region Constructor

        public BudgetTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _budgetService = new BudgetService(unitOfWork, _logApiService);            
            _budgetController = new BudgetController(_budgetService);

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

            /// Budget Id 1
            _context.Budgets.Add(new Budget()
            {
                YearBudget = 2026,
                MonthBudget = 1,
                CreationDate = new DateTime(2026, 1, 1),
                DescriptionBudget = "Test",
                IdUserBudget = 1,
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetBudgetByIdBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetByIdBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetByIdBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetByIdBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearMonthOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2026,
                MonthBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonth(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearMonthFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2025,
                MonthBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonth(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearUserBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2026,
                IdUserBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearUserBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2025,
                IdUserBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByMonthUserBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                MonthBudget = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByMonthUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByMonthUserBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                MonthBudget = 1,
                IdUserBudget = 2
            };

            ///Act
            var result = _budgetController!.GetBudgetsByMonthUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearMonthUserBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2026,
                MonthBudget = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonthUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearMonthUserBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2025,
                MonthBudget = 1,
                IdUserBudget = 2
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonthUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUserBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUserBudget = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUserBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByStatusBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByStatusBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByStatusBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByStatusBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUserBudgetStatusBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUserBudgetStatusBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2026,
                MonthBudget = 2,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetController!.SaveBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                YearBudget = 2026,
                MonthBudget = 2,
                CreationDate = DateTime.Now,
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetController!.SaveBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = 1,
                YearBudget = 2026,
                MonthBudget = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetController!.UpdateBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = -1,
                YearBudget = 2026,
                MonthBudget = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _budgetController!.UpdateBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBudgetOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = 1,
                YearBudget = 2026,
                MonthBudget = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _budgetController!.DeleteBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteBudgetFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = -1,
                YearBudget = 2026,
                MonthBudget = 1,
                CreationDate = DateTime.Now,
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _budgetController!.DeleteBudget(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}