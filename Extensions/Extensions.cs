
using ChabadNapa.Models;

namespace ChabadNapa.Extensions;

public static class Extensions
{
    public static string ToFriendlyString(this InfoCategory cat)
    {
        return cat switch
        {
            InfoCategory.Attraction => "Attraction",
            InfoCategory.PlacesToTravel => "Places To Travel",
            InfoCategory.Beach => "Beach",
            InfoCategory.Transportation => "Transportation",
            InfoCategory.CovidTest => "COVID Test",
            InfoCategory.TravelGuides => "Travel Guides",
            _ => string.Empty
        };
    }
}