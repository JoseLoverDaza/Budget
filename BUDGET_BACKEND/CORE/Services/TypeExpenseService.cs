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
    /// Nombre: TypeExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpenseService : BaseService, ITypeExpenseService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public TypeExpenseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseById(int idTypeExpense)
        {
            throw new NotImplementedException();
        }

        public TypeExpenseExtendDto? GetTypeExpenseByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public TypeExpenseExtendDto SaveTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            throw new NotImplementedException();
        }

        public TypeExpenseExtendDto UpdateTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            throw new NotImplementedException();
        }

        public TypeExpenseExtendDto DeleteTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            throw new NotImplementedException();
        }

        #endregion Constructor

    }
}