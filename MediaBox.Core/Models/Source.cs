namespace MediaBox.Frm.Models;
internal class Source
{
    //Properties
    public string Name { get; private set; } = string.Empty;
    public MediaType Type { get; private set; }
    public string Language { get; private set; } = string.Empty;
    public string Path { get; private set; } = string.Empty;

    //Constructor
    public Source(string name, MediaType type, string language, string path)
    {
        Name = name;
        Type = type;
        Language = language;
        Path = path;
    }
}