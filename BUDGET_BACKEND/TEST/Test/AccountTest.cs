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
    /// Nombre: AccountTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]

    public class AccountTest
    {

        #region  Atributos y Propiedades

        private readonly IAccountService _accountService;
        private readonly EFContext? _context;
        private readonly AccountController? _accountController;

        #endregion

        #region Constructor

        public AccountTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _accountService = new AccountService(unitOfWork);
            _accountController = new AccountController(_accountService);

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

            #endregion Data
        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetAccountByIdOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = 1
            };

            ///Act
            var result = _accountController!.GetAccountById(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountByIdFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = -1
            };

            ///Act
            var result = _accountController!.GetAccountById(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitution(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitution(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByTypeAccountOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdTypeAccount = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByTypeAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByTypeAccountFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdTypeAccount = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByTypeAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUser = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByUser(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUser = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByUser(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByStatusOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByStatusFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdStatus = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionStatusOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionStatusFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = -1,
                IdStatus = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByTypeAccountStatusOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdTypeAccount = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByTypeAccountStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByTypeAccountStatusFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdTypeAccount = -1,
                IdStatus = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByTypeAccountStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserStatusOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByUserStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserStatusFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUser = -1,
                IdStatus = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByUserStatus(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByNameFinancialInstitutionTypeAccountUserOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                Name = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByNameFinancialInstitutionTypeAccountUser(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByNameFinancialInstitutionTypeAccountUserFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                Name = "T",
                IdFinancialInstitution = -1,
                IdTypeAccount = -1,
                IdUser = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByNameFinancialInstitutionTypeAccountUser(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionTypeAccountUserOK()
        {
            ///Arrange   
            AccountDto account = new()
            {                
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionTypeAccountUser(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionTypeAccountUserFail()
        {
            ///Arrange   
            AccountDto account = new()
            {                
                IdFinancialInstitution = -1,
                IdTypeAccount = -1,
                IdUser = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionTypeAccountUser(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }


        [TestMethod]
        public void SaveAccountOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                Name = "Test2",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.SaveAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveAccountFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                Name = "Test",
                IdFinancialInstitution =1,
                IdTypeAccount = 1,
                IdUser =1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.SaveAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateAccountOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = 1,
                Name = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.UpdateAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateAccountFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = -1,
                Name = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.UpdateAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteAccountOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = 1,
                Name = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1,
                IdStatus = 3
            };

            ///Act
            var result = _accountController!.DeleteAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteAccountFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = -1,
                Name = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUser = 1,
                IdStatus = 1
            };

            ///Act
            var result = _accountController!.DeleteAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}