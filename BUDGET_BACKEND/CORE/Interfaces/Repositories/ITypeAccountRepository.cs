﻿namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeAccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeAccountRepository
    {

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountByIdTypeAccount(TypeAccountDto typeAccount);

        public TypeAccountExtendDto? GetTypeAccountByNameTypeAccount(TypeAccountDto typeAccount);

        public List<TypeAccountExtendDto> GetTypeAccountsByStatusBudget(TypeAccountDto typeAccount);

        #endregion 

    }
}