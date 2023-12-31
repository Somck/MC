﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Mc.Contracts.Admin.Dtos.ReceiverGroups.Validator;

public class ReceiverGroupUpsertDtoValidator : AbstractValidator<ReceiverGroupUpsertDto>
{
    public ReceiverGroupUpsertDtoValidator()
    {
        RuleFor(inputDto => inputDto.DisplayName).Required("DisplayNameRequired")
            .Length(2, 50).WithMessage("DisplayNameLength")
            .ChineseLetterNumber().WithMessage("DisplayNameChineseLetterNumber");
        RuleFor(inputDto => inputDto.Items).Required("ReceiverGroupItemsRequired");
    }
}
