namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using Domain.Context;
    using Domain.Dto;
    using Domain.Entities;
    using INFRAESTRUCTURE.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeAccountTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class TypeAccountTest
    {

        #region Atributos y Propiedades

        private readonly ITypeAccountService _typeAccountService;
        private readonly EFContext? _context;
        private readonly TypeAccountController? _typeAccountController;

        #endregion

        #region Constructor

        public TypeAccountTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _typeAccountService = new TypeAccountService(unitOfWork);
            _typeAccountController = new TypeAccountController(_typeAccountService);

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

            /// TypeAccount Id 1
            _context.TypeAccounts.Add(new TypeAccount()
            {
                IdTypeAccount = 1,
                Name = "Test",
                Description = "Test",
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetTypeAccountByIdOK()
        {
            ///Arrange           
            TypeAccountDto typeAccount = new()
            {
                IdTypeAccount = 1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountById(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountByIdFail()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                IdTypeAccount = -1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountById(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountByNameOK()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                Name = "Test"
            };
           
            ///Act
            var result = _typeAccountController!.GetTypeAccountByName(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountByNameFail()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                Name = "T"
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountByName(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountsByStatusOK()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                IdStatus = 1
            };
            
            ///Act
            var result = _typeAccountController!.GetTypeAccountsByStatus(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountsByStatusFail()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountsByStatus(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTypeAccountOK()
        {
            ///Arrange   
            TypeAccountExtendDto typeAccount = new()
            {
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeAccountController!.SaveTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTypeAccountFail()
        {
            ///Arrange   
            TypeAccountExtendDto typeAccount = new()
            {
                Name = "Test",
                IdStatus = 1
            };

            ///Act
            var result = _typeAccountController!.SaveTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTypeAccountOK()
        {
            ///Arrange   
            TypeAccountExtendDto typeAccount = new()
            {
                IdTypeAccount = 1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeAccountController!.UpdateTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTypeAccountFail()
        {
            ///Arrange   
            TypeAccountExtendDto typeAccount = new()
            {
                IdTypeAccount = -1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeAccountController!.UpdateTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTypeAccountOK()
        {
            ///Arrange   
            TypeAccountExtendDto typeAccount = new()
            {
                IdTypeAccount = 1,
                Name = "Test1",
                IdStatus = 3
            };

            ///Act
            var result = _typeAccountController!.DeleteTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTypeAccountFail()
        {
            ///Arrange   
            TypeAccountExtendDto typeAccount = new()
            {
                IdTypeAccount = -1,
                Name = "Test1",
                IdStatus = 1
            };

            ///Act
            var result = _typeAccountController!.DeleteTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}