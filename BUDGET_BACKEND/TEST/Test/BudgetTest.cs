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

            /// Budget Id 1
            _context.Budgets.Add(new Budget()
            {
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
        public void GetBudgetByIdOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetById(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetByIdFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdBudget = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetById(budget);

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
                Year = 2026,
                Month = 1
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
                Year = 2025,
                Month = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonth(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearUserOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                Year = 2026,
                IdUser = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearUserFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                Year = 2025,
                IdUser = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByMonthUserOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                Month = 1,
                IdUser = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByMonthUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByMonthUserFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                Month = 1,
                IdUser = 2
            };

            ///Act
            var result = _budgetController!.GetBudgetsByMonthUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearMonthUserOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                Year = 2026,
                Month = 1,
                IdUser = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonthUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByYearMonthUserFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                Year = 2025,
                Month = 1,
                IdUser = 2
            };

            ///Act
            var result = _budgetController!.GetBudgetsByYearMonthUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUser = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUser = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUser(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByStatusOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByStatus(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByStatusFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByStatus(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserStatusOK()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUserStatus(budget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetBudgetsByUserStatusFail()
        {
            ///Arrange   
            BudgetDto budget = new()
            {
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _budgetController!.GetBudgetsByUserStatus(budget);

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
                Year = 2026,
                Month = 2,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 1
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
                Year = 2026,
                Month = 2,
                CreationDate = DateTime.Now,
                IdUser = -1,
                IdStatus = -1
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 1
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = -1,
                IdStatus = -1
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 3
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
                Year = 2026,
                Month = 1,
                CreationDate = DateTime.Now,
                IdUser = 1,
                IdStatus = 1
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