﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes ={"CatalogFullPermisson","CatalogReadPermisson"},
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes={"DiscountFullPermisson"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes={"OrderFullPermisson"}
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.Address(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermisson","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermisson","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermisson","Full authority for discount operations"),
            new ApiScope("OrderFullPermisson","Full authority for order operations")

        };
    }
}