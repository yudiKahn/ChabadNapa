
namespace ChabadNapa.Models;

public struct Lang
{
    public string En { get; set; }
    public string He { get; set; }
}

public struct Hotel
{
    public Lang Title { get; set; }
    public string Text { get; set; }
    public string Img { get; set; }
    public string Link { get; set; }
}