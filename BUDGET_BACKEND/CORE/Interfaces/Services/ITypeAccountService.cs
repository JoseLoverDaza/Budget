namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeAccountService
    {

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountByIdTypeAccount(TypeAccountDto typeAccount);

        public TypeAccountExtendDto? GetTypeAccountByNameTypeAccount(TypeAccountDto typeAccount);

        public List<TypeAccountExtendDto> GetTypeAccountsByStatusBudget(TypeAccountDto typeAccount);

        public TypeAccountDto SaveTypeAccount(TypeAccountDto typeAccount);

        public TypeAccountDto UpdateTypeAccount(TypeAccountDto typeAccount);

        public TypeAccountDto DeleteTypeAccount(TypeAccountDto typeAccount);

        #endregion 

    }
}