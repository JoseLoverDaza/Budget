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
    /// Nombre: BudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetService : BaseService, IBudgetService
    {

        #region #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BudgetService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetById(int idBudget)
        {
            throw new NotImplementedException();
        }

        public BudgetExtendDto? GetBudgetByYearMonthUser(int year, int month, int idUser)
        {
            throw new NotImplementedException();
        }

        public List<BudgetExtendDto> GetBudgetsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<BudgetExtendDto> GetBudgetsByUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public List<BudgetExtendDto> GetBudgetsByUserStatus(int idUser, int idStatus)
        {
            throw new NotImplementedException();
        }

        public BudgetExtendDto SaveBudget(BudgetExtendDto budget)
        {
            throw new NotImplementedException();
        }

        public BudgetExtendDto UpdateBudget(BudgetExtendDto budget)
        {
            throw new NotImplementedException();
        }

        public BudgetExtendDto DeleteBudget(BudgetExtendDto budget)
        {
            throw new NotImplementedException();
        }

        #endregion Constructor

    }
}