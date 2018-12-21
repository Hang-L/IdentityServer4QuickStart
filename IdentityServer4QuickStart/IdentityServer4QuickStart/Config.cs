using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer4QuickStart
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>
            {
               new ApiResource("api1","MyApp")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "api1"}
                },
                new Client
                {
                    ClientId="up.client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api1" }
                },
                new Client
                {
                    ClientId="mvc",
                    ClientName="OpenIDConnect",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    //ClientSecrets={
                    //    new Secret("secret".Sha256())
                    //},
                    RedirectUris={ "http://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris={ "http://localhost:5002/signout-callback-oidc"},
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="alice",
                    Password="123456",
                    Claims=new []
                    {
                        new Claim("name","Alice"),
                        new Claim("website","https://alice.com")

                    }
                },
                new TestUser
                {
                    SubjectId="2",
                    Username="bob",
                    Password="123456",
                    Claims=new[]
                    {
                        new Claim("name","Bob"),
                        new Claim("website","https://bob.com")
                    }
                }
            };
        }


        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()

            };
        }
    }

}
