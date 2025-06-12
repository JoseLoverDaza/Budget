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
    /// Nombre: TypeExpenseTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class TypeExpenseTest
    {

        #region Atributos y Propiedades

        private readonly ITypeExpenseService _typeExpenseService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly TypeExpenseController? _typeExpenseController;

        #endregion

        #region Constructor

        public TypeExpenseTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _typeExpenseService = new TypeExpenseService(unitOfWork, _logApiService);           
            _typeExpenseController = new TypeExpenseController(_typeExpenseService);

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

            /// TypeExpense IdTypeExpense 1
            _context.TypeExpenses.Add(new TypeExpense()
            {
                IdTypeExpense = 1,
                NameTypeExpense = "Test",
                DescriptionTypeExpense = "Test",
                IdStatusBudget = 2
            });

            _context.SaveChanges();

            /// TypeExpense IdTypeExpense 1
            _context.TypeExpenses.Add(new TypeExpense()
            {
                IdTypeExpense = 2,
                NameTypeExpense = "Test1",
                DescriptionTypeExpense = "Test",
                IdStatusBudget = 1
            });

            _context.SaveChanges();

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetTypeExpenseByIdTypeExpenseOK()
        {
            ///Arrange  
            TypeExpenseDto typeExpense = new()
            {
                IdTypeExpense = 1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseByIdTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpenseByIdTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                IdTypeExpense = -1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseByIdTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpenseByNameTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                NameTypeExpense = "Test"
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseByNameTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpenseByNameTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                NameTypeExpense = "T"
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpenseByNameTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpensesByStatusBudgetOK()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpensesByStatusBudget(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetTypeExpensesByStatusBudgetFail()
        {
            ///Arrange   
            TypeExpenseDto typeExpense = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _typeExpenseController!.GetTypeExpensesByStatusBudget(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                NameTypeExpense = "Test2",
                IdStatusBudget = 2
            };

            ///Act
            var result = _typeExpenseController!.SaveTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                NameTypeExpense = "Test",
                IdStatusBudget = 2
            };

            ///Act
            var result = _typeExpenseController!.SaveTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = 2,
                NameTypeExpense = "Test1",
                IdStatusBudget = 1
            };

            ///Act
            var result = _typeExpenseController!.UpdateTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = -1,
                NameTypeExpense = "Test1",
                IdStatusBudget = 1
            };

            ///Act
            var result = _typeExpenseController!.UpdateTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTypeExpenseOK()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = 1,
                NameTypeExpense = "Test1",
                IdStatusBudget = 3
            };

            ///Act
            var result = _typeExpenseController!.DeleteTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteTypeExpenseFail()
        {
            ///Arrange   
            TypeExpenseExtendDto typeExpense = new()
            {
                IdTypeExpense = -1,
                NameTypeExpense = "Test1",
                IdStatusBudget = 1
            };

            ///Act
            var result = _typeExpenseController!.DeleteTypeExpense(typeExpense);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}