namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IFinancialInstitutionRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IFinancialInstitutionRepository
    {

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByIdFinancialInstitution(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByNameFinancialInstitution(FinancialInstitutionDto financialInstitution);

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatusBudget(FinancialInstitutionDto financialInstitution);

        #endregion

    }
}