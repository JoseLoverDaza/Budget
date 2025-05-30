namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using Domain.Context;
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

        public TypeExpenseExtendDto? GetTypeExpenseById(int idTypeExpense)
        {
            return (
                       from t in _context.TypeExpenses.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on t.IdStatus equals s.IdStatus
                       where t.IdTypeExpense == idTypeExpense
                       select new TypeExpenseExtendDto
                       {
                           IdTypeExpense = t.IdTypeExpense,
                           Name = t.Name,
                           IdStatus = t.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public TypeExpenseExtendDto? GetTypeExpenseByName(string name)
        {
            return (
                       from t in _context.TypeExpenses.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on t.IdStatus equals s.IdStatus
                       where t.Name == name
                       select new TypeExpenseExtendDto
                       {
                           IdTypeExpense = t.IdTypeExpense,
                           Name = t.Name,
                           IdStatus = t.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(int idStatus)
        {
            return (
                    from t in _context.TypeExpenses.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on t.IdStatus equals s.IdStatus
                    where t.IdStatus == idStatus
                    select new TypeExpenseExtendDto
                    {
                        IdTypeExpense = t.IdTypeExpense,
                        Name = t.Name,
                        IdStatus = t.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                 )
                .ToList();
        }

        #endregion

    }
}