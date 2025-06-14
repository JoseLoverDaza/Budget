﻿namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitutionDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdFinancialInstitution { get; set; }
        public string NameFinancialInstitution { get; set; } = null!;
        public string? DescriptionFinancialInstitution { get; set; }

        public int IdStatusBudget { get; set; }
       
        #endregion

    }
}