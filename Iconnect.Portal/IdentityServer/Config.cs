using Iconnect.Dominio.Helpers;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Iconnect.Portal.IdentityServer
{
    public class Config
    {
        private readonly IOptions<AppSettings> _settings;
        public Config(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // Credenciais da Aplicação
            return new List<Client>
            {
                // OpenID Connect
                new Client
                {
                    // O Nome ÚNICO da nossa aplicação autorizada no nosso servidor de autoridade
                    ClientId = "Iconnect.Portal",
                    
                    // Nome de exibição da nossa aplicação
                    ClientName = "Iconnect Portal",
                    
                    //Tipo de autenticação permitida
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret(Startup.staticConfig["AppSettings:Secret"].Sha256())
                    },

                    //Url de redicionamento para quando o login for efetuado com sucesso.
                    RedirectUris = { Startup.staticConfig["AppSettings:WebSiteUrl"] },

                    //Url de redirecionamento para quando o logout for efetuado com sucesso.
                    PostLogoutRedirectUris = { Startup.staticConfig["AppSettings:WebSiteUrl"] + "login" },
                    AccessTokenLifetime = 43200,

                    //Escopos permitidos dentro da aplicação
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    },

                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "admin",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Admin teste"),
                        new Claim("website", "https://google.com.br"),
                        new Claim("email", "admin@admin.com")
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("Iconnect.Portal")
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Subject,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.NickName,
                        JwtClaimTypes.GivenName,
                        JwtClaimTypes.Id,
                        JwtClaimTypes.Role,
                        "admin"
                    }
                }
            };
        }
    }
}
