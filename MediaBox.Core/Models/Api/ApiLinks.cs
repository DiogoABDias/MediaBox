namespace MediaBox.Core.Models.Api;
internal class ApiLinks
{
    [JsonProperty("prev")]
    public object? Prev { get; set; }

    [JsonProperty("self")]
    public string? Self { get; set; }

    [JsonProperty("next")]
    public object? Next { get; set; }

    [JsonProperty("total_items")]
    public int TotalItems { get; set; }

    [JsonProperty("page_size")]
    public int PageSize { get; set; }
}