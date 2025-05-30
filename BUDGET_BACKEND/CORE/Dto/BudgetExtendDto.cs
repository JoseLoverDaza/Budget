﻿namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetExtendDto : BudgetDto
    {

        #region Atributos y Propiedades

        public string EmailUser { get; set; } = null!;
        public string LoginUser { get; set; } = null!;
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}