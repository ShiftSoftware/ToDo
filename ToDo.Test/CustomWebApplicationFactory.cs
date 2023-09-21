﻿using ShiftSoftware.ShiftFrameworkTestingTools;
using ToDo.Data;

namespace ToDo.Test;

public class CustomWebApplicationFactory : ShiftCustomWebApplicationFactory<WebMarker, DB>
{
    public CustomWebApplicationFactory() : base(
        "SQLServer_Test_APIs",
        new ShiftCustomWebApplicationBearerAuthSettings
        {
            Enabled = true,
            TokenKeySettingKey = "Settings:TokenSettings:Key",
            TokenIssuerSettingKey = "Settings:TokenSettings:Issuer",
            TypeAuthActions = new List<Type>()
            {
                typeof(ToDoActions)
            }
        })
    { }
}

[CollectionDefinition("API Collection")]
public class APICollection : ICollectionFixture<CustomWebApplicationFactory>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
