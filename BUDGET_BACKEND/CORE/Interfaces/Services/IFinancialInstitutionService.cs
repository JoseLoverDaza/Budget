namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IFinancialInstitutionService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IFinancialInstitutionService
    {

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(FinancialInstitutionDto financialInstitution);

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionExtendDto SaveFinancialInstitution(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionExtendDto UpdateFinancialInstitution(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionExtendDto DeleteFinancialInstitution(FinancialInstitutionDto financialInstitution);

        #endregion

    }
}