namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IFinancialInstitutionRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IFinancialInstitutionRepository
    {

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(int idFinancialInstitution);

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(string name);

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(int idStatus);

        #endregion

    }
}