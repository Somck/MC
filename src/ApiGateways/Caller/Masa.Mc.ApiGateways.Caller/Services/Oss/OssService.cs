﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Mc.ApiGateways.Caller.Services.Oss;

public class OssService : ServiceBase
{
    protected override string BaseUrl { get; set; }

    public OssService(ICaller caller) : base(caller)
    {
        BaseUrl = "api/oss/";
    }

    public async Task<SecurityTokenDto> GetSecurityTokenAsync()
    {
        return await GetAsync<SecurityTokenDto>("SecurityToken");
    }
}
