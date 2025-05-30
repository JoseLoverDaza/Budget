﻿namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IDepositService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IDepositService
    {

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(int idDeposit);

        public List<DepositExtendDto> GetDepositsByYearMonth(int year, int month);

        public List<DepositExtendDto> GetDepositsByYearMonthUser(int year, int month, int idUser);

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(int year, int month, int idAccount);

        public List<DepositExtendDto> GetDepositsByYearMonthStatus(int year, int month, int idStatus);

        public List<DepositExtendDto> GetDepositsByUser(int idUser);

        public List<DepositExtendDto> GetDepositsByAccount(int idAccount);

        public List<DepositExtendDto> GetDepositsByStatus(int idStatus);

        public List<DepositExtendDto> GetDepositsByUserStatus(int idUser, int idStatus);

        public List<DepositExtendDto> GetDepositsByAccountStatus(int idAccount, int idStatus);

        public DepositExtendDto SaveDeposit(DepositExtendDto deposit);

        public DepositExtendDto UpdateDeposit(DepositExtendDto deposit);

        public DepositExtendDto DeleteDeposit(DepositExtendDto deposit);

        #endregion

    }
}