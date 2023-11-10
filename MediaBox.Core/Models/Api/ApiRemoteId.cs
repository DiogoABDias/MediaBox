namespace MediaBox.Core.Models.Api;
internal class ApiRemoteId
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("sourceName")]
    public string? SourceName { get; set; }
}