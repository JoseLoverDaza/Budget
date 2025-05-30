namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeAccountRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeAccountRepository
    {

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountById(int idTypeAccount);

        public TypeAccountExtendDto? GetTypeAccountByName(string name);

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(int idStatus);

        #endregion 

    }
}