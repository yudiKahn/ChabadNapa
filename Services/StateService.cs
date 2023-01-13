using System.Runtime.CompilerServices;
using AKSoftware.Localization.MultiLanguages;
using CultureInfo = System.Globalization.CultureInfo;

namespace ChabadNapa.Services;

public class StateService
{

    readonly ILanguageContainerService _LocService;

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

    public event EventHandler<string> StateHasChanged;

    public StateService(ILanguageContainerService locService)
    {
        _LocService = locService;
    }


    bool SetProperty<T>(ref T field, T val, [CallerMemberName] string? propName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, val)) return false;
        if (propName is null) return false;

        field = val;
        StateHasChanged?.Invoke(this, propName);
        return true;
    }
}