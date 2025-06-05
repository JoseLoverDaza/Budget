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

        public FinancialInstitutionDto SaveFinancialInstitution(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionDto UpdateFinancialInstitution(FinancialInstitutionDto financialInstitution);

        public FinancialInstitutionDto DeleteFinancialInstitution(FinancialInstitutionDto financialInstitution);

        #endregion

    }
}