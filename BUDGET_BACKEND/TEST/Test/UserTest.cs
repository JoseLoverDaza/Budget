namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using Domain.Context;
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

        private readonly IUserService _userService;
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
            _userService = new UserService(unitOfWork);
            _userController = new UserController(_userService);

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
                Phone = "1234567890",
                Login = "Test",                 
                Password = "Test",
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
                Login = "Test1",
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
            int Id = 1;

            ///Act
            var result = _userController!.GetUserById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRoleByIdFail()
        {
            ///Arrange   
            int Id = -1;

            ///Act
            var result = _userController!.GetUserById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByEmailOK()
        {
            ///Arrange   
            string Email = "Test";

            ///Act
            var result = _userController!.GetUserByEmail(Email);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByEmailFail()
        {
            ///Arrange   
            string Email = "T";

            ///Act
            var result = _userController!.GetUserByEmail(Email);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByLoginOK()
        {
            ///Arrange   
            string Login = "Test";

            ///Act
            var result = _userController!.GetUserByLogin(Login);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUserByLoginFail()
        {
            ///Arrange   
            string Login = "T";

            ///Act
            var result = _userController!.GetUserByLogin(Login);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleOK()
        {
            ///Arrange   
            int IdRole = 1;

            ///Act
            var result = _userController!.GetUsersByRole(IdRole);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleFail()
        {
            ///Arrange   
            int IdRole = -1;

            ///Act
            var result = _userController!.GetUsersByRole(IdRole);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByStatusOK()
        {
            ///Arrange   
            int IdStatus = 1;

            ///Act
            var result = _userController!.GetUsersByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByStatusFail()
        {
            ///Arrange   
            int IdStatus = -1;

            ///Act
            var result = _userController!.GetUsersByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleStatusOK()
        {
            ///Arrange   
            int IdRole = 1;
            int IdStatus = 1;

            ///Act
            var result = _userController!.GetUsersByRoleStatus(IdRole, IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetUsersByRoleStatusFail()
        {
            ///Arrange   
            int IdRole = -1;
            int IdStatus = -1;

            ///Act
            var result = _userController!.GetUsersByRoleStatus(IdRole, IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveUserOK()
        {
            ///Arrange   
            UserExtendDto user = new()
            {
                Email = "Test1",
                Phone = "Test1",
                Login = "Test2",
                Password = "Test1",
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
            UserExtendDto user = new()
            {                
                Email = "Test",
                Phone = "Test",
                Login = "Test",
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
            UserExtendDto user = new()
            {
                IdUser = 1,
                Email = "Test1",
                Phone = "Test1",
                Login = "Test",
                Password = "Test1",
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
            UserExtendDto user = new()
            {
                IdUser = -1,
                Email = "Test1",
                Phone = "Test1",
                Login = "Test1",
                Password = "Test1",
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
            UserExtendDto user = new()
            {
                IdUser = 2,
                Email = "Test1",
                Phone = "Test1",
                Login = "Test1",
                Password = "Test1",
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
            UserExtendDto user = new()
            {
                IdUser = -1,
                Email = "Test1",
                Phone = "Test1",
                Login = "Test1",
                Password = "Test1",
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