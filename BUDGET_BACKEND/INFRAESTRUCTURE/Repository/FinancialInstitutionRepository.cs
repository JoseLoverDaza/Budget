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

        public FinancialInstitutionExtendDto? GetFinancialInstitutionById(int idFinancialInstitution)
        {
            return (
                       from f in _context.FinancialInstitutions.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on f.IdStatus equals s.IdStatus
                       where f.IdFinancialInstitution == idFinancialInstitution
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

        public FinancialInstitutionExtendDto? GetFinancialInstitutionByName(string name)
        {
            return (
                       from f in _context.FinancialInstitutions.AsNoTracking()
                       join s in _context.Status.AsNoTracking()
                       on f.IdStatus equals s.IdStatus
                       where f.Name == name
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

        public List<FinancialInstitutionExtendDto> GetFinancialInstitutionsByStatus(int idStatus)
        {
            return (
                    from f in _context.FinancialInstitutions.AsNoTracking()
                    join s in _context.Status.AsNoTracking()
                    on f.IdStatus equals s.IdStatus
                    where f.IdStatus == idStatus
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
