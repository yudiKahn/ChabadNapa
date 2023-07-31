
using ChabadNapa.Models;
using Microsoft.JSInterop;

namespace ChabadNapa.Extensions;

public static class Extensions
{
    public static InfoCategoryEnum[] GetCategories(this InfoItem item)
    {
        return item.Categories
                .Where(c => Enum.TryParse<InfoCategoryEnum>(c, out _))
                .Select(Enum.Parse<InfoCategoryEnum>)
                .ToArray();
    }

    public static void SetLocalStorage(this IJSRuntime js, string key, string val)
    {
        js.InvokeVoidAsync("localStorage.setItem", key, val);
    }

    public static async Task<string?> GetLocalStorage(this IJSRuntime js, string key)
    {
        return await js.InvokeAsync<string?>("localStorage.getItem", key);
    }
}