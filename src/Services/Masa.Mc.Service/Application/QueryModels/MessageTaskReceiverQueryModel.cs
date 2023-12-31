﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Mc.Service.Admin.Application.QueryModels;

public class MessageTaskReceiverQueryModel
{
    public Guid SubjectId { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string Account { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public MessageTaskReceiverTypes Type { get; set; }

    public ExtraPropertyDictionary Variables { get; set; } = new();
}
