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
    /// Nombre: UserBudgetTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class UserBudgetTest
    {

        #region  Atributos y Propiedades

        private readonly IUserBudgetService _userBudgetService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly UserBudgetController? _userBudgetController;

        #endregion

        #region Constructor

        public UserBudgetTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _userBudgetService = new UserBudgetService(unitOfWork, _logApiService);            
            _userBudgetController = new UserBudgetController(_userBudgetService);

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

            /// User Id 2
            _context.UsersBudget.Add(new UserBudget()
            {
                IdUserBudget = 2,
                Email = "Test",
                Phone = "1234567890",
                Username = "Test",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetUserBudgetByIdUserBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdUserBudget = 1
            };

            ///Act
            var result = _userBudgetController!.GetUserBudgetByIdUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserBudgetByIdUserBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdUserBudget = -1
            };

            ///Act
            var result = _userBudgetController!.GetUserBudgetByIdUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserBudgetByEmailOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                Email = "Test"
            };

            ///Act
            var result = _userBudgetController!.GetUserBudgetByEmail(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserBudgetByEmailFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                Email = "T"
            };

            ///Act
            var result = _userBudgetController!.GetUserBudgetByEmail(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserBudgetByUsernameOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                Username = "Test"
            };

            ///Act
            var result = _userBudgetController!.GetUserBudgetByUsername(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserBudgetByUsernameFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                Username = "T"
            };

            ///Act
            var result = _userBudgetController!.GetUserBudgetByUsername(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersBudgetByRoleBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdRoleBudget = 1
            };

            ///Act
            var result = _userBudgetController!.GetUsersBudgetByRoleBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersBudgetByRoleBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdRoleBudget = -1
            };

            ///Act
            var result = _userBudgetController!.GetUsersBudgetByRoleBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersBudgetByStatusBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _userBudgetController!.GetUsersBudgetByStatusBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersBudgetByStatusBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _userBudgetController!.GetUsersBudgetByStatusBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersBudgetByRoleBudgetStatusBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdStatusBudget = 1,
                IdRoleBudget  = 1
            };

            ///Act
            var result = _userBudgetController!.GetUsersBudgetByRoleBudgetStatusBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersBudgetByRoleBudgetStatusBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdStatusBudget = -1,
                IdRoleBudget = -1
            };

            ///Act
            var result = _userBudgetController!.GetUsersBudgetByRoleBudgetStatusBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveUserBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                Email = "Test1",
                Phone = "Test1",
                Username = "Test2",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _userBudgetController!.SaveUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveUserBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                Email = "Test",
                Phone = "Test",
                Username = "Test",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _userBudgetController!.SaveUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateUserBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdUserBudget = 2,
                Email = "Test2",
                Phone = "Test2",
                Username = "Test",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _userBudgetController!.UpdateUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateUserBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdUserBudget = -1,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test1",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _userBudgetController!.UpdateUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteUserBudgetOK()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdUserBudget = 2,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test1",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 3
            };

            ///Act
            var result = _userBudgetController!.DeleteUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteUserBudgetFail()
        {
            ///Arrange   
            UserBudgetDto userBudget = new()
            {
                IdUserBudget = -1,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test1",
                EncryptedPassword = "Test",
                IdRoleBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _userBudgetController!.DeleteUserBudget(userBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}