namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITokenApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITokenApiService
    {

        #region Métodos y Funciones

        public TokenApiExtendDto? GetTokenApiByIdTokenApi(TokenApiDto tokenApi);

        public TokenApiExtendDto? GetTokenApiByToken(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByCreationDate(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByUserBudget(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByStatusBudget(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByCreationDateStatusBudget(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateStatusBudget(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByUserBudgetStatusBudget(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByCreationDateUserBudgetStatusBudget(TokenApiDto tokenApi);

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateUserBudgetStatusBudget(TokenApiDto tokenApi);

        public TokenApiDto SaveTokenApi(TokenApiDto tokenApi);

        public TokenApiDto UpdateTokenApi(TokenApiDto tokenApi);

        public TokenApiDto DeleteTokenApi(TokenApiDto tokenApi);

        #endregion

    }
}