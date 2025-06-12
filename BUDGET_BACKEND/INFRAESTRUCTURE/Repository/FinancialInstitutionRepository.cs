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
    /// Nombre: FinancialInstitutionRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitutionRepository : BaseRepository<FinancialInstitution>, IFinancialInstitutionRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public FinancialInstitutionRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByIdFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            return (
                    from f in _context.FinancialInstitutions.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on f.IdStatusBudget equals s.IdStatusBudget
                    where f.IdFinancialInstitution == financialInstitution.IdFinancialInstitution
                    select new FinancialInstitutionExtendDto
                    {
                        IdFinancialInstitution = f.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdStatusBudget = f.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = f.CreationUser,
                        CreationDate = f.CreationDate,
                        ModificationUser = f.ModificationUser,
                        ModificationDate = f.ModificationDate
                    }
                  )
                  .FirstOrDefault();
        }

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByNameFinancialInstitution(FinancialInstitutionDto financialInstitution)
        {
            return (
                    from f in _context.FinancialInstitutions.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on f.IdStatusBudget equals s.IdStatusBudget
                    where f.NameFinancialInstitution == financialInstitution.NameFinancialInstitution
                    select new FinancialInstitutionExtendDto
                    {
                        IdFinancialInstitution = f.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdStatusBudget = f.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = f.CreationUser,
                        CreationDate = f.CreationDate,
                        ModificationUser = f.ModificationUser,
                        ModificationDate = f.ModificationDate
                    }
                   )
                   .FirstOrDefault();
        }

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatusBudget(FinancialInstitutionDto financialInstitution)
        {
            return (
                    from f in _context.FinancialInstitutions.AsNoTracking()
                    join s in _context.StatusBudget.AsNoTracking()
                    on f.IdStatusBudget equals s.IdStatusBudget
                    where f.IdStatusBudget == financialInstitution.IdStatusBudget
                    select new FinancialInstitutionExtendDto
                    {
                        IdFinancialInstitution = f.IdFinancialInstitution,
                        NameFinancialInstitution = f.NameFinancialInstitution,
                        DescriptionFinancialInstitution = f.DescriptionFinancialInstitution,
                        IdStatusBudget = f.IdStatusBudget,
                        NameStatusBudget = s.NameStatus,
                        DescriptionStatusBudget = s.DescriptionStatus,
                        CreationUser = f.CreationUser,
                        CreationDate = f.CreationDate,
                        ModificationUser = f.ModificationUser,
                        ModificationDate = f.ModificationDate
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}