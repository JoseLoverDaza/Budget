namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IFinancialInstitutionRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IFinancialInstitutionRepository
    {

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(int id);

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(string name);

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(int status);

        #endregion Methods

    }
}