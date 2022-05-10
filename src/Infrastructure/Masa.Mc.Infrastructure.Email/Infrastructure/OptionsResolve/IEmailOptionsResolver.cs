﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Mc.Infrastructure.Email.Infrastructure.OptionsResolve;

public interface IEmailOptionsResolver
{
    Task<IEmailOptions> ResolveAsync();
}
