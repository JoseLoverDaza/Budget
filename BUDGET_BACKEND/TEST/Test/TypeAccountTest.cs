namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
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
        private readonly ILogApiService _logApiService;
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
            _logApiService = new LogApiService(unitOfWork);
            _typeAccountService = new TypeAccountService(unitOfWork, _logApiService);            
            _typeAccountController = new TypeAccountController(_typeAccountService);

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

            /// TypeAccount IdTypeAccount 1
            _context.TypeAccounts.Add(new TypeAccount()
            {
                IdTypeAccount = 1,
                NameTypeAccount = "Test",
                DescriptionTypeAccount = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetTypeAccountByIdTypeAccountOK()
        {
            ///Arrange           
            TypeAccountDto typeAccount = new()
            {
                IdTypeAccount = 1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountByIdTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountByIdTypeAccountFail()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                IdTypeAccount = -1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountByIdTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountByNameTypeAccountOK()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                NameTypeAccount = "Test"
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountByNameTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountByNameTypeAccountFail()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                NameTypeAccount = "T"
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountByNameTypeAccount(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountsByStatusBudgetOK()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountsByStatusBudget(typeAccount);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeAccountsByStatusBudgetFail()
        {
            ///Arrange   
            TypeAccountDto typeAccount = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _typeAccountController!.GetTypeAccountsByStatusBudget(typeAccount);

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
                NameTypeAccount = "Test1",
                IdStatusBudget = 1
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
                NameTypeAccount = "Test",
                IdStatusBudget = 1
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
                NameTypeAccount = "Test1",
                IdStatusBudget = 1
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
                NameTypeAccount = "Test1",
                IdStatusBudget = 1
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
                NameTypeAccount = "Test1",
                IdStatusBudget = 3
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
                NameTypeAccount = "Test1",
                IdStatusBudget = 1
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