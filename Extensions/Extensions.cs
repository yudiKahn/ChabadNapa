
using ChabadNapa.Models;

namespace ChabadNapa.Extensions;

public static class Extensions
{
    public static string ToFriendlyString(this InfoCategoryEnum cat)
    {
        return cat switch
        {
            InfoCategoryEnum.Attraction => "Attraction",
            InfoCategoryEnum.PlacesToTravel => "Places To Travel",
            InfoCategoryEnum.Beach => "Beach",
            InfoCategoryEnum.Transportation => "Transportation",
            InfoCategoryEnum.CovidTest => "COVID Test",
            InfoCategoryEnum.TravelGuides => "Travel Guides",
            _ => string.Empty
        };
    }

    public static InfoCategoryEnum[] GetCategories(this InfoItem item)
    {
        return item.Categories
                .Where(c => Enum.TryParse<InfoCategoryEnum>(c, out _))
                .Select(Enum.Parse<InfoCategoryEnum>)
                .ToArray();
    }
}