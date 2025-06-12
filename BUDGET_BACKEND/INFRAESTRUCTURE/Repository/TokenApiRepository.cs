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
    /// Nombre: TokenApiRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TokenApiRepository : BaseRepository<TokenApi>, ITokenApiRepository
    {

        #region Atributos y Propiedades

        private readonly EFContext _context;

        #endregion

        #region Constructor

        public TokenApiRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos y Funciones

        public TokenApiExtendDto? GetTokenApiByIdTokenApi(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.IdTokenApi == tokenApi.IdTokenApi
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,                       
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public TokenApiExtendDto? GetTokenApiByToken(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.Token == tokenApi.Token
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByCreationDate(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.CreationDate == tokenApi.CreationDate
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByUserBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.IdUserBudget == tokenApi.IdUserBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByStatusBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.IdStatusBudget == tokenApi.IdStatusBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByCreationDateStatusBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.CreationDate == tokenApi.CreationDate && t.IdStatusBudget == tokenApi.IdStatusBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateStatusBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.ExpirationDate == tokenApi.ExpirationDate && t.IdStatusBudget == tokenApi.IdStatusBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.IdUserBudget == tokenApi.IdUserBudget && t.IdStatusBudget == tokenApi.IdStatusBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByCreationDateUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.CreationDate == tokenApi.CreationDate && t.IdUserBudget == tokenApi.IdUserBudget && t.IdStatusBudget == tokenApi.IdStatusBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context.UsersBudget.AsNoTracking()
                    on t.IdUserBudget equals u.IdUserBudget
                    join s in _context.StatusBudget.AsNoTracking()
                    on t.IdStatusBudget equals s.IdStatusBudget
                    where t.ExpirationDate == tokenApi.ExpirationDate && t.IdUserBudget == tokenApi.IdUserBudget && t.IdStatusBudget == tokenApi.IdStatusBudget
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        ExpirationDate = t.ExpirationDate,
                        IdUserBudget = t.IdUserBudget,
                        EmailUserBudget = u.Email,
                        UsernameUserBudget = u.Username,
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