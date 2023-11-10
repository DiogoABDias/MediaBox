namespace MediaBox.Frm.Models;
public class Source
{
    //Properties
    [JsonProperty("id")]
    public int Id { get; private set; }
    [JsonProperty("name")]
    public string Name { get; private set; } = string.Empty;
    [JsonProperty("type")]
    public MediaType Type { get; private set; }
    [JsonProperty("language")]
    public string Language { get; private set; } = string.Empty;
    [JsonProperty("path")]
    public string Path { get; private set; } = string.Empty;

    //Constructor
    public Source(int id, string name, MediaType type, string language, string path)
    {
        Id = id;
        Name = name;
        Type = type;
        Language = language;
        Path = path;
    }
}