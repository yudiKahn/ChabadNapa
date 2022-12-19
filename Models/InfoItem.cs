

namespace  ChabadNapa.Models;

public struct InfoItem
{
    public string Name { get; set; }
    public string Img { get; set; }
    public string Location { get; set; }
    public InfoCategory[] Categories { get; set; }
}