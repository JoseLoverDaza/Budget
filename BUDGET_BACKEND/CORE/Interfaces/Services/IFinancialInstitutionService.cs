namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
   
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IFinancialInstitutionService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IFinancialInstitutionService
    {

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(int idFinancialInstitution);

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(string name);

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(int idStatus);

        public FinancialInstitutionExtendDto SaveFinancialInstitution(FinancialInstitutionExtendDto financialInstitution);

        public FinancialInstitutionExtendDto UpdateFinancialInstitution(FinancialInstitutionExtendDto financialInstitution);

        public FinancialInstitutionExtendDto DeleteFinancialInstitution(FinancialInstitutionExtendDto financialInstitution);

        #endregion

    }
}