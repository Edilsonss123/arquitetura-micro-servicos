using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("geek_shopping", "GeekShopping Server"),
            new ApiScope(name: "read", "Read Data"),
            new ApiScope(name: "write", "Write Data"),
            new ApiScope(name: "delete", "Delete Data"),
        };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "cliente",
                ClientSecrets = { new Secret("3d|1$0|\\|20_ç+243gtsdfgdfgç-".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" }
            },
            new Client
            {
                ClientId = "geek_shopping",
                ClientSecrets = { new Secret("3d|1$0|\\|20_ç+243gtsdfgdfgç-".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"https://localhost:7256/signin-oidc"},
                PostLogoutRedirectUris = {"https://localhost:7256/signout-callback-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "geek_shopping"
                }
                // AllowedScopes = { "read", "write", "profile" }
            }
        };
    }
}