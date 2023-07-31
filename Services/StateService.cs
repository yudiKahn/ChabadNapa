using System.Runtime.CompilerServices;
using AKSoftware.Localization.MultiLanguages;
using Microsoft.JSInterop;
using CultureInfo = System.Globalization.CultureInfo;

namespace ChabadNapa.Services;

public class StateService
{

    readonly ILanguageContainerService _LocService;
    readonly IJSRuntime _JsRuntime;

    CultureInfo _Culture;

    public CultureInfo Culture
    {
        get => _Culture;
        set
        {
            if (SetProperty(ref _Culture, value))
            {
                _LocService.SetLanguage(value);
            }
        }
    }

    public bool IsCulture(string cul) => cul == _LocService.CurrentCulture.Name;

    public event EventHandler<string>? StateHasChanged;

    public StateService(ILanguageContainerService locService, IJSRuntime jsRuntime)
    {
        _LocService = locService;
        _JsRuntime = jsRuntime;

        
    }


    bool SetProperty<T>(ref T field, T val, [CallerMemberName] string? propName = null)
    {
        if (propName is null) return false;
        if (EqualityComparer<T>.Default.Equals(field, val)) return false;

        field = val;
        StateHasChanged?.Invoke(this, propName);
        return true;
    }
}