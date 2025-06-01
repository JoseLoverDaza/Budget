namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

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

            if (typeExpense == null || string.IsNullOrWhiteSpace(typeExpense.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(typeExpense.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByName(typeExpense.Name.Trim());

            if (typeExpenseSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpense saveTypeExpense = new()
            {
                Name = typeExpense.Name.Trim(),
                Description = typeExpense.Description!.Trim()
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

            if (!Regex.IsMatch(typeExpense.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
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
                Description = typeExpense.Description!.Trim(),
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
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseById(typeExpense.IdTypeExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TypeExpense deleteTypeExpense = new()
            {
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                Name = typeExpenseSearch.Name.Trim(),
                Description = typeExpenseSearch.Description!.Trim(),
                IdStatus = Constants.Status.INACTIVO
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