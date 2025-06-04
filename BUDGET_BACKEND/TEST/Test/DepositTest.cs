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
    /// Nombre: DepositTest   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [TestClass]
    public class DepositTest
    {

        #region  Atributos y Propiedades

        private readonly IDepositService _depositService;
        private readonly EFContext? _context;
        private readonly DepositController? _depositController;

        #endregion

        #region Constructor

        public DepositTest()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            _context = new EFContext(options);
            UnitOfWork unitOfWork = new(_context);
            _depositService = new DepositService(unitOfWork);
            _depositController = new DepositController(_depositService);

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

            /// Deposit Id 1
            _context.Deposits.Add(new Deposit()
            {
                IdDeposit = 1,
                Year = 2026,
                Month = 1,
                Amount = 1000,
                IdUser = 1,
                IdAccount = 1,               
                IdStatus = 1
            });

            _context.SaveChanges();

            #endregion Data
        }

        #endregion

    }
}