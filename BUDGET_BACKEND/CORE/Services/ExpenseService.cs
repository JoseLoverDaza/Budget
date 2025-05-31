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
    /// Nombre: ExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseService : BaseService, IExpenseService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public ExpenseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseById(int idExpense)
        {
            throw new NotImplementedException();
        }

        public ExpenseExtendDto? GetExpenseByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<ExpenseExtendDto> GetExpensesByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public ExpenseExtendDto SaveExpense(ExpenseExtendDto expense)
        {
            throw new NotImplementedException();
        }

        public ExpenseExtendDto UpdateExpense(ExpenseExtendDto expense)
        {
            throw new NotImplementedException();
        }

        public ExpenseExtendDto DeleteExpense(ExpenseExtendDto expense)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}