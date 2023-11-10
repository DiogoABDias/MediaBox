namespace MediaBox.Core.Models.Api;

internal class ApiLanguage
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
    [JsonProperty(PropertyName = "nativeName")]
    public string? NativeName { get; set; }
    [JsonProperty(PropertyName = "shortCode")]
    public string? ShortCode { get; set; }
}