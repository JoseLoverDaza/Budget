namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITokenApiRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITokenApiRepository
    {

        #region Métodos y Funciones

        public TokenApiExtendDto? GetTokenApiById(TokenApiDto tokenApi);

        public TokenApiExtendDto? GetTokenApiByToken(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByCreationDate(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByUser(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByStatus(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByCreationDateStatus(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateStatus(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByUserStatus(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByCreationDateUserStatus(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateUserStatus(TokenApiDto tokenApi);

        #endregion

    }
}