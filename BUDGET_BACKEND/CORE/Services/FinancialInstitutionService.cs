namespace CORE.Services
{
   
    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitutionService : BaseService, IFinancialInstitutionService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public FinancialInstitutionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(int idFinancialInstitution)
        {
            throw new NotImplementedException();
        }

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public FinancialInstitutionExtendDto SaveFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
        {
            throw new NotImplementedException();
        }

        public FinancialInstitutionExtendDto UpdateFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
        {
            throw new NotImplementedException();
        }

        public FinancialInstitutionExtendDto DeleteFinancialInstitution(FinancialInstitutionExtendDto financialInstitution)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}