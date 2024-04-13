using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServer6;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(name: "user", userClaims: new[] {JwtClaimTypes.Email}),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("scope1"),
            new ApiScope("scope2"),
            new ApiScope("api1"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            //Postman
            new Client
            {
                ClientId = "client",
                ClientName = "Client for Postman use",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedScopes = {"api1", "user"},
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowAccessTokensViaBrowser = true,
            },

            //swagger
            new Client
            {
                ClientId = "swagger",
                ClientName = "Client for Swagger use",
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedScopes = { "openid", "profile", "api1", "user"},
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = {"https://localhost:7207/swagger/oauth2-redirect.html"},
                AllowedCorsOrigins = {"https://localhost:7207"},
            },
            /*
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "scope1" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope2" }
            },*/
        };
}
