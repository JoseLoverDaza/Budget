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
    /// Nombre: UserTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class UserTest
    {

        #region  Atributos y Propiedades

        private readonly IUserBudgetService _userService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly UserController? _userController;

        #endregion

        #region Constructor

        public UserTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _userService = new UserService(unitOfWork, _logApiService);            
            _userController = new UserController(_userService);

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
                Description = "Test",
                IdStatus = 1
            });

            _context.SaveChanges();

            /// User Id 1
            _context.Users.Add(new User()
            {
                IdUser = 1,
                Email = "Test",
                Phone = "1234567890",
                Username = "Test",
                Password = "A7Ws/sQDVsXXi/xheT1IufcXPN5rJUKXmPWvnJTGzjRgOzD+vAt1GAMXoD0/mlrD",
                IdRole = 1,
                IdStatus = 1
            });

            _context.SaveChanges();

            /// User Id 2
            _context.Users.Add(new User()
            {
                IdUser = 2,
                Email = "Test",
                Phone = "1234567890",
                Username = "Test1",
                Password = "Test",
                IdRole = 1,
                IdStatus = 2
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetUserByIdOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdUser = 1
            };

            ///Act
            var result = _userController!.GetUserById(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRoleByIdFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdUser = -1
            };

            ///Act
            var result = _userController!.GetUserById(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByEmailOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                Email = "Test"
            };

            ///Act
            var result = _userController!.GetUserByEmail(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByEmailFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                Email = "T"
            };

            ///Act
            var result = _userController!.GetUserByEmail(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByUsernameOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                Username = "Test"
            };

            ///Act
            var result = _userController!.GetUserByUsername(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByUsernameFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                Username = "T"
            };

            ///Act
            var result = _userController!.GetUserByUsername(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdRole = 1
            };

            ///Act
            var result = _userController!.GetUsersByRole(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdRole = -1
            };

            ///Act
            var result = _userController!.GetUsersByRole(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByStatusOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _userController!.GetUsersByStatus(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByStatusFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _userController!.GetUsersByStatus(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleStatusOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdStatus = 1,
                IdRole = 1
            };

            ///Act
            var result = _userController!.GetUsersByRoleStatus(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleStatusFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdStatus = -1,
                IdRole = -1
            };

            ///Act
            var result = _userController!.GetUsersByRoleStatus(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveUserOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                Email = "Test1",
                Phone = "Test1",
                Username = "Test2",
                Password = "Test",
                IdRole = 1,
                IdStatus = 1
            };

            ///Act
            var result = _userController!.SaveUser(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveUserFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                Email = "Test",
                Phone = "Test",
                Username = "Test",
                Password = "Test",
                IdRole = 1,
                IdStatus = 1
            };

            ///Act
            var result = _userController!.SaveUser(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateUserOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdUser = 1,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test",
                Password = "Test",
                IdRole = 1,
                IdStatus = 1
            };

            ///Act
            var result = _userController!.UpdateUser(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateUserFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdUser = -1,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test1",
                Password = "Test",
                IdRole = 1,
                IdStatus = 1
            };

            ///Act
            var result = _userController!.UpdateUser(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteUserOK()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdUser = 2,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test1",
                Password = "Test",
                IdRole = 1,
                IdStatus = 3
            };

            ///Act
            var result = _userController!.DeleteUser(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteUserFail()
        {
            ///Arrange   
            UserDto user = new()
            {
                IdUser = -1,
                Email = "Test1",
                Phone = "Test1",
                Username = "Test1",
                Password = "Test",
                IdRole = 1,
                IdStatus = 1
            };

            ///Act
            var result = _userController!.DeleteUser(user);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}