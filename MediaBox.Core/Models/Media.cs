namespace MediaBox.Core.Models;
abstract class Media
{
    internal string Name { get; set; } = string.Empty;
    internal int Year { get; set; }
    internal MediaType Type { get; set; }
}