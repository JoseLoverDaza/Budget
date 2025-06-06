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

        public TypeExpenseExtendDto? GetTypeExpenseById(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(typeExpense);

            if (typeExpenseSearch != null)
            {
                return typeExpenseSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeExpenseExtendDto? GetTypeExpenseByName(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByName(typeExpense);

            if (typeExpenseSearch != null)
            {
                return typeExpenseSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            List<TypeExpenseExtendDto> typeExpensesSearch = typeExpenseRepository.GetTypeExpensesByStatus(typeExpense);

            if (typeExpensesSearch.Count != 0)
            {
                return typeExpensesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeExpenseDto SaveTypeExpense(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (typeExpense == null || string.IsNullOrWhiteSpace(typeExpense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByName(typeExpense);

            if (typeExpenseSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = typeExpense.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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

        public TypeExpenseDto UpdateTypeExpense(TypeExpenseDto typeExpense)
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

            TypeExpenseExtendDto? typeExpenseDuplicado = typeExpenseRepository.GetTypeExpenseByName(typeExpense);
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(new TypeExpenseDto { IdTypeExpense = typeExpense.IdTypeExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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

        public TypeExpenseDto DeleteTypeExpense(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(typeExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = typeExpense.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeExpenseSearch.IdStatus == typeExpense.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpense deleteTypeExpense = new()
            {
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                Name = typeExpenseSearch.Name.Trim(),
                Description = typeExpenseSearch.Description?.Trim() ?? string.Empty,
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