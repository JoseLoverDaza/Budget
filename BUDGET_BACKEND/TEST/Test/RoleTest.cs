namespace TEST.Test
{

    #region Librerias

    using API.Controllers;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using Domain.Context;
    using Domain.Entities;
    using INFRAESTRUCTURE.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class RoleTest
    {

        #region Atributos y Propiedades

        private readonly IRoleService _roleService;      
        private readonly EFContext? _context;
        private readonly RoleController? _roleController;

        #endregion

        #region Constructor

        public RoleTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);            
            _roleService = new RoleService(unitOfWork);           
            _roleController = new RoleController(_roleService);

            #region Data

            /// Status Id 1
            _context.Status.Add(new Status()
            {
                IdStatus = 1,
                Name = "Test",
                Description = "Test"
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

            #endregion Data

        }

        #endregion 

        #region Métodos y Funciones

        [TestMethod]
        public void GetRoleByIdOK()
        {
            ///Arrange   
            int Id = 1;

            ///Act
            var result = _roleController!.GetRoleById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Code == HttpStatusCode.OK.GetHashCode());
        }

        [TestMethod]
        public void GetRoleByIdFail()
        {
            ///Arrange   
            int Id = -1;

            ///Act
            var result = _roleController!.GetRoleById(Id);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Code == HttpStatusCode.InternalServerError.GetHashCode());
        }

        [TestMethod]
        public void GetRoleByNameOK()
        {
            ///Arrange   
            string Name = "Test";

            ///Act
            var result = _roleController!.GetRoleByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Code == HttpStatusCode.OK.GetHashCode());
        }

        [TestMethod]
        public void GetRoleByNameFail()
        {
            ///Arrange   
            string Name = "";

            ///Act
            var result = _roleController!.GetRoleByName(Name);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Code == HttpStatusCode.InternalServerError.GetHashCode());
        }

        [TestMethod]
        public void GetRolesOK()
        {
            ///Arrange   
            int IdStatus = 1;

            ///Act
            var result = _roleController!.GetRolesByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Code == HttpStatusCode.OK.GetHashCode());
        }

        [TestMethod]
        public void GetRolesFail()
        {
            ///Arrange   
            int IdStatus = -1;

            ///Act
            var result = _roleController!.GetRolesByStatus(IdStatus);

            ///Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Code == HttpStatusCode.InternalServerError.GetHashCode());
        }

        #endregion

    }
}