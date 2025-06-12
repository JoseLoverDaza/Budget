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
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusBudgetTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class StatusBudgetTest
    {

        #region Atributos y Propiedades

        private readonly IStatusBudgetService _statusBudgetService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly StatusBudgetController? _statusBudgetController;

        #endregion 

        #region Constructor

        public StatusBudgetTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _statusBudgetService = new StatusBudgetService(unitOfWork, _logApiService);            
            _statusBudgetController = new StatusBudgetController(_statusBudgetService);

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

            #endregion Data

        }

        #endregion

        #region Métodos y Funciones

        [TestMethod]
        public void GetStatusBudgetByIdStatusBudgetOK()
        {
            ///Arrange 
            StatusBudgetDto statusBudget = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _statusBudgetController!.GetStatusBudgetByIdStatusBudget(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusBudgetByIdStatusBudgetFail()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _statusBudgetController!.GetStatusBudgetByIdStatusBudget(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusBudgetByNameStatusOK()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                NameStatus = Constants.Status.ACTIVO
            };

            ///Act
            var result = _statusBudgetController!.GetStatusBudgetByNameStatus(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusBudgetByNameStatusFail()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                NameStatus = "T"
            };

            ///Act
            var result = _statusBudgetController!.GetStatusBudgetByNameStatus(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetStatusBudgetOK()
        {
            ///Arrange   

            ///Act
            var result = _statusBudgetController!.GetStatusBudget();

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveStatusBudgetOK()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                NameStatus = "Test"
            };

            ///Act
            var result = _statusBudgetController!.SaveStatusBudget(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveStatusBudgetFail()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                IdStatusBudget = -1,
                NameStatus = Constants.Status.INACTIVO                
            };

            ///Act
            var result = _statusBudgetController!.SaveStatusBudget(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateStatusBudgetOK()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                IdStatusBudget = 1,
                NameStatus = "Test1"
            };

            ///Act
            var result = _statusBudgetController!.UpdateStatusBudget(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateStatusBudgetFail()
        {
            ///Arrange   
            StatusBudgetDto statusBudget = new()
            {
                IdStatusBudget = -1,
                NameStatus = "Test"                
            };

            ///Act
            var result = _statusBudgetController!.UpdateStatusBudget(statusBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}