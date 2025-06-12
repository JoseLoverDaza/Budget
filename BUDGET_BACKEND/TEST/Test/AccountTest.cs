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
    /// Nombre: AccountTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class AccountTest
    {

        #region  Atributos y Propiedades

        private readonly IAccountService _accountService;
        private readonly ILogApiService _logApiService;
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
            _logApiService = new LogApiService(unitOfWork);
            _accountService = new AccountService(unitOfWork, _logApiService);            
            _accountController = new AccountController(_accountService);

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

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetAccountByIdAccountOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = 1
            };

            ///Act
            var result = _accountController!.GetAccountByIdAccount(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountByIdAccountFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdAccount = -1
            };

            ///Act
            var result = _accountController!.GetAccountByIdAccount(account);

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
        public void GetAccountsByUserBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUserBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByUserBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUserBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByUserBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByStatusBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByStatusBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionStatusBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionStatusBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByTypeAccountStatusBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdTypeAccount = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByTypeAccountStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByTypeAccountStatusBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdTypeAccount = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByTypeAccountStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserBudgetStatusBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUserBudget = 1,
                IdStatusBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByUserBudgetStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByUserBudgetStatusBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdUserBudget = -1,
                IdStatusBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByUserBudgetStatusBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByNameFinancialInstitutionTypeAccountUserBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                NameAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByNameFinancialInstitutionTypeAccountUserBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                NameAccount = "T",
                IdFinancialInstitution = -1,
                IdTypeAccount = -1,
                IdUserBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByNameFinancialInstitutionTypeAccountUserBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionTypeAccountUserBudgetOK()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionTypeAccountUserBudget(account);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetAccountsByFinancialInstitutionTypeAccountUserBudgetFail()
        {
            ///Arrange   
            AccountDto account = new()
            {
                IdFinancialInstitution = -1,
                IdTypeAccount = -1,
                IdUserBudget = -1
            };

            ///Act
            var result = _accountController!.GetAccountsByFinancialInstitutionTypeAccountUserBudget(account);

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
                NameAccount = "Test2",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 1
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
                NameAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 1
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
                NameAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 1
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
                NameAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 1
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
                NameAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 3
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
                NameAccount = "Test",
                IdFinancialInstitution = 1,
                IdTypeAccount = 1,
                IdUserBudget = 1,
                IdStatusBudget = 1
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