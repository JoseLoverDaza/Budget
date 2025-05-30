namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeAccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeAccountRepository
    {

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountById(int id);

        public TypeAccountExtendDto? GetTypeAccountByName(string name);

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(int status);

        #endregion 

    }
}