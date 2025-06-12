namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using Domain.Context;
    using Domain.Dto;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpenseRepository : BaseRepository<TypeAccount>, ITypeExpenseRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public TypeExpenseRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseByIdTypeExpense(TypeExpenseDto typeExpense)
        {
            return (
                       from t in _context.TypeExpenses.AsNoTracking()
                       join s in _context.StatusBudget.AsNoTracking()
                       on t.IdStatusBudget equals s.IdStatusBudget
                       where t.IdTypeExpense == typeExpense.IdTypeExpense
                       select new TypeExpenseExtendDto
                       {
                           IdTypeExpense = t.IdTypeExpense,
                           NameTypeExpense = t.NameTypeExpense,
                           DescriptionTypeExpense = t.DescriptionTypeExpense,
                           IdStatusBudget = t.IdStatusBudget,
                           NameStatusBudget = s.NameStatus,
                           DescriptionStatusBudget = s.DescriptionStatus,
                           CreationUser = t.CreationUser,
                           CreationDate = t.CreationDate,
                           ModificationUser = t.ModificationUser,
                           ModificationDate = t.ModificationDate
                       }
                   )
                   .FirstOrDefault();
        }

        public TypeExpenseExtendDto? GetTypeExpenseByNameTypeExpense(TypeExpenseDto typeExpense)
        {
            return (
                     from t in _context.TypeExpenses.AsNoTracking()
                     join s in _context.StatusBudget.AsNoTracking()
                     on t.IdStatusBudget equals s.IdStatusBudget
                     where t.NameTypeExpense == typeExpense.NameTypeExpense
                     select new TypeExpenseExtendDto
                     {
                         IdTypeExpense = t.IdTypeExpense,
                         NameTypeExpense = t.NameTypeExpense,
                         DescriptionTypeExpense = t.DescriptionTypeExpense,
                         IdStatusBudget = t.IdStatusBudget,
                         NameStatusBudget = s.NameStatus,
                         DescriptionStatusBudget = s.DescriptionStatus,
                         CreationUser = t.CreationUser,
                         CreationDate = t.CreationDate,
                         ModificationUser = t.ModificationUser,
                         ModificationDate = t.ModificationDate
                     }
                   )
                   .FirstOrDefault();
        }

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatusBudget(TypeExpenseDto typeExpense)
        {
            return (
                     from t in _context.TypeExpenses.AsNoTracking()
                     join s in _context.StatusBudget.AsNoTracking()
                     on t.IdStatusBudget equals s.IdStatusBudget
                     where t.IdStatusBudget == typeExpense.IdStatusBudget
                     select new TypeExpenseExtendDto
                     {
                        IdTypeExpense = t.IdTypeExpense,
                        NameTypeExpense = t.NameTypeExpense,
                        DescriptionTypeExpense = t.DescriptionTypeExpense,
                        IdStatusBudget = t.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = t.CreationUser,
                        CreationDate = t.CreationDate,
                        ModificationUser = t.ModificationUser,
                        ModificationDate = t.ModificationDate
                     }
                  )
                  .ToList();
        }

        #endregion

    }
}