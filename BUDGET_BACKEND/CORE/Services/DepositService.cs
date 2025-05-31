namespace CORE.Services
{
    
    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositService : BaseService, IDepositService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public DepositService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(int idDeposit)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByAccount(int idAccount)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByAccountStatus(int idAccount, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByUserStatus(int idUser, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(int year, int month)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(int year, int month, int idAccount)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatus(int year, int month, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUser(int year, int month, int idUser)
        {
            throw new NotImplementedException();
        }

        public DepositExtendDto SaveDeposit(DepositExtendDto deposit)
        {
            throw new NotImplementedException();
        }

        public DepositExtendDto UpdateDeposit(DepositExtendDto deposit)
        {
            throw new NotImplementedException();
        }

        public DepositExtendDto DeleteDeposit(DepositExtendDto deposit)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}