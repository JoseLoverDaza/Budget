﻿namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleBudgetExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleBudgetExtendDto : RoleBudgetDto
    {

        #region Atributos y Propiedades

        public string NameStatusBudget { get; set; } = null!;
        public string? DescriptionStatusBudget { get; set; }

        #endregion

    }
}