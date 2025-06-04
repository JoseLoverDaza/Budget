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

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(FinancialInstitutionDto financialInstitution)
        {
            return (
                       from f in _context.FinancialInstitutions.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on f.IdStatus equals s.IdStatus
                       where f.IdFinancialInstitution == financialInstitution.IdFinancialInstitution
                       select new FinancialInstitutionExtendDto
                       {
                           IdFinancialInstitution = f.IdFinancialInstitution,
                           Name = f.Name,
                           IdStatus = f.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(FinancialInstitutionDto financialInstitution)
        {
            return (
                       from f in _context.FinancialInstitutions.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on f.IdStatus equals s.IdStatus
                       where f.Name == financialInstitution.Name
                       select new FinancialInstitutionExtendDto
                       {
                           IdFinancialInstitution = f.IdFinancialInstitution,
                           Name = f.Name,
                           IdStatus = f.IdStatus,
                           NameStatus = s.Name,
                           DescriptionStatus = s.Description
                       }
                   )
                   .FirstOrDefault();
        }

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(FinancialInstitutionDto financialInstitution)
        {
            return (
                    from f in _context.FinancialInstitutions.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on f.IdStatus equals s.IdStatus
                    where f.IdStatus == financialInstitution.IdStatus
                    select new FinancialInstitutionExtendDto
                    {
                        IdFinancialInstitution = f.IdFinancialInstitution,
                        Name = f.Name,
                        IdStatus = f.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                  )
                 .ToList();
        }

        #endregion

    }
}
