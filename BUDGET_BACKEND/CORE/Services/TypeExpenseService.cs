﻿namespace CORE.Services
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
    using System.Security.Principal;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpenseService : BaseService, ITypeExpenseService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public TypeExpenseService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseByIdTypeExpense(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByIdTypeExpense(typeExpense);

            _logApiService.TraceLog(typeof(TypeExpense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(typeExpense), DateTime.Now, null);

            if (typeExpenseSearch != null)
            {
                return typeExpenseSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeExpenseExtendDto? GetTypeExpenseByNameTypeExpense(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByNameTypeExpense(typeExpense);

            _logApiService.TraceLog(typeof(TypeExpense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(typeExpense), DateTime.Now, null);

            if (typeExpenseSearch != null)
            {
                return typeExpenseSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatusBudget(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            List<TypeExpenseExtendDto> typeExpensesSearch = typeExpenseRepository.GetTypeExpensesByStatusBudget(typeExpense);

            _logApiService.TraceLog(typeof(TypeExpense).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(typeExpense), DateTime.Now, null);

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
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (typeExpense == null || string.IsNullOrWhiteSpace(typeExpense.NameTypeExpense.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByNameTypeExpense(typeExpense);

            if (typeExpenseSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = typeExpense.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TypeExpense saveTypeExpense = new()
            {
                NameTypeExpense = typeExpense.NameTypeExpense.Trim(),
                DescriptionTypeExpense = typeExpense.DescriptionTypeExpense?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = typeExpense.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = typeExpense.ModificationDate
            };

            UnitOfWork.BaseRepository<TypeExpense>().Add(saveTypeExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TypeExpense).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveTypeExpense), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return typeExpense;
        }

        public TypeExpenseDto UpdateTypeExpense(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();

            if (typeExpense == null || typeExpense.IdTypeExpense <= 0 || string.IsNullOrWhiteSpace(typeExpense.NameTypeExpense.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(typeExpense.NameTypeExpense.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpenseExtendDto? typeExpenseDuplicado = typeExpenseRepository.GetTypeExpenseByNameTypeExpense(typeExpense);
            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByIdTypeExpense(new TypeExpenseDto { IdTypeExpense = typeExpense.IdTypeExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeExpenseDuplicado != null && typeExpenseDuplicado.IdTypeExpense != typeExpense.IdTypeExpense)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpense updateTypeExpense = new()
            {
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                NameTypeExpense = typeExpense.NameTypeExpense.Trim(),
                DescriptionTypeExpense = typeExpense.DescriptionTypeExpense?.Trim() ?? string.Empty,
                IdStatusBudget = typeExpenseSearch.IdStatusBudget,
                CreationUser = typeExpenseSearch.CreationUser,
                CreationDate = typeExpenseSearch.CreationDate,
                ModificationUser = typeExpenseSearch.ModificationUser,
                ModificationDate = typeExpense.ModificationDate
            };

            UnitOfWork.BaseRepository<TypeExpense>().Update(updateTypeExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TypeExpense).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(typeExpenseSearch), JsonSerializer.Serialize(updateTypeExpense), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return typeExpense;
        }

        public TypeExpenseDto DeleteTypeExpense(TypeExpenseDto typeExpense)
        {
            ITypeExpenseRepository typeExpenseRepository = UnitOfWork.TypeExpenseRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            TypeExpenseExtendDto? typeExpenseSearch = typeExpenseRepository.GetTypeExpenseByIdTypeExpense(typeExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = typeExpense.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeExpenseSearch.IdStatusBudget == typeExpense.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeExpense deleteTypeExpense = new()
            {
                IdTypeExpense = typeExpenseSearch.IdTypeExpense,
                NameTypeExpense = typeExpenseSearch.NameTypeExpense.Trim(),
                DescriptionTypeExpense = typeExpenseSearch.DescriptionTypeExpense?.Trim() ?? string.Empty,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = typeExpenseSearch.CreationUser,
                CreationDate = typeExpenseSearch.CreationDate,
                ModificationUser = typeExpenseSearch.ModificationUser,
                ModificationDate = typeExpenseSearch.ModificationDate
            };

            UnitOfWork.BaseRepository<TypeExpense>().Update(deleteTypeExpense);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TypeExpense).Name, Constants.EntityAction.DELETE, JsonSerializer.Serialize(typeExpenseSearch), JsonSerializer.Serialize(deleteTypeExpense), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return typeExpense;
        }

        #endregion Constructor

    }
}