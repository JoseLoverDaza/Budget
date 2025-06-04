namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    
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
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            TypeExpenseExtendDto? typeExpense = typeExpenseRepository.GetTypeExpenseById(idTypeExpense);

            if (typeExpense != null)
            {
                return typeExpense;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeExpenseExtendDto? GetTypeExpenseByName(string name)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            TypeExpenseExtendDto? typeExpense = typeExpenseRepository.GetTypeExpenseByName(name);

            if (typeExpense != null)
            {
                return typeExpense;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(int idStatus)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            List<TypeExpenseExtendDto> typeExpenses = typeExpenseRepository.GetTypeExpensesByStatus(idStatus);

            if (typeExpenses.Count != 0)
            {
                return typeExpenses;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeExpenseExtendDto SaveTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (typeExpense == null || string.IsNullOrWhiteSpace(typeExpense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(typeExpense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByName(typeExpense.Name.Trim());

            if (typeExpenseSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(typeExpense.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TypeExpense saveTypeExpense = new()
            {
                Name = typeExpense.Name.Trim(),
                Description = typeExpense.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeExpense>().Add(saveTypeExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeExpense;
        }

        public TypeExpenseExtendDto UpdateTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();

            if (typeExpense == null || typeExpense.IdTypeExpense <= 0 || string.IsNullOrWhiteSpace(typeExpense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(typeExpense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseDuplicado = typeExpenseRepository.GetTypeExpenseByName(typeExpense.Name);
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(typeExpense.IdTypeExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeExpenseDuplicado != null && typeExpenseDuplicado.IdTypeExpense != typeExpense.IdTypeExpense)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpense updateTypeExpense = new()
            {
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                Name = typeExpense.Name.Trim(),
                Description = typeExpense.Description?.Trim() ?? string.Empty,
                IdStatus = typeExpenseSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeExpense>().Update(updateTypeExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeExpense;
        }

        public TypeExpenseExtendDto DeleteTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(typeExpense.IdTypeExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(typeExpense.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeExpenseSearch.IdStatus == typeExpense.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpense deleteTypeExpense = new()
            {
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                Name = typeExpenseSearch.Name.Trim(),
                Description = typeExpense.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeExpense>().Update(deleteTypeExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeExpense;
        }

        #endregion Constructor

    }
}