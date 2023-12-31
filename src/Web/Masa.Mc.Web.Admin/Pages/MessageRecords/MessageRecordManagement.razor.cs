﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Mc.Web.Admin.Pages.MessageRecords;

public partial class MessageRecordManagement : AdminCompontentBase
{
    public List<DataTableHeader<MessageRecordDto>> Headers { get; set; } = new();

    private MessageRecordDetailModal _detailModal = default!;
    private GetMessageRecordInputDto _queryParam = new() { TimeType = MessageRecordTimeTypes.ExpectSendTime };
    private PaginatedListDto<MessageRecordDto> _entities = new();
    private List<ChannelDto> _channelItems = new();
    private bool advanced = false;
    private List<KeyValuePair<string, bool>> _successItems { get; set; } = new();
    private bool isAnimate;

    ChannelService ChannelService => McCaller.ChannelService;

    MessageRecordService MessageRecordService => McCaller.MessageRecordService;

    protected override async Task OnInitializedAsync()
    {
        var _prefix = "DisplayName.MessageRecord";
        Headers = new()
        {
            new() { Text = T("DisplayName.MessageTaskReceiver"), Value = "Receiver", Sortable = false, Width = "147px" },
            new() { Text = T(nameof(MessageTaskReceiverDto.Email)), Value = nameof(MessageTaskReceiverDto.Email), Sortable = false, Width = "157px" },
            new() { Text = T("DisplayName.Channel"), Value = "ChannelDisplayName", Sortable = false, Width = "80px" },
            new() { Text = T($"{_prefix}{nameof(MessageRecordDto.DisplayName)}"), Value = nameof(MessageRecordDto.DisplayName), Sortable = false, Width = "120px" },
            new() { Text = T($"{_prefix}{nameof(MessageRecordDto.ExpectSendTime)}"), Value = nameof(MessageRecordDto.ExpectSendTime), Sortable = false, Width = "120px" },
            new() { Text = T($"{_prefix}{nameof(MessageRecordDto.SendTime)}"), Value = nameof(MessageRecordDto.SendTime), Sortable = false, Width = "120px" },
            new() { Text = T($"{_prefix}{nameof(MessageRecordDto.Success)}"), Value = nameof(MessageRecordDto.Success), Sortable = false, Width = "56px" },
            new() { Text = T($"{_prefix}{nameof(MessageRecordDto.FailureReason)}"), Value = nameof(MessageRecordDto.FailureReason), Sortable = false, Width = "100px" },
            new() { Text = T("Action"), Value = "Action", Sortable = false, Width = 72, Align=DataTableHeaderAlign.Center },
        };
        _channelItems = (await ChannelService.GetListAsync(new GetChannelInputDto(99))).Result;
        _successItems = new()
        {
            new(T("Success"), true),
            new(T("Failure"), false)
        };
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadData();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task LoadData()
    {
        Loading = true;
        _entities = (await MessageRecordService.GetListAsync(_queryParam));
        Loading = false;
        StateHasChanged();
    }

    private async Task HandleOk()
    {
        await LoadData();
    }

    private async Task RefreshAsync()
    {
        _queryParam.Page = 1;
        await LoadData();
    }

    private async Task HandlePageChanged(int page)
    {
        _queryParam.Page = page;
        await LoadData();
    }

    private async Task HandlePageSizeChanged(int pageSize)
    {
        _queryParam.PageSize = pageSize;
        await LoadData();
    }

    private async Task HandleClearAsync()
    {
        _queryParam = new() { TimeType = MessageRecordTimeTypes.ExpectSendTime };
        await LoadData();
    }

    private void ToggleAdvanced()
    {
        advanced = !advanced;
        isAnimate = true;
    }
}
