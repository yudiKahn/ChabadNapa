using AKSoftware.Localization.MultiLanguages;
using ChabadNapa.Services;
using Microsoft.AspNetCore.Components;

namespace ChabadNapa.Models;

public class PageBase : ComponentBase, IDisposable
{
    bool _UsedOnAfterRender;

    [Inject] 
    public StateService State { get; set; }

    [Inject]
    public ILanguageContainerService Loc { get; set; }

    public void Dispose()
    {
        State.StateHasChanged -= OnStateHasChanged;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (_UsedOnAfterRender) return;

        _UsedOnAfterRender = true;
        if (firstRender)
            State.StateHasChanged += OnStateHasChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (_UsedOnAfterRender) return;

        _UsedOnAfterRender = true;
        if (firstRender)
        {
            State.StateHasChanged += OnStateHasChanged;
        }
    }

    public virtual void OnStateHasChanged(object? sender, string args) => InvokeAsync(StateHasChanged);

}