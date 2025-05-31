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
    /// Nombre: TypeAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccountService : BaseService, ITypeAccountService
    {

        #region Atributos y Propiedades

        #endregion 

        #region Constructor

        public TypeAccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones
               
        public TypeAccountExtendDto? GetTypeAccountById(int idTypeAccount)
        {
            throw new NotImplementedException();
        }

        public TypeAccountExtendDto? GetTypeAccountByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public TypeAccountExtendDto SaveTypeAccount(TypeAccountExtendDto typeAccount)
        {
            throw new NotImplementedException();
        }

        public TypeAccountExtendDto UpdateTypeAccount(TypeAccountExtendDto typeAccount)
        {
            throw new NotImplementedException();
        }

        public TypeAccountExtendDto DeleteTypeAccount(TypeAccountExtendDto typeAccount)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}