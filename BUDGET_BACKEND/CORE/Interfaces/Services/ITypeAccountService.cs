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

        public TypeAccountExtendDto? GetTypeAccountById(TypeAccountDto typeAccount);

        public TypeAccountExtendDto? GetTypeAccountByName(TypeAccountDto typeAccount);

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(TypeAccountDto typeAccount);

        public TypeAccountExtendDto SaveTypeAccount(TypeAccountDto typeAccount);

        public TypeAccountExtendDto UpdateTypeAccount(TypeAccountDto typeAccount);

        public TypeAccountExtendDto DeleteTypeAccount(TypeAccountDto typeAccount);

        #endregion 

    }
}