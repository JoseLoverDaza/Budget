namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
   
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeAccountService
    {

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountById(int idTypeAccount);

        public TypeAccountExtendDto? GetTypeAccountByName(string name);

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(int idStatus);

        public TypeAccountExtendDto SaveTypeAccount(TypeAccountExtendDto typeAccount);

        public TypeAccountExtendDto UpdateTypeAccount(TypeAccountExtendDto typeAccount);

        public TypeAccountExtendDto DeleteTypeAccount(TypeAccountExtendDto typeAccount);

        #endregion 

    }
}