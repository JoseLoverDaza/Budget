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
    /// Nombre: RoleBudgetTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class RoleBudgetTest
    {

        #region Atributos y Propiedades

        private readonly IRoleBudgetService _roleBudgetService;
        private readonly ILogApiService _logApiService;
        private readonly EFContext? _context;
        private readonly RoleBudgetController? _roleBudgetController;

        #endregion

        #region Constructor

        public RoleBudgetTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _logApiService = new LogApiService(unitOfWork);
            _roleBudgetService = new RoleBudgetService(unitOfWork, _logApiService);            
            _roleBudgetController = new RoleBudgetController(_roleBudgetService);

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

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetRoleBudgetByIdRoleBudgetOK()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdRoleBudget = 1
            };

            ///Act
            var result = _roleBudgetController!.GetRoleBudgetByIdRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRoleBudgetByIdRoleBudgetFail()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdRoleBudget = -1
            };

            ///Act
            var result = _roleBudgetController!.GetRoleBudgetByIdRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRoleBudgetByNameRoleOK()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                NameRole = "Test"
            };

            ///Act
            var result = _roleBudgetController!.GetRoleBudgetByNameRole(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRoleBudgetByNameRoleFail()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                NameRole = "T"
            };

            ///Act
            var result = _roleBudgetController!.GetRoleBudgetByNameRole(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRolesBudgetByStatusBudgetOK()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdStatusBudget = 1
            };

            ///Act
            var result = _roleBudgetController!.GetRolesBudgetByStatusBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void GetRolesBudgetByStatusBudgetFail()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdStatusBudget = -1
            };

            ///Act
            var result = _roleBudgetController!.GetRolesBudgetByStatusBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveRoleBudgetOK()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdStatusBudget = 1,
                NameRole = "Test1"               
            };

            ///Act
            var result = _roleBudgetController!.SaveRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void SaveRoleBudgetFail()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdStatusBudget = 1,
                NameRole = "Test"                
            };

            ///Act
            var result = _roleBudgetController!.SaveRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateRoleBudgetOK()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdRoleBudget = 1,
                NameRole = "Test1",
                IdStatusBudget = 1
            };

            ///Act
            var result = _roleBudgetController!.UpdateRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void UpdateRoleBudgetFail()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdRoleBudget = -1,
                NameRole = "Test1",
                IdStatusBudget = 1
            };

            ///Act
            var result = _roleBudgetController!.UpdateRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteRoleBudgetOK()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdRoleBudget = 1,
                NameRole = "Test1",
                IdStatusBudget = 3
            };

            ///Act
            var result = _roleBudgetController!.DeleteRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(HttpStatusCode.OK.GetHashCode(), result.Code);
        }

        [TestMethod]
        public void DeleteRoleBudgetFail()
        {
            ///Arrange   
            RoleBudgetDto roleBudget = new()
            {
                IdRoleBudget = -1,
                NameRole = "Test1",
                IdStatusBudget = 1
            };

            ///Act
            var result = _roleBudgetController!.DeleteRoleBudget(roleBudget);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.AreEqual(HttpStatusCode.InternalServerError.GetHashCode(), result.Code);
        }

        #endregion

    }
}