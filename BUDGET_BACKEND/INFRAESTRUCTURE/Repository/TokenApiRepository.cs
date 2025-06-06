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

        public TokenApiExtendDto? GetTokenApiById(TokenApiDto tokenApi)
        {
            return (
                    from t in _context.TokenApis.AsNoTracking()
                    join u in _context .Users.AsNoTracking()
                    on t.IdUser equals u.IdUser
                    join s in _context.Status.AsNoTracking()
                    on t.IdStatus equals s.IdStatus
                    where t.IdTokenApi == tokenApi.IdTokenApi
                    select new TokenApiExtendDto
                    {
                        IdTokenApi = t.IdTokenApi,
                        Token = t.Token,
                        CreationDate = t.CreationDate,
                        ExpirationDate = t.ExpirationDate,
                        IdUser = t.IdUser,
                        EmailUser = u.Email,
                        LoginUser = u.Login,
                        IdStatus = t.IdStatus,
                        NameStatus = s.Name,
                        DescriptionStatus = s.Description
                    }
                )
                .FirstOrDefault();
        }

        public TokenApiExtendDto? GetTokenApiByToken(TokenApiDto tokenApi)
        {
            return (
                   from t in _context.TokenApis.AsNoTracking()
                   join u in _context.Users.AsNoTracking()
                   on t.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on t.IdStatus equals s.IdStatus
                   where t.Token == tokenApi.Token
                   select new TokenApiExtendDto
                   {
                       IdTokenApi = t.IdTokenApi,
                       Token = t.Token,
                       CreationDate = t.CreationDate,
                       ExpirationDate = t.ExpirationDate,
                       IdUser = t.IdUser,
                       EmailUser = u.Email,
                       LoginUser = u.Login,
                       IdStatus = t.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .FirstOrDefault();
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDate(TokenApiDto tokenApi)
        {
            return (
                   from t in _context.TokenApis.AsNoTracking()
                   join u in _context.Users.AsNoTracking()
                   on t.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on t.IdStatus equals s.IdStatus
                   where t.CreationDate == tokenApi.CreationDate
                   select new TokenApiExtendDto
                   {
                       IdTokenApi = t.IdTokenApi,
                       Token = t.Token,
                       CreationDate = t.CreationDate,
                       ExpirationDate = t.ExpirationDate,
                       IdUser = t.IdUser,
                       EmailUser = u.Email,
                       LoginUser = u.Login,
                       IdStatus = t.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByUser(TokenApiDto tokenApi)
        {
            return (
                   from t in _context.TokenApis.AsNoTracking()
                   join u in _context.Users.AsNoTracking()
                   on t.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on t.IdStatus equals s.IdStatus
                   where t.IdUser == tokenApi.IdUser
                   select new TokenApiExtendDto
                   {
                       IdTokenApi = t.IdTokenApi,
                       Token = t.Token,
                       CreationDate = t.CreationDate,
                       ExpirationDate = t.ExpirationDate,
                       IdUser = t.IdUser,
                       EmailUser = u.Email,
                       LoginUser = u.Login,
                       IdStatus = t.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByStatus(TokenApiDto tokenApi)
        {
            return (
                   from t in _context.TokenApis.AsNoTracking()
                   join u in _context.Users.AsNoTracking()
                   on t.IdUser equals u.IdUser
                   join s in _context.Status.AsNoTracking()
                   on t.IdStatus equals s.IdStatus
                   where t.IdStatus == tokenApi.IdStatus
                   select new TokenApiExtendDto
                   {
                       IdTokenApi = t.IdTokenApi,
                       Token = t.Token,
                       CreationDate = t.CreationDate,
                       ExpirationDate = t.ExpirationDate,
                       IdUser = t.IdUser,
                       EmailUser = u.Email,
                       LoginUser = u.Login,
                       IdStatus = t.IdStatus,
                       NameStatus = s.Name,
                       DescriptionStatus = s.Description
                   }
               )
               .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDateStatus(TokenApiDto tokenApi)
        {
            return (
                  from t in _context.TokenApis.AsNoTracking()
                  join u in _context.Users.AsNoTracking()
                  on t.IdUser equals u.IdUser
                  join s in _context.Status.AsNoTracking()
                  on t.IdStatus equals s.IdStatus
                  where t.CreationDate == tokenApi.CreationDate && t.IdStatus == tokenApi.IdStatus
                  select new TokenApiExtendDto
                  {
                      IdTokenApi = t.IdTokenApi,
                      Token = t.Token,
                      CreationDate = t.CreationDate,
                      ExpirationDate = t.ExpirationDate,
                      IdUser = t.IdUser,
                      EmailUser = u.Email,
                      LoginUser = u.Login,
                      IdStatus = t.IdStatus,
                      NameStatus = s.Name,
                      DescriptionStatus = s.Description
                  }
              )
              .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateStatus(TokenApiDto tokenApi)
        {
            return (
                 from t in _context.TokenApis.AsNoTracking()
                 join u in _context.Users.AsNoTracking()
                 on t.IdUser equals u.IdUser
                 join s in _context.Status.AsNoTracking()
                 on t.IdStatus equals s.IdStatus
                 where t.ExpirationDate == tokenApi.ExpirationDate && t.IdStatus == tokenApi.IdStatus
                 select new TokenApiExtendDto
                 {
                     IdTokenApi = t.IdTokenApi,
                     Token = t.Token,
                     CreationDate = t.CreationDate,
                     ExpirationDate = t.ExpirationDate,
                     IdUser = t.IdUser,
                     EmailUser = u.Email,
                     LoginUser = u.Login,
                     IdStatus = t.IdStatus,
                     NameStatus = s.Name,
                     DescriptionStatus = s.Description
                 }
             )
             .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByUserStatus(TokenApiDto tokenApi)
        {
            return (
                from t in _context.TokenApis.AsNoTracking()
                join u in _context.Users.AsNoTracking()
                on t.IdUser equals u.IdUser
                join s in _context.Status.AsNoTracking()
                on t.IdStatus equals s.IdStatus
                where t.IdUser == tokenApi.IdUser && t.IdStatus == tokenApi.IdStatus
                select new TokenApiExtendDto
                {
                    IdTokenApi = t.IdTokenApi,
                    Token = t.Token,
                    CreationDate = t.CreationDate,
                    ExpirationDate = t.ExpirationDate,
                    IdUser = t.IdUser,
                    EmailUser = u.Email,
                    LoginUser = u.Login,
                    IdStatus = t.IdStatus,
                    NameStatus = s.Name,
                    DescriptionStatus = s.Description
                }
            )
            .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDateUserStatus(TokenApiDto tokenApi)
        {
            return (
                from t in _context.TokenApis.AsNoTracking()
                join u in _context.Users.AsNoTracking()
                on t.IdUser equals u.IdUser
                join s in _context.Status.AsNoTracking()
                on t.IdStatus equals s.IdStatus
                where t.CreationDate == tokenApi.CreationDate && t.IdUser == tokenApi.IdUser && t.IdStatus == tokenApi.IdStatus                
                select new TokenApiExtendDto
                {
                    IdTokenApi = t.IdTokenApi,
                    Token = t.Token,
                    CreationDate = t.CreationDate,
                    ExpirationDate = t.ExpirationDate,
                    IdUser = t.IdUser,
                    EmailUser = u.Email,
                    LoginUser = u.Login,
                    IdStatus = t.IdStatus,
                    NameStatus = s.Name,
                    DescriptionStatus = s.Description
                }
            )
            .ToList();
        }

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateUserStatus(TokenApiDto tokenApi)
        {
            return (
                from t in _context.TokenApis.AsNoTracking()
                join u in _context.Users.AsNoTracking()
                on t.IdUser equals u.IdUser
                join s in _context.Status.AsNoTracking()
                on t.IdStatus equals s.IdStatus
                where t.ExpirationDate == tokenApi.ExpirationDate && t.IdUser == tokenApi.IdUser && t.IdStatus == tokenApi.IdStatus
                select new TokenApiExtendDto
                {
                    IdTokenApi = t.IdTokenApi,
                    Token = t.Token,
                    CreationDate = t.CreationDate,
                    ExpirationDate = t.ExpirationDate,
                    IdUser = t.IdUser,
                    EmailUser = u.Email,
                    LoginUser = u.Login,
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